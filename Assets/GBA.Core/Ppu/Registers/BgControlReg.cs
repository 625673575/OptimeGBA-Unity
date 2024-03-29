﻿using System;

namespace GameboyAdvanced.Core.Ppu.Registers
{
    public enum BgSize
    {
        Regular32x32 = 0b00,
        Regular64x32 = 0b01,
        Regular32x64 = 0b10,
        Regular64x64 = 0b11,
    }

    internal static class BgSizeExtensions
    {
        internal static int Width(this BgSize size) => size switch
        {
            BgSize.Regular32x32 => 256,
            BgSize.Regular32x64 => 256,
            BgSize.Regular64x32 => 512,
            BgSize.Regular64x64 => 512,
            _ => throw new Exception("Invalid BG size")
        };

        internal static int Height(this BgSize size) => size switch
        {
            BgSize.Regular32x32 => 256,
            BgSize.Regular32x64 => 512,
            BgSize.Regular64x32 => 256,
            BgSize.Regular64x64 => 512,
            _ => throw new Exception("Invalid BG size")
        };
    }

    public struct BgControlReg
    {
        /// <summary>
        /// Priority of BG against sprites and other BGs. highest priority is 
        /// _drawn_ first so 0 will appear on top of all except sprites with 
        /// priority 0.
        /// </summary>
        public int BgPriority;

        /// <summary>
        /// Where are the tiles for this BG stored? CharBaseBlock * 16KB
        /// </summary>
        public int CharBaseBlock;

        /// <summary>
        /// Is mosaic enabled for this background (depending on value of MOSAIC 
        /// register)
        /// </summary>
        public bool IsMosaic;

        /// <summary>
        /// Are tiles using 4bpp (false) or 8bpp (true)
        /// </summary>
        public bool LargePalette;

        /// <summary>
        /// Where is the tile map for this BG stored? ScreenBaseBlock * 2KB
        /// </summary>
        public int ScreenBaseBlock;

        /// <summary>
        /// Only valid on affine backgrounds, after affine transform do pixels 
        /// wrap around or become transparent?
        /// </summary>
        public bool DisplayAreaOverflow;

        /// <summary>
        /// How many screen blocks (32*32) areas are in the tilemap
        /// </summary>
        public BgSize ScreenSize;

        internal ushort Read() => (ushort)
            (BgPriority |
             (CharBaseBlock << 2) |
             (0b11 << 4) | // Docs say 0 but tests say 1 for these bits
             (IsMosaic ? 1 << 6 : 0) |
             (LargePalette ? 1 << 7 : 0) |
             (ScreenBaseBlock << 8) |
             (DisplayAreaOverflow ? 1 << 13 : 0) |
             ((ushort)ScreenSize << 14));

        internal void Reset()
        {
            Update(0);
        }

        internal void Update(ushort value)
        {
            UpdateB1((byte)value);
            UpdateB2((byte)value);
        }

        internal void UpdateB1(byte value)
        {
            BgPriority = value & 0b11;
            CharBaseBlock = (value >> 2) & 0b11;
            IsMosaic = ((value >> 6) & 0b1) == 0b1;
            LargePalette = ((value >> 7) & 0b1) == 0b1;
        }

        internal void UpdateB2(byte value)
        {
            ScreenBaseBlock = value & 0b1_1111;
            DisplayAreaOverflow = ((value >> 5) & 0b1) == 0b1;
            ScreenSize = (BgSize)((value >> 6) & 0b11);
        }
    }
}