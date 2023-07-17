// Auto-generated code
using static GameboyAdvanced.Core.Cpu.ALU;
using static GameboyAdvanced.Core.Cpu.Shifter;
using GameboyAdvanced.Core.Cpu.Shared;
namespace GameboyAdvanced.Core.Cpu
{

    internal static unsafe partial class Arm
    {

        static partial void ldrb_prrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] + offset);
        }

        static partial void ldrb_prrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] + offset);
        }

        static partial void ldrb_prrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] + offset);
        }

        static partial void ldrb_prrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] + offset);
        }

        static partial void ldrb_prip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] + offset);
        }

        static partial void ldrb_ofrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB);
        }

        static partial void ldrb_ofrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB);
        }

        static partial void ldrb_ofrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB);
        }

        static partial void ldrb_ofrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB);
        }

        static partial void ldrb_ofip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB);
        }

        static partial void ldrb_prrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] - offset);
        }

        static partial void ldrb_prrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] - offset);
        }

        static partial void ldrb_prrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] - offset);
        }

        static partial void ldrb_prrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] - offset);
        }

        static partial void ldrb_prim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] - offset);
        }

        static partial void ldrb_ofrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB);
        }

        static partial void ldrb_ofrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB);
        }

        static partial void ldrb_ofrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB);
        }

        static partial void ldrb_ofrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB);
        }

        static partial void ldrb_ofim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB);
        }

        static partial void ldrb_ptrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] + offset);
        }

        static partial void ldrb_ptrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] + offset);
        }

        static partial void ldrb_ptrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] + offset);
        }

        static partial void ldrb_ptrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] + offset);
        }

        static partial void ldrb_ptip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] + offset);
        }

        static partial void ldrb_ptrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] - offset);
        }

        static partial void ldrb_ptrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] - offset);
        }

        static partial void ldrb_ptrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] - offset);
        }

        static partial void ldrb_ptrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] - offset);
        }

        static partial void ldrb_ptim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRB, (int)rn, core.R[rn] - offset);
        }

        static partial void ldr_prrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] + offset);
        }

        static partial void ldr_prrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] + offset);
        }

        static partial void ldr_prrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] + offset);
        }

        static partial void ldr_prrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] + offset);
        }

        static partial void ldr_prip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] + offset);
        }

        static partial void ldr_ofrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW);
        }

        static partial void ldr_ofrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW);
        }

        static partial void ldr_ofrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW);
        }

        static partial void ldr_ofrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW);
        }

        static partial void ldr_ofip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW);
        }

        static partial void ldr_prrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] - offset);
        }

        static partial void ldr_prrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] - offset);
        }

        static partial void ldr_prrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] - offset);
        }

        static partial void ldr_prrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] - offset);
        }

        static partial void ldr_prim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] - offset);
        }

        static partial void ldr_ofrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW);
        }

        static partial void ldr_ofrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW);
        }

        static partial void ldr_ofrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW);
        }

        static partial void ldr_ofrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW);
        }

        static partial void ldr_ofim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Word, (int)rd, &LdrStrUtils.LDRW);
        }

        static partial void ldr_ptrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] + offset);
        }

        static partial void ldr_ptrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] + offset);
        }

        static partial void ldr_ptrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] + offset);
        }

        static partial void ldr_ptrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] + offset);
        }

        static partial void ldr_ptip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] + offset);
        }

        static partial void ldr_ptrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] - offset);
        }

        static partial void ldr_ptrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] - offset);
        }

        static partial void ldr_ptrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] - offset);
        }

        static partial void ldr_ptrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] - offset);
        }

        static partial void ldr_ptim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Word, (int)rd, &LdrStrUtils.LDRW, (int)rn, core.R[rn] - offset);
        }

        static partial void strb_prrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] + offset);
        }

        static partial void strb_prrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] + offset);
        }

        static partial void strb_prrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] + offset);
        }

        static partial void strb_prrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] + offset);
        }

        static partial void strb_prip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] + offset);
        }

        static partial void strb_ofrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte);
        }

        static partial void strb_ofrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte);
        }

        static partial void strb_ofrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte);
        }

        static partial void strb_ofrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte);
        }

        static partial void strb_ofip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte);
        }

        static partial void strb_prrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] - offset);
        }

        static partial void strb_prrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] - offset);
        }

        static partial void strb_prrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] - offset);
        }

        static partial void strb_prrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] - offset);
        }

        static partial void strb_prim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] - offset);
        }

        static partial void strb_ofrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte);
        }

        static partial void strb_ofrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte);
        }

        static partial void strb_ofrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte);
        }

        static partial void strb_ofrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte);
        }

        static partial void strb_ofim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte);
        }

        static partial void strb_ptrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] + offset);
        }

        static partial void strb_ptrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] + offset);
        }

        static partial void strb_ptrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] + offset);
        }

        static partial void strb_ptrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] + offset);
        }

        static partial void strb_ptip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] + offset);
        }

        static partial void strb_ptrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] - offset);
        }

        static partial void strb_ptrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] - offset);
        }

        static partial void strb_ptrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] - offset);
        }

        static partial void strb_ptrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] - offset);
        }

        static partial void strb_ptim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 8) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 16) | ((((rd == 15) ? core.R[rd] + 4 : core.R[rd]) & 0xFF) << 24), BusWidth.Byte, (int)rn, core.R[rn] - offset);
        }

        static partial void str_prrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] + offset);
        }

        static partial void str_prrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] + offset);
        }

        static partial void str_prrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] + offset);
        }

        static partial void str_prrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] + offset);
        }

        static partial void str_prip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] + offset);
        }

        static partial void str_ofrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word);
        }

        static partial void str_ofrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word);
        }

        static partial void str_ofrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word);
        }

        static partial void str_ofrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word);
        }

        static partial void str_ofip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word);
        }

        static partial void str_prrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] - offset);
        }

        static partial void str_prrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] - offset);
        }

        static partial void str_prrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] - offset);
        }

        static partial void str_prrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] - offset);
        }

        static partial void str_prim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] - offset);
        }

        static partial void str_ofrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word);
        }

        static partial void str_ofrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word);
        }

        static partial void str_ofrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word);
        }

        static partial void str_ofrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word);
        }

        static partial void str_ofim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word);
        }

        static partial void str_ptrpll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] + offset);
        }

        static partial void str_ptrplr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] + offset);
        }

        static partial void str_ptrpar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] + offset);
        }

        static partial void str_ptrprr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] + offset);
        }

        static partial void str_ptip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] + offset);
        }

        static partial void str_ptrmll(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSLNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] - offset);
        }

        static partial void str_ptrmlr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = LSRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] - offset);
        }

        static partial void str_ptrmar(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = ASRImmediateNoFlags(core.R[rm], shiftAmount);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] - offset);
        }

        static partial void str_ptrmrr(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;


            var rm = instruction & 0b1111;
            var shiftType = (instruction >> 4) & 0b11;
            var shiftAmount = (byte)((instruction >> 7) & 0b1_1111); var offset = RORNoFlagsIncRRX(core.R[rm], shiftAmount, ref core.Cpsr);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] - offset);
        }

        static partial void str_ptim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111_1111_1111;

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], (rd == 15) ? core.R[rd] + 4 : core.R[rd], BusWidth.Word, (int)rn, core.R[rn] - offset);
        }
    }
}