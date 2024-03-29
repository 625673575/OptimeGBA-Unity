﻿using System;

namespace GameboyAdvanced.Core.Bus
{
    public enum PhiOutput
    {
        Disabled = 0,
        Phi4_19MHz = 1,
        Phi8_38MHz = 2,
        Phi16_78MHz = 3,
    }

    /// <summary>
    /// WAITCNT is a special register which controls access timings to various
    /// regions of the gamepak.
    /// 
    /// - Wait State 0 = 0x0800_0000 (normal)
    /// - Wait State 1 = 0x0A00_0000
    /// - Wait State 2 = 0x0C00_0000
    /// </summary>
    public class WaitControl
    {
        public int SRAMWaitStates;
        public int SRAMWaitControl;
        public int[][] WaitStates = new int[3][]
        {
        new int[2], new int[2], new int[2],
        };
        public PhiOutput PhiTerminalOutput;
        public bool EnableGamepakPrefetch;
        public bool GamepakIsCGB;

        internal WaitControl()
        {
            Reset();
        }

        /// <summary>
        /// WAITCNT is set to 0x0000 on reset
        /// </summary>
        internal void Reset()
        {
            Set(0);
        }

        internal void Set(ushort value)
        {
            SetByte1((byte)value);
            SetByte2((byte)(value >> 8));
        }

        internal void SetByte1(byte value)
        {
            SRAMWaitControl = value & 0b11;
            SRAMWaitStates = SRAMWaitControl switch
            {
                0 => 4,
                1 => 3,
                2 => 2,
                3 => 8,
                _ => throw new Exception("Invalid SRAM wait control value")
            };
            WaitStates[0][0] = WaitStatesNFromBitVal((value >> 2) & 0b11);
            WaitStates[0][1] = ((value >> 4) & 0b1) == 0 ? 2 : 1;
            WaitStates[1][0] = WaitStatesNFromBitVal((value >> 5) & 0b11);
            WaitStates[1][1] = ((value >> 7) & 0b1) == 0 ? 4 : 1;
        }

        internal void SetByte2(byte value)
        {
            WaitStates[2][0] = WaitStatesNFromBitVal(value & 0b11);
            WaitStates[2][1] = ((value >> 2) & 0b1) == 0 ? 8 : 1;
            PhiTerminalOutput = (PhiOutput)((value >> 3) & 0b11);
            EnableGamepakPrefetch = ((value >> 6) & 0b1) == 0b1;
            GamepakIsCGB = ((value >> 7) & 0b1) == 0b1;
        }

        internal ushort Get() => (ushort)(SRAMWaitControl |
                (BitValFromWaitStateN(WaitStates[0][0]) << 2) |
                (WaitStates[0][1] == 2 ? 0 : (1 << 4)) |
                (BitValFromWaitStateN(WaitStates[1][0]) << 5) |
                (WaitStates[1][1] == 4 ? 0 : (1 << 7)) |
                (BitValFromWaitStateN(WaitStates[2][0]) << 8) |
                (WaitStates[2][1] == 8 ? 0 : (1 << 10)) |
                ((ushort)PhiTerminalOutput << 11) |
                (EnableGamepakPrefetch ? (1 << 14) : 0) |
                (GamepakIsCGB ? (1 << 15) : 0));

        private static int WaitStatesNFromBitVal(int bitVal) => bitVal switch
        {
            0 => 4,
            1 => 3,
            2 => 2,
            3 => 8,
            _ => throw new Exception("Invalid waitcnt value"),
        };

        private static ushort BitValFromWaitStateN(int waitStateN) => waitStateN switch
        {
            4 => 0,
            3 => 1,
            2 => 2,
            8 => 3,
            _ => throw new Exception("Invalid waitcnt")
        };
    }
}