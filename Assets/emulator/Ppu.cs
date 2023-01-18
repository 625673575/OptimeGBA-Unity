using static OptimeGBA.Bits;
using System.Runtime.InteropServices;

namespace OptimeGBA
{
    public enum BackgroundMode
    {
        Char,
        Display3D,
        Affine,
        Extended,
        Large,

        // Extended
        Affine16BitBgMapEntries,
        Affine256ColorBitmap,
        AffineFullColorBitmap,
    }
    public sealed class Background
    {
        bool Nds;

        public Background(bool nds, byte id)
        {
            Nds = nds;
            Id = id;
        }

        byte[] BGCNTValue = new byte[2];

        // BGCNT
        public byte Priority = 0;
        public uint CharBaseBlock = 0;
        public bool EnableMosaic = false;
        public bool Use8BitColor = false;
        public uint MapBaseBlock = 0;
        public bool OverflowWrap = false;
        public uint ScreenSize = 0;

        // BGCNT NDS
        public bool AffineBitmap;
        public bool AffineBitmapFullColor;

        // BGH/VOFS
        public uint HorizontalOffset;
        public uint VerticalOffset;

        public byte Id;

        public uint RefPointX;
        public uint RefPointY;

        public short AffineA;
        public short AffineB;
        public short AffineC;
        public short AffineD;

        public int AffinePosX;
        public int AffinePosY;

        // Set by PrepareBackgroundAndWindow() and used by RenderBgModes()
        public BackgroundMode Mode;

        public byte ReadBGCNT(uint addr)
        {
            switch (addr)
            {
                case 0x00: // BGCNT B0
                    return BGCNTValue[0];
                case 0x01: // BGCNT B1
                    return BGCNTValue[1];
            }
            return 0;
        }

        public void WriteBGCNT(uint addr, byte val)
        {
            switch (addr)
            {
                case 0x00: // BGCNT B0
                    Priority = (byte)((val >> 0) & 0b11);

                    // These bits overlay other bits on NDS
                    AffineBitmap = BitTest(val, 7);
                    AffineBitmapFullColor = BitTest(val, 2);

                    EnableMosaic = BitTest(val, 6);
                    if (!Nds)
                    {
                        CharBaseBlock = (uint)(val >> 2) & 0b11;
                    }
                    else
                    {
                        CharBaseBlock = (uint)(val >> 2) & 0b1111;
                    }
                    EnableMosaic = BitTest(val, 6);
                    Use8BitColor = BitTest(val, 7);

                    BGCNTValue[0] = val;
                    break;
                case 0x01: // BGCNT B1
                    MapBaseBlock = (uint)(val >> 0) & 0b11111;
                    OverflowWrap = BitTest(val, 5);
                    ScreenSize = (uint)(val >> 6) & 0b11;

                    BGCNTValue[1] = val;
                    break;
            }
        }

        public void WriteBGOFS(uint addr, byte val)
        {
            switch (addr)
            {
                case 0x0: // BGHOFS B0
                    HorizontalOffset &= ~0x0FFu;
                    HorizontalOffset |= (uint)((val << 0) & 0x0FFu);
                    break;
                case 0x1: // BGHOFS B1
                    HorizontalOffset &= ~0x100u;
                    HorizontalOffset |= (uint)((val << 8) & 0x100u);
                    break;

                case 0x2: // BGVOFS B0
                    VerticalOffset &= ~0x0FFu;
                    VerticalOffset |= (uint)((val << 0) & 0x0FFu);
                    break;
                case 0x3: // BGVOFS B1
                    VerticalOffset &= ~0x100u;
                    VerticalOffset |= (uint)((val << 8) & 0x100u);
                    break;
            }
        }

        public void WriteBGXY(uint addr, byte val)
        {
            byte offset = (byte)((addr & 3) * 8);
            switch (addr)
            {
                case 0x0: // BGX_L
                case 0x1: // BGX_L
                case 0x2: // BGX_H
                case 0x3: // BGX_H
                    RefPointX &= ~(0xFFu << offset);
                    RefPointX |= (uint)(val << offset);
                    break;

                case 0x4: // BGY_L
                case 0x5: // BGY_L
                case 0x6: // BGY_H
                case 0x7: // BGY_H
                    RefPointY &= ~(0xFFu << offset);
                    RefPointY |= (uint)(val << offset);
                    break;
            }

            CopyAffineParams();
        }

        public void CopyAffineParams()
        {
            // also sign extend
            AffinePosX = ((int)RefPointX << 4) >> 4;
            AffinePosY = ((int)RefPointY << 4) >> 4;
        }

        public void WriteBGPX(uint addr, byte val)
        {
            byte offset = (byte)((addr & 1) * 8);
            switch (addr)
            {
                case 0x0: // BGPA B0
                case 0x1: // BGPA B1
                    AffineA &= (short)~(0xFFu << offset);
                    AffineA |= (short)(val << offset);
                    break;
                case 0x2: // BGPB B0
                case 0x3: // BGPB B1
                    AffineB &= (short)~(0xFFu << offset);
                    AffineB |= (short)(val << offset);
                    break;

                case 0x4: // BGPC B0
                case 0x5: // BGPC B1
                    AffineC &= (short)~(0xFFu << offset);
                    AffineC |= (short)(val << offset);
                    break;
                case 0x6: // BGPD B0
                case 0x7: // BGPD B1
                    AffineD &= (short)~(0xFFu << offset);
                    AffineD |= (short)(val << offset);
                    break;
            }
        }

        // Metadata used for rendering
        public ushort GetMeta()
        {
            return (ushort)((Priority << 8) | (1 << Id));
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct ObjPixel
    {
        public ushort Color;
        public byte PaletteIndex;
        public byte Priority;
        public ObjMode Mode;

        public ObjPixel(ushort color, byte paletteIndex, byte priority, ObjMode transparent)
        {
            Color = color;
            PaletteIndex = paletteIndex;
            Priority = priority;
            Mode = transparent;
        }
    }

    public enum ObjShape
    {
        Square = 0,
        Horizontal = 1,
        Vertical = 2,
    }

    public enum ObjMode : byte
    {
        Normal = 0,
        Translucent = 1,
        ObjWindow = 2,
    }

    public enum BlendEffect
    {
        None = 0,
        Blend = 1,
        Lighten = 2,
        Darken = 3,
    }

    public enum BlendFlag : byte
    {
        Bg0 = 1 << 0,
        Bg1 = 1 << 1,
        Bg2 = 1 << 2,
        Bg3 = 1 << 3,
        Obj = 1 << 4,
        Backdrop = 1 << 5,
    }

    public enum WindowFlag : byte
    {
        Bg0 = 1 << 0,
        Bg1 = 1 << 1,
        Bg2 = 1 << 2,
        Bg3 = 1 << 3,
        Obj = 1 << 4,
        ColorMath = 1 << 5,
    }
}