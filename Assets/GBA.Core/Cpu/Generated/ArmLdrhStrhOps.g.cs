// Auto-generated code
using GameboyAdvanced.Core.Cpu.Shared;
namespace GameboyAdvanced.Core.Cpu
{

    internal static unsafe partial class Arm
    {

        static partial void ldrsh_prip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrsh_prrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrsb_prip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrsb_prrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrh_prip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrh_prrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] + offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrsh_ofip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW);
        }


        static partial void ldrsh_ofrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW);
        }


        static partial void ldrsb_ofip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB);
        }


        static partial void ldrsb_ofrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB);
        }


        static partial void ldrh_ofip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW);
        }


        static partial void ldrh_ofrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommon(core, core.R[rn] + offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW);
        }


        static partial void ldrsh_prim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrsh_prrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrsb_prim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrsb_prrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrh_prim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrh_prrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn] - offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrsh_ofim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW);
        }


        static partial void ldrsh_ofrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW);
        }


        static partial void ldrsb_ofim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB);
        }


        static partial void ldrsb_ofrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB);
        }


        static partial void ldrh_ofim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW);
        }


        static partial void ldrh_ofrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommon(core, core.R[rn] - offset, BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW);
        }


        static partial void ldrsh_ptip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrsh_ptrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrsb_ptip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrsb_ptrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrh_ptip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrh_ptrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW, (int)rn, core.R[rn] + offset);
        }


        static partial void ldrsh_ptim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrsh_ptrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRSHW, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrsb_ptim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrsb_ptrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.Byte, (int)rd, &LdrStrUtils.LDRSB, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrh_ptim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW, (int)rn, core.R[rn] - offset);
        }


        static partial void ldrh_ptrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.LDRCommonWriteback(core, core.R[rn], BusWidth.HalfWord, (int)rd, &LdrStrUtils.LDRHW, (int)rn, core.R[rn] - offset);
        }


        static partial void strh_prip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord, (int)rn, core.R[rn] + offset);
        }


        static partial void strh_prrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] + offset, core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord, (int)rn, core.R[rn] + offset);
        }


        static partial void strh_ofip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord);
        }


        static partial void strh_ofrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.STRCommon(core, core.R[rn] + offset, core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord);
        }


        static partial void strh_prim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord, (int)rn, core.R[rn] - offset);
        }


        static partial void strh_prrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.STRCommonWriteback(core, core.R[rn] - offset, core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord, (int)rn, core.R[rn] - offset);
        }


        static partial void strh_ofim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord);
        }


        static partial void strh_ofrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.STRCommon(core, core.R[rn] - offset, core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord);
        }


        static partial void strh_ptip(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord, (int)rn, core.R[rn] + offset);
        }


        static partial void strh_ptrp(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord, (int)rn, core.R[rn] + offset);
        }


        static partial void strh_ptim(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = instruction & 0b1111 | ((instruction & 0b1111_0000_0000) >> 4);

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord, (int)rn, core.R[rn] - offset);
        }


        static partial void strh_ptrm(Core core, uint instruction)
        {
            var rn = (instruction >> 16) & 0b1111;
            var rd = (instruction >> 12) & 0b1111;

            var offset = core.R[instruction & 0b1111];

            LdrStrUtils.STRCommonWriteback(core, core.R[rn], core.R[rd] & 0xFFFF | ((core.R[rd] & 0xFFFF) << 16), BusWidth.HalfWord, (int)rn, core.R[rn] - offset);
        }

    }
}