﻿using GameboyAdvanced.Core.Debug;
using GameboyAdvanced.Core.Dma;
using GameboyAdvanced.Core.Interrupts;
using GameboyAdvanced.Core.Ppu.Registers;
using System;
using System.Runtime.CompilerServices;
using static GameboyAdvanced.Core.IORegs;

namespace GameboyAdvanced.Core.Ppu
{
    /// <summary>
    /// This class both encapsulates the state of the PPU and provides 
    /// functionality for rendering the current state into a bitmap
    /// </summary>
    public unsafe partial class Ppu
    {
        private const int CyclesPerDot = 4;
        private const int CyclesPerVisibleLine = CyclesPerDot * Device.WIDTH; // 960
        internal const int HBlankFlagCycles = 1006; // Note this is more than the number of cycles in the visible line
        private const int HBlankDots = 68;
        private const int CyclesPerHBlank = CyclesPerDot * HBlankDots; // 272
        private const int CyclesPerLine = CyclesPerVisibleLine + CyclesPerHBlank; // 1232
        private const int VBlankLines = 68;
        private const int VisibleLineCycles = Device.HEIGHT * CyclesPerLine; // 197,120
        private const int VBlankCycles = VBlankLines * CyclesPerLine; // 83,776
        public const int FrameCycles = VisibleLineCycles + VBlankCycles; // 280,896

        private readonly BaseDebugger _debugger;

        // TODO - Might be more efficient to store as ushorts given access is over 16 bit bus?
        public readonly byte[] Vram = new byte[0x18000]; // 96KB
        public readonly byte[] FrameBuffer = new byte[Device.WIDTH * Device.HEIGHT * 4]; // RGBA order

        public DisplayCtrl Dispcnt = new();
        public ushort GreenSwap;
        public GeneralLcdStatus Dispstat = new();
        public ushort CurrentLine;
        public readonly Background[] Backgrounds = new Background[4] { new Background(0), new Background(1), new Background(2), new Background(3) };

        private readonly Windows _windows = new();
        public Mosaic Mosaic = new();
        public readonly ColorEffects ColorEffects = new();

        public int CurrentLineCycles;

        internal Ppu(BaseDebugger debugger)
        {
            _debugger = debugger ?? throw new ArgumentNullException(nameof(debugger));

            for (var ii = 0; ii < 4; ii++)
            {
                _scanlineBgBuffer[ii] = new int[Device.WIDTH];
            }

            for (var ii = 0; ii < _sprites.Length; ii++)
            {
                _sprites[ii] = new Sprite(ii);
            }

            for (var ii = 0; ii < Device.WIDTH; ii++)
            {
                _bgBuffer[ii] = new BgPixelProperties()
                {
                    PaletteColor = new int[2],
                    Priority = new int[2],
                    ColorIsPaletteIndex = new bool[2],
                    BgId = new int[2]
                };
            }

            Reset();
        }

        internal void Reset()
        {
            Array.Clear(_paletteRam, 0, _paletteRam.Length);
            Array.Clear(Vram, 0, Vram.Length);
            Array.Clear(_oam, 0, _oam.Length);
            Array.Clear(FrameBuffer, 0, FrameBuffer.Length);
            Array.Clear(_objBuffer, 0, _objBuffer.Length);
            Dispcnt.Init();
            Dispcnt.Reset();
            GreenSwap = 0;
            Dispstat = new GeneralLcdStatus();
            CurrentLine = 0;
            CurrentLineCycles = 0;
            Mosaic = new Mosaic();
            ColorEffects.Reset();
            for (var ii = 0; ii < 4; ii++)
            {
                Backgrounds[ii].Reset();
                Array.Clear(_scanlineBgBuffer[ii], 0, _scanlineBgBuffer[ii].Length);
            }
            _windows.Reset();

            foreach (var sprite in _sprites)
            {
                sprite.Reset();
            }
        }

