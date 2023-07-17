// Auto-generated code
using GameboyAdvanced.Core.Cpu.Shared;

namespace GameboyAdvanced.Core.Cpu
{

    internal static unsafe partial class Arm
    {

        static partial void ldmib_uw(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.GetUserModeRegister((int)rn) + 4;
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = core.GetUserModeRegister((int)rn) + 4;
            }
            core.AIncrement = 0;


        }


        static partial void ldmib_w(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.R[rn] + 4;
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = core.R[rn] + 4;
            }
            core.AIncrement = 0;


        }


        static partial void ldmib_u(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.GetUserModeRegister((int)rn) + 4;
            }
            else
            {

                core.A = core.GetUserModeRegister((int)rn) + 4;
            }
            core.AIncrement = 0;


        }


        static partial void ldmib(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.R[rn] + 4;
            }
            else
            {

                core.A = core.R[rn] + 4;
            }
            core.AIncrement = 0;


        }


        static partial void ldmia_uw(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.GetUserModeRegister((int)rn);
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = core.GetUserModeRegister((int)rn);
            }
            core.AIncrement = 0;


        }


        static partial void ldmia_w(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.R[rn];
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = core.R[rn];
            }
            core.AIncrement = 0;


        }


        static partial void ldmia_u(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.GetUserModeRegister((int)rn);
            }
            else
            {

                core.A = core.GetUserModeRegister((int)rn);
            }
            core.AIncrement = 0;


        }


        static partial void ldmia(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.R[rn];
            }
            else
            {

                core.A = core.R[rn];
            }
            core.AIncrement = 0;


        }


        static partial void ldmdb_uw(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.GetUserModeRegister((int)rn) - 0x40);
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = (uint)(core.GetUserModeRegister((int)rn) - (4 * LdmStmUtils._storeLoadMultiplePopCount));
            }
            core.AIncrement = 0;


        }


        static partial void ldmdb_w(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.R[rn] - 0x40);
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = (uint)(core.R[rn] - (4 * LdmStmUtils._storeLoadMultiplePopCount));
            }
            core.AIncrement = 0;


        }


        static partial void ldmdb_u(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.GetUserModeRegister((int)rn) - 0x40);
            }
            else
            {

                core.A = (uint)(core.GetUserModeRegister((int)rn) - (4 * LdmStmUtils._storeLoadMultiplePopCount));
            }
            core.AIncrement = 0;


        }


        static partial void ldmdb(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.R[rn] - 0x40);
            }
            else
            {

                core.A = (uint)(core.R[rn] - (4 * LdmStmUtils._storeLoadMultiplePopCount));
            }
            core.AIncrement = 0;


        }


        static partial void ldmda_uw(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.GetUserModeRegister((int)rn) - 0x3C);
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = (uint)(core.GetUserModeRegister((int)rn) - (4 * (LdmStmUtils._storeLoadMultiplePopCount - 1)));
            }
            core.AIncrement = 0;


        }


        static partial void ldmda_w(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.R[rn] - 0x3C);
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = (uint)(core.R[rn] - (4 * (LdmStmUtils._storeLoadMultiplePopCount - 1)));
            }
            core.AIncrement = 0;


        }


        static partial void ldmda_u(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.GetUserModeRegister((int)rn) - 0x3C);
            }
            else
            {

                core.A = (uint)(core.GetUserModeRegister((int)rn) - (4 * (LdmStmUtils._storeLoadMultiplePopCount - 1)));
            }
            core.AIncrement = 0;


        }


        static partial void ldmda(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = false;
            core.NextExecuteAction = &LdmStmUtils.LdmRegisterReadCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.R[rn] - 0x3C);
            }
            else
            {

                core.A = (uint)(core.R[rn] - (4 * (LdmStmUtils._storeLoadMultiplePopCount - 1)));
            }
            core.AIncrement = 0;


        }


        static partial void stmib_uw(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.GetUserModeRegister((int)rn) + 4 - 4;
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = core.GetUserModeRegister((int)rn) + 4 - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmib_w(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.R[rn] + 4 - 4;
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = core.R[rn] + 4 - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmib_u(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.GetUserModeRegister((int)rn) + 4 - 4;
            }
            else
            {

                core.A = core.GetUserModeRegister((int)rn) + 4 - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmib(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.R[rn] + 4 - 4;
            }
            else
            {

                core.A = core.R[rn] + 4 - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmia_uw(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.GetUserModeRegister((int)rn) - 4;
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = core.GetUserModeRegister((int)rn) - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmia_w(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.R[rn] - 4;
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = core.R[rn] - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmia_u(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.GetUserModeRegister((int)rn) - 4;
            }
            else
            {

                core.A = core.GetUserModeRegister((int)rn) - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmia(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] + 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = core.R[rn] - 4;
            }
            else
            {

                core.A = core.R[rn] - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmdb_uw(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.GetUserModeRegister((int)rn) - 0x40) - 4;
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = (uint)(core.GetUserModeRegister((int)rn) - (4 * LdmStmUtils._storeLoadMultiplePopCount)) - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmdb_w(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.R[rn] - 0x40) - 4;
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = (uint)(core.R[rn] - (4 * LdmStmUtils._storeLoadMultiplePopCount)) - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmdb_u(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.GetUserModeRegister((int)rn) - 0x40) - 4;
            }
            else
            {

                core.A = (uint)(core.GetUserModeRegister((int)rn) - (4 * LdmStmUtils._storeLoadMultiplePopCount)) - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmdb(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.R[rn] - 0x40) - 4;
            }
            else
            {

                core.A = (uint)(core.R[rn] - (4 * LdmStmUtils._storeLoadMultiplePopCount)) - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmda_uw(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.GetUserModeRegister((int)rn) - 0x3C) - 4;
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = (uint)(core.GetUserModeRegister((int)rn) - (4 * (LdmStmUtils._storeLoadMultiplePopCount - 1))) - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmda_w(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = true;
            LdmStmUtils._writebackRegister = (int)rn;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.R[rn] - 0x3C) - 4;
            }
            else
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - (4 * LdmStmUtils._storeLoadMultiplePopCount));
                core.A = (uint)(core.R[rn] - (4 * (LdmStmUtils._storeLoadMultiplePopCount - 1))) - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmda_u(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();
            LdmStmUtils._useBank0Regs = true;

            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.GetUserModeRegister((int)rn) - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.GetUserModeRegister((int)rn) - 0x3C) - 4;
            }
            else
            {

                core.A = (uint)(core.GetUserModeRegister((int)rn) - (4 * (LdmStmUtils._storeLoadMultiplePopCount - 1))) - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }


        static partial void stmda(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var registerList = instruction & 0xFFFF;
            LdmStmUtils.Reset();


            for (var r = 0; r <= 15; r++)
            {
                if (((registerList >> r) & 0b1) == 0b1)
                {
                    LdmStmUtils._storeLoadMultipleState[LdmStmUtils._storeLoadMultiplePopCount] = (uint)r;
                    LdmStmUtils._storeLoadMultiplePopCount++;
                }
            }

            core.nOPC = true;
            core.SEQ = 0;
            core.MAS = BusWidth.Word;
            core.nRW = true;
            core.NextExecuteAction = &LdmStmUtils.StmRegisterWriteCycle;

            LdmStmUtils._storeLoadMultipleDoWriteback = false;
            if (LdmStmUtils._storeLoadMultiplePopCount == 0)
            {
                LdmStmUtils._storeLoadMutipleFinalWritebackValue = (uint)(core.R[rn] - 0x40);
                LdmStmUtils._storeLoadMultiplePopCount = 1;
                LdmStmUtils._storeLoadMultipleState[0] = 15;
                core.A = (uint)(core.R[rn] - 0x3C) - 4;
            }
            else
            {

                core.A = (uint)(core.R[rn] - (4 * (LdmStmUtils._storeLoadMultiplePopCount - 1))) - 4;
            }
            core.AIncrement = 0;

            LdmStmUtils.StmRegisterWriteCycle(core, instruction);
        }

    }
}