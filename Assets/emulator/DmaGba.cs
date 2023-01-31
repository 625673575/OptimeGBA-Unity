using static OptimeGBA.Bits;
using System;

namespace OptimeGBA
{
    public enum DmaStartTimingGba
    {
        Immediately = 0,
        VBlank = 1,
        HBlank = 2,
        Special = 3,
    }

    public sealed class DmaChannelGba
    {
        public uint DMASAD;
        public uint DMADAD;
        public uint DMACNT_L;

        public uint DmaSource;
        public uint DmaDest;
        public uint DmaLength;

        // DMACNT_H
        public DmaDestAddrCtrl DestAddrCtrl;
        public DmaSrcAddrCtrl SrcAddrCtrl;
        public bool Repeat;
        public bool TransferType;
        public bool GamePakDRQ;
        public DmaStartTimingGba StartTiming;
        public bool FinishedIRQ;
        public bool Enabled; // Don't directly set to false, use Disable()

        public uint DMACNT_H;

        public byte ReadHwio8(uint addr)
        {
            // DMASAD, DMADAD, and DMACNT_L are write-only
            byte val = 0;
            switch (addr)
            {
                case 0x0A: // DMACNT_H B0
                case 0x0B: // DMACNT_H B1
                    val = GetByteIn(GetControl(), addr & 1);
                    break;
            }
            return val;
        }

        public void WriteHwio8(uint addr, byte val)
        {
            switch (addr)
            {
                case 0x00: // DMASAD B0
                case 0x01: // DMASAD B1
                case 0x02: // DMASAD B2
                case 0x03: // DMASAD B3
                    DMASAD = SetByteIn(DMASAD, val, addr & 3);
                    break;

                case 0x04: // DMADAD B0
                case 0x05: // DMADAD B1
                case 0x06: // DMADAD B2
                case 0x07: // DMADAD B3
                    DMADAD = SetByteIn(DMADAD, val, addr & 3);
                    break;

                case 0x08: // DMACNT_L B0
                case 0x09: // DMACNT_L B1
                    DMACNT_L = SetByteIn(DMACNT_L, val, addr & 1);
                    break;
                case 0x0A: // DMACNT_H B0
                case 0x0B: // DMACNT_H B1
                    DMACNT_H = SetByteIn(DMACNT_H, val, addr & 1);
                    UpdateControl();
                    break;
            }
        }

        public void UpdateControl()
        {
            DestAddrCtrl = (DmaDestAddrCtrl)BitRange(DMACNT_H, 5, 6);
            SrcAddrCtrl = (DmaSrcAddrCtrl)BitRange(DMACNT_H, 7, 8);
            Repeat = BitTest(DMACNT_H, 9);
            TransferType = BitTest(DMACNT_H, 10);
            GamePakDRQ = BitTest(DMACNT_H, 11);
            StartTiming = (DmaStartTimingGba)BitRange(DMACNT_H, 12, 13);
            FinishedIRQ = BitTest(DMACNT_H, 14);
            if (BitTest(DMACNT_H, 15))
            {
                Enable();
            }
            else
            {
                Disable();
            }
        }

        public uint GetControl()
        {
            uint val = 0;
            val |= ((uint)DestAddrCtrl & 0b11) << 5;
            val |= ((uint)SrcAddrCtrl & 0b11) << 7;
            if (Repeat) val = BitSet(val, 9);
            if (TransferType) val = BitSet(val, 10);
            if (GamePakDRQ) val = BitSet(val, 11);
            val |= ((uint)StartTiming & 0b11) << 12;
            if (FinishedIRQ) val = BitSet(val, 14);
            if (Enabled) val = BitSet(val, 15);

            DMACNT_H = val;

            return val;
        }

        public void Enable()
        {
            if (!Enabled)
            {
                DmaSource = DMASAD;
                DmaDest = DMADAD;
                DmaLength = DMACNT_L;
            }

            Enabled = true;
            GetControl();
        }

        public void Disable()
        {
            Enabled = false;
            GetControl();
        }
    }

    public unsafe sealed class DmaGba
    {
        Gba Gba;

        public DmaChannelGba[] Ch = new DmaChannelGba[4] {
            new DmaChannelGba(),
            new DmaChannelGba(),
            new DmaChannelGba(),
            new DmaChannelGba(),
        };

        static readonly uint[] DmaSourceMask = { 0x07FFFFFF, 0x0FFFFFFF, 0x0FFFFFFF, 0x0FFFFFFF };
        static readonly uint[] DmaDestMask = { 0x07FFFFFF, 0x07FFFFFF, 0x07FFFFFF, 0x0FFFFFFFF };

        public bool DmaLock;

        public DmaGba(Gba gba)
        {
            Gba = gba;
        }

        public byte ReadHwio8(uint addr)
        {
            if (addr >= 0x40000B0 && addr <= 0x40000BB)
            {
                return Ch[0].ReadHwio8(addr - 0x40000B0);
            }
            else if (addr >= 0x40000BC && addr <= 0x40000C7)
            {
                return Ch[1].ReadHwio8(addr - 0x40000BC);
            }
            else if (addr >= 0x40000C8 && addr <= 0x40000D3)
            {
                return Ch[2].ReadHwio8(addr - 0x40000C8);
            }
            else if (addr >= 0x40000D4 && addr <= 0x40000DF)
            {
                return Ch[3].ReadHwio8(addr - 0x40000D4);
            }
            throw new Exception("This shouldn't happen.");
        }