        /// <summary>
        /// Returns the current state of the frame buffer and therefore should only
        /// be called when the buffer is fully complete (i.e. during vblank)
        /// </summary>
        internal byte[] GetFrame()
        {
            return FrameBuffer;
        }

        /// <summary>
        /// Scheduled event which occurs on cycle 1006 of every scanline (both 
        /// within vblank and without)
        /// </summary>
        internal static void HBlankStartEvent(Device device)
        {
            var ppu = device.Ppu;
            device.DmaData.StartHdma(ppu.CurrentLine);

            ppu.Dispstat.HBlankFlag = true;
            if (ppu.Dispstat.HBlankIrqEnable)
            {
                device.InterruptInterconnect.RaiseInterrupt(Interrupt.LCDHBlank);
            }

            if (ppu.CurrentLine < Device.HEIGHT)
            {
                ppu.DrawCurrentScanline();
                Array.Fill(ppu._windowState, -1); // Clear window state after rendering scanline so it's ready to refill

                if (ppu.Dispcnt.BgMode != BgMode.Video0) // Mode 0 has no affine backgrounds
                {
                    for (var ii = 2; ii < 4; ii++)
                    {
                        if (ppu.Dispcnt.ScreenDisplayBg[ii])
                        {
                            ppu.Backgrounds[ii].RefPointXLatched += ppu.Backgrounds[ii].Dmx;
                            ppu.Backgrounds[ii].RefPointYLatched += ppu.Backgrounds[ii].Dmy;
                        }
                    }
                }
            }

            device.Scheduler.ScheduleEvent(EventType.HBlankEnd, &HBlankEndEvent, CyclesPerLine - 1 - HBlankFlagCycles);
        }

        internal static void HBlankEndEvent(Device device)
        {
            var ppu = device.Ppu;

            ppu.Dispstat.VCounterFlag = false;
            ppu.Dispstat.HBlankFlag = false;
            ppu.CurrentLine++;
            ppu.CurrentLineCycles = 0;

            if (ppu.CurrentLine < Device.HEIGHT)
            {
                // Sprites are latched the line before they're displayed, this therefore latches the _next_ lines sprites
                ppu.DrawSpritesOnLine((int)ppu.Dispcnt.BgMode >= 3);
            }
            else if (ppu.CurrentLine == Device.HEIGHT)
            {
                device.DmaData.StartVdma();

                ppu.Dispstat.VBlankFlag = true;
                if (ppu.Dispstat.VBlankIrqEnable)
                {
                    device.InterruptInterconnect.RaiseInterrupt(Interrupt.LCDVBlank);
                }

                // Latch affine registers
                for (var ii = 2; ii < 4; ii++)
                {
                    if (ppu.Dispcnt.ScreenDisplayBg[ii])
                    {
                        ppu.Backgrounds[ii].RefPointXLatched = ppu.Backgrounds[ii].RefPointX;
                        ppu.Backgrounds[ii].RefPointYLatched = ppu.Backgrounds[ii].RefPointY;
                    }
                }
            }
            else if (ppu.CurrentLine == VBlankLines + Device.HEIGHT - 1)
            {
                ppu.Dispstat.VBlankFlag = false;
            }
            else if (ppu.CurrentLine == VBlankLines + Device.HEIGHT)
            {
                ppu.CurrentLine = 0;
                // Sprites are latched the line before they're displayed, this therefore latches the _next_ lines sprites
                ppu.DrawSpritesOnLine((int)ppu.Dispcnt.BgMode >= 3);
            }

            // Need to check this after cycling currentline around to 0 or we
            // won't catch vcount irqs on line 0. Required for mario kart
            if (ppu.CurrentLine == ppu.Dispstat.VCountSetting)
            {
                ppu.Dispstat.VCounterFlag = true;
                if (ppu.Dispstat.VCounterIrqEnable)
                {
                    device.InterruptInterconnect.RaiseInterrupt(Interrupt.LCDVCounter);
                }
            }

            device.Scheduler.ScheduleEvent(EventType.HBlankStart, &HBlankStartEvent, HBlankFlagCycles);
        }

