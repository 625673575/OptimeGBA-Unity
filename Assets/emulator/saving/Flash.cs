using System;
using static Util;
namespace OptimeGBA
{
    public enum FlashState
    {
        InitialState,
        PreCommand0,
        PreCommand1,

        FullErase,
        EraseSector,
        PrepareWriteByte,
        SetBank,
    }

    public enum FlashStateSecondary
    {
        Ready,
        PrepareEraseCommand
    }

    public enum FlashSize
    {
        Flash512k,
        Flash1m
    }

    public unsafe sealed class Flash : SaveProvider
    {
        Gba Gba;

        FlashState State = FlashState.InitialState;
        FlashStateSecondary StateSecondary = FlashStateSecondary.Ready;

        FlashSize Size;

        bool IdentificationMode = false;
        bool Bank1 = false;
        bool PrepareSetBank = false;
        bool PrepareWrite = false;

        byte[] Memory;

        public Flash(Gba gba, FlashSize size)
        {
            Gba = gba;
            Size = size;

            switch (size)
            {
                case FlashSize.Flash1m:
                    Memory = new byte[131072];
                    break;
                case FlashSize.Flash512k:
                    Memory = new byte[65536];
                    break;
            }
        }

        public override byte Read8(uint addr)
        {
            byte val = 0;

            addr -= 0xE000000;
            if (Bank1) addr += 0x10000;
            if (addr < Memory.Length)
            {
                val = Memory[addr];
            }

            if (IdentificationMode)
            {
                // Return correct IDs in identification mode
                if (Size == FlashSize.Flash1m)
                {
                    switch (addr)
                    {
                        case 0x0: return 0x62;
                        case 0x1: return 0x13;
                    }
                }
                else
                {
                    switch (addr)
                    {
                        case 0x0: return 0x32;
                        case 0x1: return 0x1B;
                    }
                }
            }

            // Debug.Log("Flash.Read8 addr:" + HexN(addr, 8) + " val:" + HexN(val, 2));
            // Gba.Arm7.Error("read");

            return val;
        }

        public override void Write8(uint addr, byte val)
        {
            if (PrepareSetBank && addr == 0xE000000)
            {
                if (Size == FlashSize.Flash1m)
                {
                    Bank1 = (val & 1) != 0 ? true : false;
                }
                PrepareSetBank = false;
                return;
            }

            if (PrepareWrite)
            {
                addr -= 0xE000000;
                if (Bank1) addr += 0x10000;
                if (addr < Memory.Length)
                {
                    // Writes can only clear bits
                    Memory[addr] &= val;
                    Dirty = true;
                }
                PrepareWrite = false;
                return;
            }

            switch (State)
            {
                case FlashState.InitialState:
                    if (addr == 0xE005555 && val == 0xAA)
                    {
                        // Debug.Log("pre-command 0 sent");
                        State = FlashState.PreCommand0;
                    }
                    break;
                case FlashState.PreCommand0:
                    if (addr == 0xE002AAA && val == 0x55)
                    {
                        // Debug.Log("pre-command 1 sent, ready to receive commands");
                        State = FlashState.PreCommand1;
                    }
                    break;
                case FlashState.PreCommand1:
                    switch (StateSecondary)
                    {
                        case FlashStateSecondary.Ready:
                            if (addr == 0xE005555)
                            {
                                switch (val)
                                {
                                    case 0x90:
                                        // Debug.Log("enter identification mode");
                                        IdentificationMode = true;
                                        break;
                                    case 0xF0:
                                        // Debug.Log("exit identification mode");
                                        // Gba.Arm7.Error("here");
                                        IdentificationMode = false;
                                        break;
                                    case 0x80:
                                        // Debug.Log("preparing to erase");
                                        StateSecondary = FlashStateSecondary.PrepareEraseCommand;
                                        break;
                                    case 0xB0:
                                        // Debug.Log("preparing to set bank");
                                        PrepareSetBank = true;
                                        break;
                                    case 0xA0:
                                        // Debug.Log("preparing to write");
                                        PrepareWrite = true;
                                        break;
                                }
                            }
                            break;
                        case FlashStateSecondary.PrepareEraseCommand:
                            switch (val)
                            {
                                // Erase everything
                                case 0x10:
                                    if (addr == 0xE005555)
                                    {
                                        for (uint i = 0; i < Memory.Length; i++)
                                        {
                                            Memory[i] = 0xFF;
                                        }
                                        Dirty = true;
                                    }
                                    StateSecondary = FlashStateSecondary.Ready;
                                    break;
                                // Erase 4 KB
                                case 0x30:
                                    uint page = addr & 0xF000;
                                    if (Bank1) page += 0x10000;
                                    for (uint i = 0; i < 0x1000; i++)
                                    {
                                        if (i < Memory.Length)
                                        {
                                            Memory[page + i] = 0xFF;
                                        }
                                    }
                                    Dirty = true;
                                    StateSecondary = FlashStateSecondary.Ready;
                                    break;
                            }
                            break;
                    }
                    State = FlashState.InitialState;
                    break;
            }
        }

        public override byte[] GetSave()
        {
            return Memory;
        }

        public override void LoadSave(byte[] save)
        {
            for (uint i = 0; i < save.Length && i < Memory.Length; i++)
            {
                Memory[i] = save[i];
            }
        }
    }
}