        public void WriteHwio8(uint addr, byte val)
        {
            if (addr >= 0x40000B0 && addr <= 0x40000BB)
            {
                bool oldEnabled = Ch[0].Enabled;  
                Ch[0].WriteHwio8(addr - 0x40000B0, val);
                if (!oldEnabled && Ch[0].Enabled) ExecuteImmediate(0);
                return;
            }
            else if (addr >= 0x40000BC && addr <= 0x40000C7)
            {
                bool oldEnabled = Ch[1].Enabled;  
                Ch[1].WriteHwio8(addr - 0x40000BC, val);
                if (!oldEnabled && Ch[1].Enabled) ExecuteImmediate(1);
                return;
            }
            else if (addr >= 0x40000C8 && addr <= 0x40000D3)
            {
                bool oldEnabled = Ch[2].Enabled;  
                Ch[2].WriteHwio8(addr - 0x40000C8, val);
                if (!oldEnabled && Ch[2].Enabled) ExecuteImmediate(2);
                return;
            }
            else if (addr >= 0x40000D4 && addr <= 0x40000DF)
            {
                bool oldEnabled = Ch[3].Enabled;  
                Ch[3].WriteHwio8(addr - 0x40000D4, val);
                if (!oldEnabled && Ch[3].Enabled) ExecuteImmediate(3);
                return;
            }
            throw new Exception("This shouldn't happen.");
        }

        public void ExecuteDma(DmaChannelGba c, uint ci)
        {
            DmaLock = true;

            // Least significant 28 (or 27????) bits
            c.DmaSource &= DmaSourceMask[ci];
            c.DmaDest &= DmaDestMask[ci];

            if (ci == 3)
            {
                // DMA 3 is 16-bit length
                c.DmaLength &= 0b1111111111111111;
                // Value of zero is treated as maximum length
                if (c.DmaLength == 0) c.DmaLength = 0x10000;
            }
            else
            {
                // DMA 0-2 are 14-bit length
                c.DmaLength &= 0b11111111111111;
                // Value of zero is treated as maximum length
                if (c.DmaLength == 0) c.DmaLength = 0x4000;
            }

            // Debug.Log($"Starting DMA {ci}");
            // Debug.Log($"SRC: {Util.HexN(srcAddr, 7)}");
            // Debug.Log($"DEST: {Util.HexN(destAddr, 7)}");
            // Debug.Log($"LENGTH: {Util.HexN(c.DmaLength, 4)}");

            int destOffsPerUnit;
            int sourceOffsPerUnit;
            if (c.TransferType)
            {
                switch (c.DestAddrCtrl)
                {
                    case DmaDestAddrCtrl.Increment: destOffsPerUnit = +4; break;
                    case DmaDestAddrCtrl.Decrement: destOffsPerUnit = -4; break;
                    case DmaDestAddrCtrl.IncrementReload: destOffsPerUnit = +4; break;
                    default: destOffsPerUnit = 0; break;
                }
                switch (c.SrcAddrCtrl)
                {
                    case DmaSrcAddrCtrl.Increment: sourceOffsPerUnit = +4; break;
                    case DmaSrcAddrCtrl.Decrement: sourceOffsPerUnit = -4; break;
                    default: sourceOffsPerUnit = 0; break;
                }
            }
            else
            {
                switch (c.DestAddrCtrl)
                {
                    case DmaDestAddrCtrl.Increment: destOffsPerUnit = +2; break;
                    case DmaDestAddrCtrl.Decrement: destOffsPerUnit = -2; break;
                    case DmaDestAddrCtrl.IncrementReload: destOffsPerUnit = +2; break;
                    default: destOffsPerUnit = 0; break;
                }
                switch (c.SrcAddrCtrl)
                {
                    case DmaSrcAddrCtrl.Increment: sourceOffsPerUnit = +2; break;
                    case DmaSrcAddrCtrl.Decrement: sourceOffsPerUnit = -2; break;
                    default: sourceOffsPerUnit = 0; break;
                }
            }

            uint origLength = c.DmaLength;


            if (c.TransferType)
            {
                for (; c.DmaLength > 0; c.DmaLength--)
                {
                    Gba.Mem.Write32(c.DmaDest & ~3u, Gba.Mem.Read32(c.DmaSource & ~3u));
                    Gba.Tick(Gba.Cpu.Timing32[(c.DmaSource >> 24) & 0xF]);
                    Gba.Tick(Gba.Cpu.Timing32[(c.DmaDest >> 24) & 0xF]);

                    c.DmaDest = (uint)(long)(destOffsPerUnit + c.DmaDest);
                    c.DmaSource = (uint)(long)(sourceOffsPerUnit + c.DmaSource);
                }
            }
            else
            {
                for (; c.DmaLength > 0; c.DmaLength--)
                {
                    Gba.Mem.Write16(c.DmaDest & ~1u, Gba.Mem.Read16(c.DmaSource & ~1u));
                    Gba.Tick(Gba.Cpu.Timing8And16[(c.DmaSource >> 24) & 0xF]);
                    Gba.Tick(Gba.Cpu.Timing8And16[(c.DmaDest >> 24) & 0xF]);

                    c.DmaDest = (uint)(long)(destOffsPerUnit + c.DmaDest);
                    c.DmaSource = (uint)(long)(sourceOffsPerUnit + c.DmaSource);
                }
            }

            if (c.DestAddrCtrl == DmaDestAddrCtrl.IncrementReload)
            {
                c.DmaLength = origLength;

                if (c.Repeat)
                {
                    c.DmaDest = c.DMADAD;
                }
            }

            if (c.FinishedIRQ)
            {
                Gba.HwControl.FlagInterrupt((uint)InterruptGba.Dma0 + ci);
            }

            DmaLock = false;
        }