        internal void WriteRegisterByte(uint address, byte value)
        {
            switch (address)
            {
                case DISPCNT:
                    Dispcnt.UpdateB1(value);
                    break;
                case DISPCNT + 1:
                    Dispcnt.UpdateB2(value);
                    break;
                case GREENSWAP:
                    GreenSwap = (ushort)((GreenSwap & 0xFF00) | value);
                    break;
                case GREENSWAP + 1:
                    GreenSwap = (ushort)((GreenSwap & 0x00FF) | (value << 8));
                    break;
                case DISPSTAT:
                    Dispstat.UpdateB1(value);
                    break;
                case DISPSTAT + 1:
                    Dispstat.VCountSetting = value;
                    break;
                case BG0CNT:
                    Backgrounds[0].Control.UpdateB1(value);
                    break;
                case BG0CNT + 1:
                    Backgrounds[0].Control.UpdateB2(value);
                    break;
                case BG1CNT:
                    Backgrounds[1].Control.UpdateB1(value);
                    break;
                case BG1CNT + 1:
                    Backgrounds[1].Control.UpdateB2(value);
                    break;
                case BG2CNT:
                    Backgrounds[2].Control.UpdateB1(value);
                    break;
                case BG2CNT + 1:
                    Backgrounds[2].Control.UpdateB2(value);
                    break;
                case BG3CNT:
                    Backgrounds[3].Control.UpdateB1(value);
                    break;
                case BG3CNT + 1:
                    Backgrounds[3].Control.UpdateB2(value);
                    break;
                case BG0HOFS:
                    Backgrounds[0].XOffset = (Backgrounds[0].XOffset & 0xFF00) | value;
                    break;
                case BG0HOFS + 1:
                    Backgrounds[0].XOffset = (Backgrounds[0].XOffset & 0x00FF) | ((value & 0b1) << 8);
                    break;
                case BG0VOFS:
                    Backgrounds[0].YOffset = (Backgrounds[0].YOffset & 0xFF00) | value;
                    break;
                case BG0VOFS + 1:
                    Backgrounds[0].YOffset = (Backgrounds[0].YOffset & 0x00FF) | ((value & 0b1) << 8);
                    break;
                case BG1HOFS:
                    Backgrounds[1].XOffset = (Backgrounds[1].XOffset & 0xFF00) | value;
                    break;
                case BG1HOFS + 1:
                    Backgrounds[1].XOffset = (Backgrounds[1].XOffset & 0x00FF) | ((value & 0b1) << 8);
                    break;
                case BG1VOFS:
                    Backgrounds[1].YOffset = (Backgrounds[1].YOffset & 0xFF00) | value;
                    break;
                case BG1VOFS + 1:
                    Backgrounds[1].YOffset = (Backgrounds[1].YOffset & 0x00FF) | ((value & 0b1) << 8);
                    break;
                case BG2HOFS:
                    Backgrounds[2].XOffset = (Backgrounds[2].XOffset & 0xFF00) | value;
                    break;
                case BG2HOFS + 1:
                    Backgrounds[2].XOffset = (Backgrounds[2].XOffset & 0x00FF) | ((value & 0b1) << 8);
                    break;
                case BG2VOFS:
                    Backgrounds[2].YOffset = (Backgrounds[2].YOffset & 0xFF00) | value;
                    break;
                case BG2VOFS + 1:
                    Backgrounds[2].YOffset = (Backgrounds[2].YOffset & 0x00FF) | ((value & 0b1) << 8);
                    break;
                case BG3HOFS:
                    Backgrounds[3].XOffset = (Backgrounds[3].XOffset & 0xFF00) | value;
                    break;
                case BG3HOFS + 1:
                    Backgrounds[3].XOffset = (Backgrounds[3].XOffset & 0x00FF) | ((value & 0b1) << 8);
                    break;
                case BG3VOFS:
                    Backgrounds[3].YOffset = (Backgrounds[3].YOffset & 0xFF00) | value;
                    break;
                case BG3VOFS + 1:
                    Backgrounds[3].YOffset = (Backgrounds[3].YOffset & 0x00FF) | ((value & 0b1) << 8);
                    break;
                case BG2PA:
                    Backgrounds[2].Dx = (short)((Backgrounds[2].Dx & 0xFF00) | value);
                    break;
                case BG2PA + 1:
                    Backgrounds[2].Dx = (short)((Backgrounds[2].Dx & 0x00FF) | (value << 8));
                    break;
                case BG2PB:
                    Backgrounds[2].Dmx = (short)((Backgrounds[2].Dmx & 0xFF00) | value);
                    break;
                case BG2PB + 1:
                    Backgrounds[2].Dmx = (short)((Backgrounds[2].Dmx & 0x00FF) | (value << 8));
                    break;
                case BG2PC:
                    Backgrounds[2].Dy = (short)((Backgrounds[2].Dy & 0xFF00) | value);
                    break;
                case BG2PC + 1:
                    Backgrounds[2].Dy = (short)((Backgrounds[2].Dy & 0x00FF) | (value << 8));
                    break;
                case BG2PD:
                    Backgrounds[2].Dmy = (short)((Backgrounds[2].Dmy & 0xFF00) | value);
                    break;
                case BG2PD + 1:
                    Backgrounds[2].Dmy = (short)((Backgrounds[2].Dmy & 0x00FF) | (value << 8));
                    break;
                case BG2X_L:
                    Backgrounds[2].UpdateReferencePointX(value, 0, 0xFFFF_FF00);
                    break;
                case BG2X_L + 1:
                    Backgrounds[2].UpdateReferencePointX(value, 1, 0xFFFF_00FF);
                    break;
                case BG2X_H:
                    Backgrounds[2].UpdateReferencePointX(value, 2, 0xFF00_FFFF);
                    break;
                case BG2X_H + 1:
                    Backgrounds[2].UpdateReferencePointX(value, 3, 0x00FF_FFFF);
                    break;
                case BG2Y_L:
                    Backgrounds[2].UpdateReferencePointY(value, 0, 0xFFFF_FF00);
                    break;
                case BG2Y_L + 1:
                    Backgrounds[2].UpdateReferencePointY(value, 1, 0xFFFF_00FF);
                    break;
                case BG2Y_H:
                    Backgrounds[2].UpdateReferencePointY(value, 2, 0xFF00_FFFF);
                    break;
                case BG2Y_H + 1:
                    Backgrounds[2].UpdateReferencePointY(value, 3, 0x00FF_FFFF);
                    break;
                case BG3PA:
                    Backgrounds[3].Dx = (short)((Backgrounds[3].Dx & 0xFF00) | value);
                    break;
                case BG3PA + 1:
                    Backgrounds[3].Dx = (short)((Backgrounds[3].Dx & 0x00FF) | (value << 8));
                    break;
                case BG3PB:
                    Backgrounds[3].Dmx = (short)((Backgrounds[3].Dmx & 0xFF00) | value);
                    break;
                case BG3PB + 1:
                    Backgrounds[3].Dmx = (short)((Backgrounds[3].Dmx & 0x00FF) | (value << 8));
                    break;
                case BG3PC:
                    Backgrounds[3].Dy = (short)((Backgrounds[3].Dy & 0xFF00) | value);
                    break;
                case BG3PC + 1:
                    Backgrounds[3].Dy = (short)((Backgrounds[3].Dy & 0x00FF) | (value << 8));
                    break;
                case BG3PD:
                    Backgrounds[3].Dmy = (short)((Backgrounds[3].Dmy & 0xFF00) | value);
                    break;
                case BG3PD + 1:
                    Backgrounds[3].Dmy = (short)((Backgrounds[3].Dmy & 0x00FF) | (value << 8));
                    break;
                case BG3X_L:
                    Backgrounds[3].UpdateReferencePointX(value, 0, 0xFFFF_FF00);
                    break;
                case BG3X_L + 1:
                    Backgrounds[3].UpdateReferencePointX(value, 1, 0xFFFF_00FF);
                    break;
                case BG3X_H:
                    Backgrounds[3].UpdateReferencePointX(value, 2, 0xFF00_FFFF);
                    break;
                case BG3X_H + 1:
                    Backgrounds[3].UpdateReferencePointX(value, 3, 0x00FF_FFFF);
                    break;
                case BG3Y_L:
                    Backgrounds[3].UpdateReferencePointY(value, 0, 0xFFFF_FF00);
                    break;
                case BG3Y_L + 1:
                    Backgrounds[3].UpdateReferencePointY(value, 1, 0xFFFF_00FF);
                    break;
                case BG3Y_H:
                    Backgrounds[3].UpdateReferencePointY(value, 2, 0xFF00_FFFF);
                    break;
                case BG3Y_H + 1:
                    Backgrounds[3].UpdateReferencePointY(value, 3, 0x00FF_FFFF);
                    break;
                case WIN0H:
                    _windows.SetXB1(0, value);
                    break;
                case WIN0H + 1:
                    _windows.SetXB2(0, value);
                    break;
                case WIN1H:
                    _windows.SetXB1(1, value);
                    break;
                case WIN1H + 1:
                    _windows.SetXB2(1, value);
                    break;
                case WIN0V:
                    _windows.SetYB1(0, value);
                    break;
                case WIN0V + 1:
                    _windows.SetYB2(0, value);
                    break;
                case WIN1V:
                    _windows.SetYB1(1, value);
                    break;
                case WIN1V + 1:
                    _windows.SetYB2(1, value);
                    break;
                case WININ:
                    _windows.UpdateWinIn(0, value);
                    break;
                case WININ + 1:
                    _windows.UpdateWinIn(1, value);
                    break;
                case WINOUT:
                    _windows.UpdateWinOutB1(value);
                    break;
                case WINOUT + 1:
                    _windows.UpdateWinOutB2(value);
                    break;
                case MOSAIC:
                    Mosaic.UpdateB1(value);
                    break;
                case MOSAIC + 1:
                    Mosaic.UpdateB2(value);
                    break;
                case BLDCNT:
                    ColorEffects.UpdateBldCntB1(value);
                    break;
                case BLDCNT + 1:
                    ColorEffects.UpdateBldCntB2(value);
                    break;
                case BLDALPHA:
                    ColorEffects.UpdateBldAlphaB1(value);
                    break;
                case BLDALPHA + 1:
                    ColorEffects.UpdateBldAlphaB2(value);
                    break;
                case BLDY:
                    ColorEffects.UpdateBldy(value);
                    break;
                default:
                    return;
            }
        }

