// Auto-generated code
using static GameboyAdvanced.Core.Cpu.ALU;
using static GameboyAdvanced.Core.Cpu.Shifter;
namespace GameboyAdvanced.Core.Cpu
{

    internal static unsafe partial class Arm
    {


        static partial void ands_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            core.R[rd] = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void ands_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void ands_lli(Core core, uint instruction)
        {
            ands_lli_write(core, instruction);
        }

        static partial void ands_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void ands_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &ands_llr_write;
        }

        static partial void ands_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void ands_lri(Core core, uint instruction)
        {
            ands_lri_write(core, instruction);
        }

        static partial void ands_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void ands_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &ands_lrr_write;
        }

        static partial void ands_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void ands_ari(Core core, uint instruction)
        {
            ands_ari_write(core, instruction);
        }

        static partial void ands_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void ands_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &ands_arr_write;
        }

        static partial void ands_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void ands_rri(Core core, uint instruction)
        {
            ands_rri_write(core, instruction);
        }

        static partial void ands_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void ands_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &ands_rrr_write;
        }


        static partial void and_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = core.R[rn] & secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void and_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] & secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void and_lli(Core core, uint instruction)
        {
            and_lli_write(core, instruction);
        }

        static partial void and_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] & secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void and_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &and_llr_write;
        }

        static partial void and_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] & secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void and_lri(Core core, uint instruction)
        {
            and_lri_write(core, instruction);
        }

        static partial void and_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] & secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void and_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &and_lrr_write;
        }

        static partial void and_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] & secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void and_ari(Core core, uint instruction)
        {
            and_ari_write(core, instruction);
        }

        static partial void and_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] & secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void and_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &and_arr_write;
        }

        static partial void and_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] & secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void and_rri(Core core, uint instruction)
        {
            and_rri_write(core, instruction);
        }

        static partial void and_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] & secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void and_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &and_rrr_write;
        }


        static partial void eors_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            core.R[rd] = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void eors_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eors_lli(Core core, uint instruction)
        {
            eors_lli_write(core, instruction);
        }

        static partial void eors_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eors_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &eors_llr_write;
        }

        static partial void eors_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eors_lri(Core core, uint instruction)
        {
            eors_lri_write(core, instruction);
        }

        static partial void eors_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eors_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &eors_lrr_write;
        }

        static partial void eors_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eors_ari(Core core, uint instruction)
        {
            eors_ari_write(core, instruction);
        }

        static partial void eors_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eors_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &eors_arr_write;
        }

        static partial void eors_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eors_rri(Core core, uint instruction)
        {
            eors_rri_write(core, instruction);
        }

        static partial void eors_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eors_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &eors_rrr_write;
        }


        static partial void eor_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = core.R[rn] ^ secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void eor_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] ^ secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eor_lli(Core core, uint instruction)
        {
            eor_lli_write(core, instruction);
        }

        static partial void eor_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] ^ secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eor_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &eor_llr_write;
        }

        static partial void eor_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] ^ secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eor_lri(Core core, uint instruction)
        {
            eor_lri_write(core, instruction);
        }

        static partial void eor_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] ^ secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eor_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &eor_lrr_write;
        }

        static partial void eor_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] ^ secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eor_ari(Core core, uint instruction)
        {
            eor_ari_write(core, instruction);
        }

        static partial void eor_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] ^ secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eor_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &eor_arr_write;
        }

        static partial void eor_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] ^ secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eor_rri(Core core, uint instruction)
        {
            eor_rri_write(core, instruction);
        }

        static partial void eor_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] ^ secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void eor_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &eor_rrr_write;
        }


        static partial void subs_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            core.R[rd] = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void subs_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void subs_lli(Core core, uint instruction)
        {
            subs_lli_write(core, instruction);
        }

        static partial void subs_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void subs_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &subs_llr_write;
        }

        static partial void subs_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void subs_lri(Core core, uint instruction)
        {
            subs_lri_write(core, instruction);
        }

        static partial void subs_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void subs_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &subs_lrr_write;
        }

        static partial void subs_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void subs_ari(Core core, uint instruction)
        {
            subs_ari_write(core, instruction);
        }

        static partial void subs_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void subs_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &subs_arr_write;
        }

        static partial void subs_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void subs_rri(Core core, uint instruction)
        {
            subs_rri_write(core, instruction);
        }

        static partial void subs_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void subs_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &subs_rrr_write;
        }


        static partial void sub_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = (uint)(core.R[rn] - secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void sub_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] - secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sub_lli(Core core, uint instruction)
        {
            sub_lli_write(core, instruction);
        }

        static partial void sub_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] - secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sub_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sub_llr_write;
        }

        static partial void sub_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] - secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sub_lri(Core core, uint instruction)
        {
            sub_lri_write(core, instruction);
        }

        static partial void sub_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] - secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sub_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sub_lrr_write;
        }

        static partial void sub_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] - secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sub_ari(Core core, uint instruction)
        {
            sub_ari_write(core, instruction);
        }

        static partial void sub_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] - secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sub_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sub_arr_write;
        }

        static partial void sub_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = (uint)(core.R[rn] - secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sub_rri(Core core, uint instruction)
        {
            sub_rri_write(core, instruction);
        }

        static partial void sub_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] - secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sub_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sub_rrr_write;
        }


        static partial void rsbs_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            core.R[rd] = SUB(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void rsbs_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = SUB(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsbs_lli(Core core, uint instruction)
        {
            rsbs_lli_write(core, instruction);
        }

        static partial void rsbs_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = SUB(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsbs_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsbs_llr_write;
        }

        static partial void rsbs_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = SUB(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsbs_lri(Core core, uint instruction)
        {
            rsbs_lri_write(core, instruction);
        }

        static partial void rsbs_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = SUB(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsbs_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsbs_lrr_write;
        }

        static partial void rsbs_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = SUB(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsbs_ari(Core core, uint instruction)
        {
            rsbs_ari_write(core, instruction);
        }

        static partial void rsbs_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = SUB(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsbs_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsbs_arr_write;
        }

        static partial void rsbs_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = SUB(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsbs_rri(Core core, uint instruction)
        {
            rsbs_rri_write(core, instruction);
        }

        static partial void rsbs_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = SUB(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsbs_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsbs_rrr_write;
        }


        static partial void rsb_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = (uint)(secondOperand - core.R[rn]);



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void rsb_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(secondOperand - core.R[rn]);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsb_lli(Core core, uint instruction)
        {
            rsb_lli_write(core, instruction);
        }

        static partial void rsb_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(secondOperand - core.R[rn]);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsb_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsb_llr_write;
        }

        static partial void rsb_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(secondOperand - core.R[rn]);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsb_lri(Core core, uint instruction)
        {
            rsb_lri_write(core, instruction);
        }

        static partial void rsb_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(secondOperand - core.R[rn]);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsb_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsb_lrr_write;
        }

        static partial void rsb_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(secondOperand - core.R[rn]);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsb_ari(Core core, uint instruction)
        {
            rsb_ari_write(core, instruction);
        }

        static partial void rsb_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(secondOperand - core.R[rn]);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsb_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsb_arr_write;
        }

        static partial void rsb_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = (uint)(secondOperand - core.R[rn]);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsb_rri(Core core, uint instruction)
        {
            rsb_rri_write(core, instruction);
        }

        static partial void rsb_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(secondOperand - core.R[rn]);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsb_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsb_rrr_write;
        }


        static partial void adds_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            core.R[rd] = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void adds_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adds_lli(Core core, uint instruction)
        {
            adds_lli_write(core, instruction);
        }

        static partial void adds_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adds_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adds_llr_write;
        }

        static partial void adds_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adds_lri(Core core, uint instruction)
        {
            adds_lri_write(core, instruction);
        }

        static partial void adds_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adds_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adds_lrr_write;
        }

        static partial void adds_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adds_ari(Core core, uint instruction)
        {
            adds_ari_write(core, instruction);
        }

        static partial void adds_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adds_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adds_arr_write;
        }

        static partial void adds_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adds_rri(Core core, uint instruction)
        {
            adds_rri_write(core, instruction);
        }

        static partial void adds_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adds_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adds_rrr_write;
        }


        static partial void add_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = (uint)(core.R[rn] + secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void add_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] + secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void add_lli(Core core, uint instruction)
        {
            add_lli_write(core, instruction);
        }

        static partial void add_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] + secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void add_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &add_llr_write;
        }

        static partial void add_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] + secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void add_lri(Core core, uint instruction)
        {
            add_lri_write(core, instruction);
        }

        static partial void add_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] + secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void add_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &add_lrr_write;
        }

        static partial void add_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] + secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void add_ari(Core core, uint instruction)
        {
            add_ari_write(core, instruction);
        }

        static partial void add_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] + secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void add_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &add_arr_write;
        }

        static partial void add_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = (uint)(core.R[rn] + secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void add_rri(Core core, uint instruction)
        {
            add_rri_write(core, instruction);
        }

        static partial void add_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] + secondOperand);



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void add_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &add_rrr_write;
        }


        static partial void adcs_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = ADC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void adcs_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = ADC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adcs_lli(Core core, uint instruction)
        {
            adcs_lli_write(core, instruction);
        }

        static partial void adcs_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = ADC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adcs_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adcs_llr_write;
        }

        static partial void adcs_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = ADC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adcs_lri(Core core, uint instruction)
        {
            adcs_lri_write(core, instruction);
        }

        static partial void adcs_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = ADC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adcs_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adcs_lrr_write;
        }

        static partial void adcs_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = ADC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adcs_ari(Core core, uint instruction)
        {
            adcs_ari_write(core, instruction);
        }

        static partial void adcs_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = ADC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adcs_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adcs_arr_write;
        }

        static partial void adcs_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = ADC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adcs_rri(Core core, uint instruction)
        {
            adcs_rri_write(core, instruction);
        }

        static partial void adcs_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = ADC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adcs_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adcs_rrr_write;
        }


        static partial void adc_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = (uint)(core.R[rn] + secondOperand + (core.Cpsr.CarryFlag ? 1 : 0));



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void adc_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] + secondOperand + (core.Cpsr.CarryFlag ? 1 : 0));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adc_lli(Core core, uint instruction)
        {
            adc_lli_write(core, instruction);
        }

        static partial void adc_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] + secondOperand + (core.Cpsr.CarryFlag ? 1 : 0));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adc_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adc_llr_write;
        }

        static partial void adc_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] + secondOperand + (core.Cpsr.CarryFlag ? 1 : 0));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adc_lri(Core core, uint instruction)
        {
            adc_lri_write(core, instruction);
        }

        static partial void adc_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] + secondOperand + (core.Cpsr.CarryFlag ? 1 : 0));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adc_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adc_lrr_write;
        }

        static partial void adc_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] + secondOperand + (core.Cpsr.CarryFlag ? 1 : 0));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adc_ari(Core core, uint instruction)
        {
            adc_ari_write(core, instruction);
        }

        static partial void adc_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] + secondOperand + (core.Cpsr.CarryFlag ? 1 : 0));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adc_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adc_arr_write;
        }

        static partial void adc_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = (uint)(core.R[rn] + secondOperand + (core.Cpsr.CarryFlag ? 1 : 0));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adc_rri(Core core, uint instruction)
        {
            adc_rri_write(core, instruction);
        }

        static partial void adc_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] + secondOperand + (core.Cpsr.CarryFlag ? 1 : 0));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void adc_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &adc_rrr_write;
        }


        static partial void sbcs_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = SBC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void sbcs_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = SBC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbcs_lli(Core core, uint instruction)
        {
            sbcs_lli_write(core, instruction);
        }

        static partial void sbcs_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = SBC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbcs_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sbcs_llr_write;
        }

        static partial void sbcs_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = SBC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbcs_lri(Core core, uint instruction)
        {
            sbcs_lri_write(core, instruction);
        }

        static partial void sbcs_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = SBC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbcs_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sbcs_lrr_write;
        }

        static partial void sbcs_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = SBC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbcs_ari(Core core, uint instruction)
        {
            sbcs_ari_write(core, instruction);
        }

        static partial void sbcs_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = SBC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbcs_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sbcs_arr_write;
        }

        static partial void sbcs_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = SBC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbcs_rri(Core core, uint instruction)
        {
            sbcs_rri_write(core, instruction);
        }

        static partial void sbcs_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = SBC(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbcs_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sbcs_rrr_write;
        }


        static partial void sbc_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = (uint)(core.R[rn] - secondOperand - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void sbc_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] - secondOperand - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbc_lli(Core core, uint instruction)
        {
            sbc_lli_write(core, instruction);
        }

        static partial void sbc_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] - secondOperand - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbc_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sbc_llr_write;
        }

        static partial void sbc_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] - secondOperand - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbc_lri(Core core, uint instruction)
        {
            sbc_lri_write(core, instruction);
        }

        static partial void sbc_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] - secondOperand - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbc_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sbc_lrr_write;
        }

        static partial void sbc_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(core.R[rn] - secondOperand - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbc_ari(Core core, uint instruction)
        {
            sbc_ari_write(core, instruction);
        }

        static partial void sbc_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] - secondOperand - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbc_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sbc_arr_write;
        }

        static partial void sbc_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = (uint)(core.R[rn] - secondOperand - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbc_rri(Core core, uint instruction)
        {
            sbc_rri_write(core, instruction);
        }

        static partial void sbc_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(core.R[rn] - secondOperand - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void sbc_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &sbc_rrr_write;
        }


        static partial void rscs_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = SBC(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void rscs_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = SBC(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rscs_lli(Core core, uint instruction)
        {
            rscs_lli_write(core, instruction);
        }

        static partial void rscs_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = SBC(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rscs_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rscs_llr_write;
        }

        static partial void rscs_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = SBC(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rscs_lri(Core core, uint instruction)
        {
            rscs_lri_write(core, instruction);
        }

        static partial void rscs_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = SBC(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rscs_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rscs_lrr_write;
        }

        static partial void rscs_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = SBC(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rscs_ari(Core core, uint instruction)
        {
            rscs_ari_write(core, instruction);
        }

        static partial void rscs_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = SBC(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rscs_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rscs_arr_write;
        }

        static partial void rscs_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = SBC(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rscs_rri(Core core, uint instruction)
        {
            rscs_rri_write(core, instruction);
        }

        static partial void rscs_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = SBC(secondOperand, core.R[rn], ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rscs_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rscs_rrr_write;
        }


        static partial void rsc_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = (uint)(secondOperand - core.R[rn] - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void rsc_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(secondOperand - core.R[rn] - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsc_lli(Core core, uint instruction)
        {
            rsc_lli_write(core, instruction);
        }

        static partial void rsc_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(secondOperand - core.R[rn] - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsc_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsc_llr_write;
        }

        static partial void rsc_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(secondOperand - core.R[rn] - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsc_lri(Core core, uint instruction)
        {
            rsc_lri_write(core, instruction);
        }

        static partial void rsc_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(secondOperand - core.R[rn] - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsc_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsc_lrr_write;
        }

        static partial void rsc_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = (uint)(secondOperand - core.R[rn] - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsc_ari(Core core, uint instruction)
        {
            rsc_ari_write(core, instruction);
        }

        static partial void rsc_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(secondOperand - core.R[rn] - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsc_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsc_arr_write;
        }

        static partial void rsc_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = (uint)(secondOperand - core.R[rn] - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsc_rri(Core core, uint instruction)
        {
            rsc_rri_write(core, instruction);
        }

        static partial void rsc_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = (uint)(secondOperand - core.R[rn] - (core.Cpsr.CarryFlag ? 0 : 1));



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void rsc_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &rsc_rrr_write;
        }


        static partial void tsts_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            var result = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void tsts_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void tsts_lli(Core core, uint instruction)
        {
            tsts_lli_write(core, instruction);
        }

        static partial void tsts_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void tsts_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &tsts_llr_write;
        }

        static partial void tsts_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void tsts_lri(Core core, uint instruction)
        {
            tsts_lri_write(core, instruction);
        }

        static partial void tsts_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void tsts_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &tsts_lrr_write;
        }

        static partial void tsts_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void tsts_ari(Core core, uint instruction)
        {
            tsts_ari_write(core, instruction);
        }

        static partial void tsts_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void tsts_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &tsts_arr_write;
        }

        static partial void tsts_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void tsts_rri(Core core, uint instruction)
        {
            tsts_rri_write(core, instruction);
        }

        static partial void tsts_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = core.R[rn] & secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void tsts_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &tsts_rrr_write;
        }


        static partial void teqs_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            var result = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void teqs_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void teqs_lli(Core core, uint instruction)
        {
            teqs_lli_write(core, instruction);
        }

        static partial void teqs_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void teqs_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &teqs_llr_write;
        }

        static partial void teqs_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void teqs_lri(Core core, uint instruction)
        {
            teqs_lri_write(core, instruction);
        }

        static partial void teqs_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void teqs_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &teqs_lrr_write;
        }

        static partial void teqs_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void teqs_ari(Core core, uint instruction)
        {
            teqs_ari_write(core, instruction);
        }

        static partial void teqs_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void teqs_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &teqs_arr_write;
        }

        static partial void teqs_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void teqs_rri(Core core, uint instruction)
        {
            teqs_rri_write(core, instruction);
        }

        static partial void teqs_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = core.R[rn] ^ secondOperand;

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void teqs_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &teqs_rrr_write;
        }


        static partial void cmps_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            var result = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void cmps_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmps_lli(Core core, uint instruction)
        {
            cmps_lli_write(core, instruction);
        }

        static partial void cmps_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmps_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &cmps_llr_write;
        }

        static partial void cmps_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmps_lri(Core core, uint instruction)
        {
            cmps_lri_write(core, instruction);
        }

        static partial void cmps_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmps_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &cmps_lrr_write;
        }

        static partial void cmps_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmps_ari(Core core, uint instruction)
        {
            cmps_ari_write(core, instruction);
        }

        static partial void cmps_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmps_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &cmps_arr_write;
        }

        static partial void cmps_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmps_rri(Core core, uint instruction)
        {
            cmps_rri_write(core, instruction);
        }

        static partial void cmps_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = SUB(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmps_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &cmps_rrr_write;
        }


        static partial void cmns_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            var result = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void cmns_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmns_lli(Core core, uint instruction)
        {
            cmns_lli_write(core, instruction);
        }

        static partial void cmns_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmns_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &cmns_llr_write;
        }

        static partial void cmns_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmns_lri(Core core, uint instruction)
        {
            cmns_lri_write(core, instruction);
        }

        static partial void cmns_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmns_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &cmns_lrr_write;
        }

        static partial void cmns_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmns_ari(Core core, uint instruction)
        {
            cmns_ari_write(core, instruction);
        }

        static partial void cmns_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmns_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &cmns_arr_write;
        }

        static partial void cmns_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            var result = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmns_rri(Core core, uint instruction)
        {
            cmns_rri_write(core, instruction);
        }

        static partial void cmns_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            var result = ADD(core.R[rn], secondOperand, ref core.Cpsr);

            SetZeroSignFlags(ref core.Cpsr, result);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }

            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void cmns_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &cmns_rrr_write;
        }


        static partial void orrs_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            core.R[rd] = core.R[rn] | secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void orrs_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] | secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orrs_lli(Core core, uint instruction)
        {
            orrs_lli_write(core, instruction);
        }

        static partial void orrs_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] | secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orrs_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &orrs_llr_write;
        }

        static partial void orrs_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] | secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orrs_lri(Core core, uint instruction)
        {
            orrs_lri_write(core, instruction);
        }

        static partial void orrs_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] | secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orrs_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &orrs_lrr_write;
        }

        static partial void orrs_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] | secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orrs_ari(Core core, uint instruction)
        {
            orrs_ari_write(core, instruction);
        }

        static partial void orrs_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] | secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orrs_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &orrs_arr_write;
        }

        static partial void orrs_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] | secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orrs_rri(Core core, uint instruction)
        {
            orrs_rri_write(core, instruction);
        }

        static partial void orrs_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] | secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orrs_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &orrs_rrr_write;
        }


        static partial void orr_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = core.R[rn] | secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void orr_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] | secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orr_lli(Core core, uint instruction)
        {
            orr_lli_write(core, instruction);
        }

        static partial void orr_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] | secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orr_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &orr_llr_write;
        }

        static partial void orr_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] | secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orr_lri(Core core, uint instruction)
        {
            orr_lri_write(core, instruction);
        }

        static partial void orr_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] | secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orr_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &orr_lrr_write;
        }

        static partial void orr_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] | secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orr_ari(Core core, uint instruction)
        {
            orr_ari_write(core, instruction);
        }

        static partial void orr_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] | secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orr_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &orr_arr_write;
        }

        static partial void orr_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] | secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orr_rri(Core core, uint instruction)
        {
            orr_rri_write(core, instruction);
        }

        static partial void orr_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] | secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void orr_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &orr_rrr_write;
        }


        static partial void movs_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            core.R[rd] = secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void movs_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void movs_lli(Core core, uint instruction)
        {
            movs_lli_write(core, instruction);
        }

        static partial void movs_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void movs_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &movs_llr_write;
        }

        static partial void movs_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void movs_lri(Core core, uint instruction)
        {
            movs_lri_write(core, instruction);
        }

        static partial void movs_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void movs_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &movs_lrr_write;
        }

        static partial void movs_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void movs_ari(Core core, uint instruction)
        {
            movs_ari_write(core, instruction);
        }

        static partial void movs_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void movs_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &movs_arr_write;
        }

        static partial void movs_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void movs_rri(Core core, uint instruction)
        {
            movs_rri_write(core, instruction);
        }

        static partial void movs_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void movs_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &movs_rrr_write;
        }


        static partial void mov_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void mov_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mov_lli(Core core, uint instruction)
        {
            mov_lli_write(core, instruction);
        }

        static partial void mov_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mov_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mov_llr_write;
        }

        static partial void mov_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mov_lri(Core core, uint instruction)
        {
            mov_lri_write(core, instruction);
        }

        static partial void mov_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mov_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mov_lrr_write;
        }

        static partial void mov_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mov_ari(Core core, uint instruction)
        {
            mov_ari_write(core, instruction);
        }

        static partial void mov_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mov_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mov_arr_write;
        }

        static partial void mov_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mov_rri(Core core, uint instruction)
        {
            mov_rri_write(core, instruction);
        }

        static partial void mov_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mov_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mov_rrr_write;
        }


        static partial void bics_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            core.R[rd] = core.R[rn] & ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void bics_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] & ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bics_lli(Core core, uint instruction)
        {
            bics_lli_write(core, instruction);
        }

        static partial void bics_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] & ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bics_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &bics_llr_write;
        }

        static partial void bics_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] & ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bics_lri(Core core, uint instruction)
        {
            bics_lri_write(core, instruction);
        }

        static partial void bics_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] & ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bics_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &bics_lrr_write;
        }

        static partial void bics_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] & ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bics_ari(Core core, uint instruction)
        {
            bics_ari_write(core, instruction);
        }

        static partial void bics_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] & ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bics_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &bics_arr_write;
        }

        static partial void bics_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] & ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bics_rri(Core core, uint instruction)
        {
            bics_rri_write(core, instruction);
        }

        static partial void bics_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = core.R[rn] & ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bics_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &bics_rrr_write;
        }


        static partial void bic_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = core.R[rn] & ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void bic_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] & ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bic_lli(Core core, uint instruction)
        {
            bic_lli_write(core, instruction);
        }

        static partial void bic_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] & ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bic_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &bic_llr_write;
        }

        static partial void bic_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] & ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bic_lri(Core core, uint instruction)
        {
            bic_lri_write(core, instruction);
        }

        static partial void bic_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] & ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bic_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &bic_lrr_write;
        }

        static partial void bic_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = core.R[rn] & ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bic_ari(Core core, uint instruction)
        {
            bic_ari_write(core, instruction);
        }

        static partial void bic_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] & ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bic_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &bic_arr_write;
        }

        static partial void bic_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = core.R[rn] & ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bic_rri(Core core, uint instruction)
        {
            bic_rri_write(core, instruction);
        }

        static partial void bic_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = core.R[rn] & ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void bic_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &bic_rrr_write;
        }


        static partial void mvns_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = ROR(imm, (byte)rot, ref core.Cpsr);

            core.R[rd] = ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void mvns_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvns_lli(Core core, uint instruction)
        {
            mvns_lli_write(core, instruction);
        }

        static partial void mvns_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSL(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvns_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mvns_llr_write;
        }

        static partial void mvns_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvns_lri(Core core, uint instruction)
        {
            mvns_lri_write(core, instruction);
        }

        static partial void mvns_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvns_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mvns_lrr_write;
        }

        static partial void mvns_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediate(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvns_ari(Core core, uint instruction)
        {
            mvns_ari_write(core, instruction);
        }

        static partial void mvns_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegister(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvns_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mvns_arr_write;
        }

        static partial void mvns_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvns_rri(Core core, uint instruction)
        {
            mvns_rri_write(core, instruction);
        }

        static partial void mvns_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ROR(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111], ref core.Cpsr);

            core.R[rd] = ~secondOperand;

            SetZeroSignFlags(ref core.Cpsr, core.R[rd]);

            if (rd == 15)
            {
                var newMode = core.Cpsr.Set(core.CurrentSpsr().Get());
                var needsThumbMode = core.CurrentSpsr().ThumbMode;
                if (core.CurrentSpsr().ThumbMode)
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFE;
                }
                else
                {
                    core.R[15] = core.R[15] & 0xFFFF_FFFC;
                }

                if (newMode != core.Cpsr.Mode)
                {
                    core.SwitchMode(newMode);
                }

                if (needsThumbMode)
                {
                    core.SwitchToThumb();
                }
                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvns_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mvns_rrr_write;
        }


        static partial void mvn_imm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var imm = instruction & 0b1111_1111;
            var rot = ((instruction >> 8) & 0b1111) * 2;
            var secondOperand = RORInternal(imm, (byte)rot);

            core.R[rd] = ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }

            core.MoveExecutePipelineToNextInstruction();
        }

        static partial void mvn_lli_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvn_lli(Core core, uint instruction)
        {
            mvn_lli_write(core, instruction);
        }

        static partial void mvn_llr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSLNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvn_llr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mvn_llr_write;
        }

        static partial void mvn_lri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvn_lri(Core core, uint instruction)
        {
            mvn_lri_write(core, instruction);
        }

        static partial void mvn_lrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = LSRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvn_lrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mvn_lrr_write;
        }

        static partial void mvn_ari_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRImmediateNoFlags(core.R[rm], (byte)((instruction >> 7) & 0b1_1111));

            core.R[rd] = ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvn_ari(Core core, uint instruction)
        {
            mvn_ari_write(core, instruction);
        }

        static partial void mvn_arr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = ASRRegisterNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvn_arr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mvn_arr_write;
        }

        static partial void mvn_rri_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlagsIncRRX(core.R[rm], (byte)((instruction >> 7) & 0b1_1111), ref core.Cpsr);

            core.R[rd] = ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvn_rri(Core core, uint instruction)
        {
            mvn_rri_write(core, instruction);
        }

        static partial void mvn_rrr_write(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;
            var rm = instruction & 0b1111;

            var secondOperand = RORNoFlags(core.R[rm], (byte)core.R[(instruction >> 8) & 0b1111]);

            core.R[rd] = ~secondOperand;



            if (rd == 15)
            {

                core.ClearPipeline();
            }


            core.nOPC = false;
            core.SEQ = 1;
            core.AIncrement = 0;
            core.nMREQ = false;
            core.MoveExecutePipelineToNextInstruction();
        }
        // Auto-generated code
        static partial void mvn_rrr(Core core, uint instruction)
        {

            core.nMREQ = true;
            core.nOPC = true;
            core.SEQ = 0;
            core.NextExecuteAction = &mvn_rrr_write;
        }
    }
}