        public void ExecuteSoundDma(DmaChannelGba c, uint ci)
        {
            DmaLock = true;

            // Least significant 28 (or 27????) bits
            uint srcAddr = c.DmaSource & 0b1111111111111111111111111111;
            uint destAddr = c.DmaDest & 0b111111111111111111111111111;

            // 4 units of 32bits (16 bytes) are transferred to FIFO_A or FIFO_B
            for (uint i = 0; i < 4; i++)
            {
                uint val = Gba.Mem.Read32(srcAddr + 0);
                if (destAddr == 0x40000A0)
                {
                    Gba.GbaAudio.A.Insert((byte)val);
                    Gba.GbaAudio.A.Insert((byte)(val >>= 8));
                    Gba.GbaAudio.A.Insert((byte)(val >>= 8));
                    Gba.GbaAudio.A.Insert((byte)(val >>= 8));
                }
                else if (destAddr == 0x40000A4)
                {
                    Gba.GbaAudio.B.Insert((byte)val);
                    Gba.GbaAudio.B.Insert((byte)(val >>= 8));
                    Gba.GbaAudio.B.Insert((byte)(val >>= 8));
                    Gba.GbaAudio.B.Insert((byte)(val >>= 8));
                }
                else
                {
                    Gba.Mem.Write8(destAddr + 0, (byte)val); 
                    Gba.Mem.Write8(destAddr + 1, (byte)(val >>= 8)); 
                    Gba.Mem.Write8(destAddr + 2, (byte)(val >>= 8)); 
                    Gba.Mem.Write8(destAddr + 3, (byte)(val >>= 8));
                }

                switch (c.SrcAddrCtrl)
                {
                    case DmaSrcAddrCtrl.Increment: srcAddr += 4; break;
                    case DmaSrcAddrCtrl.Decrement: srcAddr -= 4; break;
                    case DmaSrcAddrCtrl.Fixed: break;
                }

                // Applying proper timing to sound DMAs causes crackling in certain games including PMD.
                // This only happens with scheduled timers, which leads me to believe the real problem is in there.
                // PROBLEM SOLVED.... my timers were 1 cycle too slow to reload
                Gba.Cpu.InstructionCycles += (Gba.Cpu.Timing32[(c.DmaSource >> 24) & 0xF]);
                Gba.Cpu.InstructionCycles += (Gba.Cpu.Timing32[(c.DmaDest >> 24) & 0xF]);
            }

            c.DmaSource = srcAddr;

            if (c.FinishedIRQ)
            {
                Gba.HwControl.FlagInterrupt((uint)InterruptGba.Dma0 + ci);
            }

            DmaLock = false;
        }


        public void ExecuteImmediate(uint ci)
        {
            DmaChannelGba c = Ch[ci];

            if (c.Enabled && c.StartTiming == DmaStartTimingGba.Immediately)
            {
                c.Disable();

                ExecuteDma(c, ci);
            }
        }

        public void RepeatFifoA()
        {
            if (!DmaLock)
            {
                if (Ch[1].StartTiming == DmaStartTimingGba.Special)
                {
                    ExecuteSoundDma(Ch[1], 1);
                }
            }
        }
        public void RepeatFifoB()
        {
            if (!DmaLock)
            {
                if (Ch[2].StartTiming == DmaStartTimingGba.Special)
                {
                    ExecuteSoundDma(Ch[2], 2);
                }
            }
        }

        public void RepeatHblank()
        {
            if (!DmaLock)
            {
                for (uint ci = 0; ci < 4; ci++)
                {
                    DmaChannelGba c = Ch[ci];
                    if (c.StartTiming == DmaStartTimingGba.HBlank)
                    {
                        c.DmaLength = c.DMACNT_L;
                        ExecuteDma(c, ci);
                    }
                }
            }
        }

        public void RepeatVblank()
        {
            if (!DmaLock)
            {
                for (uint ci = 0; ci < 4; ci++)
                {
                    DmaChannelGba c = Ch[ci];
                    if (c.StartTiming == DmaStartTimingGba.VBlank)
                    {
                        c.DmaLength = c.DMACNT_L;
                        ExecuteDma(c, ci);
                    }
                }
            }
        }
    }
}