        internal void WriteRegisterHalfWord(uint address, ushort value)
        {
            WriteRegisterByte(address, (byte)value);
            WriteRegisterByte(address + 1, (byte)(value >> 8));
        }

        internal byte ReadRegisterByte(uint address, uint openbus) =>
            (byte)(ReadRegisterHalfWord(address & 0xFFFF_FFFE, openbus) >> (int)(8 * (address & 1)));

        internal ushort ReadRegisterHalfWord(uint address, uint openbus) => address switch
        {
            DISPCNT => Dispcnt.Read(),
            GREENSWAP => GreenSwap,
            DISPSTAT => Dispstat.Read(),
            VCOUNT => CurrentLine,
            BG0CNT => (ushort)(Backgrounds[0].Control.Read() & 0xDFFF),
            BG1CNT => (ushort)(Backgrounds[1].Control.Read() & 0xDFFF),
            BG2CNT => Backgrounds[2].Control.Read(),
            BG3CNT => Backgrounds[3].Control.Read(),
            WININ => _windows.GetWinIn(),
            WINOUT => _windows.GetWinOut(),
            BLDCNT => ColorEffects.BldCnt(),
            BLDALPHA => ColorEffects.BldAlpha(),
            _ => (ushort)openbus,
        };

        #region Memory Read Write

        internal byte ReadByte(uint address) => address switch
        {
            // TODO - Cycle timing needs to include extra cycle if ppu is accessing relevant memory area on this cycle
            >= 0x0500_0000 and <= 0x05FF_FFFF => ReadPaletteByte(address),
            >= 0x0600_0000 and <= 0x06FF_FFFF => Vram[MaskVRamAddress(address)],
            >= 0x0700_0000 and <= 0x07FF_FFFF => ReadOamByte(address),
            _ => throw new ArgumentOutOfRangeException(nameof(address), $"Address {address:X8} is unused")
        };

        internal ushort ReadHalfWord(uint address) => address switch
        {
            // TODO - Cycle timing needs to include extra cycle if ppu is accessing relevant memory area on this cycle
            >= 0x0500_0000 and <= 0x05FF_FFFF => ReadPaletteHalfWord(address),
            >= 0x0600_0000 and <= 0x06FF_FFFF => Utils.ReadHalfWord(Vram, MaskVRamAddress(address), 0xF_FFFF),
            >= 0x0700_0000 and <= 0x07FF_FFFF => ReadOamHalfWord(address),
            _ => throw new ArgumentOutOfRangeException(nameof(address), $"Address {address:X8} is unused")
        };

        /// <summary>
        /// The PPU has a 16 bit bus and any byte wide writes to it result in half 
        /// word writes of the byte value to both bytes in the half word or the 
        /// write being ignored (depending on where exactly the write occurs)
        /// </summary>
        internal void WriteByte(uint address, byte value)
        {
            switch (address)
            {
                case uint _ when address is >= 0x0500_0000 and <= 0x05FF_FFFF:
                    {
                        // Since internally palette memory is stored in 16 bit sections
                        // writing a byte actually writes that byte to both bytes of the
                        // half word aligned area in memory.
                        WritePaletteHalfWord(address & 0xFFFF_FFFE, (ushort)(value * 0x0101));
                        break;
                    }
                case uint _ when address is >= 0x0600_0000 and <= 0x06FF_FFFF:
                    {
                        var maskedAddress = MaskVRamAddress(address & 0xFFFF_FFFE);
                        var objStartAddress = (int)Dispcnt.BgMode >= 3 ? 0x1_4000 : 0x1_0000;

                        // 8 bit writes to OBJ are ignored
                        if (maskedAddress < objStartAddress)
                        {
                            Utils.WriteHalfWord(Vram, 0xF_FFFF, maskedAddress, (ushort)(value * 0x0101));
                        }
                        break;
                    }
                case uint _ when address is >= 0x0700_0000 and <= 0x07FF_FFFF:
                    // 8 bit writes to OAM are ignored
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(address), $"Address {address:X8} is unused");
            }
        }

        internal void WriteHalfWord(uint address, ushort value)
        {
            // TODO - "VRAM and Palette RAM may be accessed during H-Blanking. OAM can accessed only if "H-Blank Interval Free" bit in DISPCNT register is set."
            switch (address)
            {
                case uint _ when address is >= 0x0500_0000 and <= 0x05FF_FFFF:
                    WritePaletteHalfWord(address, value);
                    break;
                case uint _ when address is >= 0x0600_0000 and <= 0x06FF_FFFF:
                    Utils.WriteHalfWord(Vram, 0xF_FFFF, MaskVRamAddress(address), value);
                    break;
                case uint _ when address is >= 0x0700_0000 and <= 0x07FF_FFFF:
                    WriteOamHalfWord(address, value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(address), $"Address {address:X8} is unused"); // TODO - Handle unused addresses properly
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint MaskVRamAddress(uint address)
        {
            address &= 0x1_FFFF;
            if (address >= 0x18000)
            {
                address = (uint)(address & ~0x8000);
            }
            return address;
        }
        #endregion
    }
}