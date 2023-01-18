using System;
using static OptimeGBA.Bits;
using System.Runtime.CompilerServices;

namespace OptimeGBA
{
    public enum ResamplingMode
    {
        None,
        Linear,
        Sinc,
        SincLowPass,
    }

    public sealed class CircularBufferOverwriting<T>
    {
        public uint Size;
        public T[] Buffer;
        public uint ReadPos = 0;
        public uint WritePos = 0;

        public CircularBufferOverwriting(uint size)
        {
            Size = size;
            Buffer = new T[Size];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Insert(T data)
        {
            Buffer[WritePos++] = data;

            if (WritePos >= Size)
            {
                WritePos = 0;
            }

            return;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Pop()
        {
            T data = Buffer[ReadPos++];

            if (ReadPos >= Size)
            {
                ReadPos = 0;
            }

            return data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Peek(int offset)
        {
            return Buffer[(ReadPos + offset) % Size];
        }

        public void Reset()
        {
            ReadPos = 0;
            WritePos = 0;
        }
    }

    public sealed class CircularBuffer<T>
    {
        public uint Size;
        public T[] Buffer;
        public T EmptyValue;
        public uint ReadPos = 0;
        public uint WritePos = 0;
        public uint Entries = 0;
        public uint TotalPops = 0;
        public uint EmptyPops = 0;
        public uint FullInserts = 0;
        public uint Collisions = 0;

        public CircularBuffer(uint size, T emptyValue)
        {
            Size = size;
            Buffer = new T[Size];
            EmptyValue = emptyValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Insert(T data)
        {
            if (Entries < Size)
            {
                if (ReadPos == WritePos) Collisions++;
                Entries++;
                Buffer[WritePos++] = data;

                if (WritePos >= Size)
                {
                    WritePos = 0;
                }

                return true;
            }

            FullInserts++;
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Pop()
        {
            T data;
            TotalPops++;
            if (Entries > 0)
            {
                Entries--;
                data = Buffer[ReadPos++];

                if (ReadPos >= Size)
                {
                    ReadPos = 0;
                }
            }
            else
            {
                EmptyPops++;
                data = EmptyValue;
            }
            return data;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Peek(int offset)
        {
            return Buffer[(ReadPos + offset) % Size];
        }

        public void Reset()
        {
            Entries = 0;
            ReadPos = 0;
            WritePos = 0;
        }
    }

    public sealed class GbaAudio
    {
        Gba Gba;
        Scheduler Scheduler;
        public GbaAudio(Gba gba, Scheduler scheduler)
        {
            Gba = gba;
            Scheduler = scheduler;

            Scheduler.AddEventRelative(SchedulerId.ApuSample, CyclesPerSample, Sample);
        }

        public GbAudio GbAudio = new GbAudio();

        public bool DebugEnableA = true;
        public bool DebugEnableB = true;

        public CircularBuffer<byte> A = new CircularBuffer<byte>(32, 0);
        public CircularBuffer<byte> B = new CircularBuffer<byte>(32, 0);

        public CircularBufferOverwriting<short> VisBufA = new CircularBufferOverwriting<short>(1024);
        public CircularBufferOverwriting<short> VisBufB = new CircularBufferOverwriting<short>(1024);

        public short CurrentValueA;
        public short CurrentValueB;

        public short PreviousValueA;
        public short PreviousValueB;

        public long LastSampleTimeA;
        public long LastSampleTimeB;

        public long IntervalA = 1;
        public long IntervalB = 1;

        uint BiasLevel = 0x100;
        uint AmplitudeRes;

        // SOUNDCNT_H
        uint SoundVolume = 0; // 0-1
        byte DmaSoundAVolume = 0; // 2
        byte DmaSoundBVolume = 0; // 3

        bool DmaSoundAEnableRight = false; // 8
        bool DmaSoundAEnableLeft = false; // 9
        bool DmaSoundATimerSelect = false; // 10

        bool DmaSoundBEnableRight = false; // 11
        bool DmaSoundBEnableLeft = false; // 12
        bool DmaSoundBTimerSelect = false; // 13

        bool MasterEnable = false;

        public byte ReadHwio8(uint addr)
        {
            byte val = 0;
            switch (addr)
            {
                case 0x4000082: // SOUNDCNT_H B0
                    val |= (byte)((SoundVolume >> 0) & 0b11); // 0-1
                    val |= (byte)(DmaSoundAVolume << 2); // 2
                    val |= (byte)(DmaSoundBVolume << 3); // 3
                    break;
                case 0x4000083: // SOUNDCNT_H B1
                    if (DmaSoundAEnableRight) val = BitSet(val, 8 - 8); // 8
                    if (DmaSoundAEnableLeft) val = BitSet(val, 9 - 8); // 9
                    if (DmaSoundATimerSelect) val = BitSet(val, 10 - 8); // 10
                    if (DmaSoundBEnableRight) val = BitSet(val, 12 - 8); // 12
                    if (DmaSoundBEnableLeft) val = BitSet(val, 13 - 8); // 13
                    if (DmaSoundBTimerSelect) val = BitSet(val, 14 - 8); // 14
                    break;

                // Special case, because SOUNDCNT_X contains both GB Audio status and GBA audio status
                case 0x4000084:
                    // NR52
                    byte i = 0;
                    i |= 0b01110000;
                    if (GbAudio.noise_enabled && GbAudio.noise_dacEnabled) i |= (byte)BIT_3;
                    if (GbAudio.wave_enabled && GbAudio.wave_dacEnabled) i |= (byte)BIT_2;
                    if (GbAudio.pulse2_enabled && GbAudio.pulse2_dacEnabled) i |= (byte)BIT_1;
                    if (GbAudio.pulse1_enabled && GbAudio.pulse1_dacEnabled) i |= (byte)BIT_0;

                    if (MasterEnable) i |= (byte)BIT_7;
                    return i;

                case 0x4000088: // SOUNDBIAS B0
                    val |= (byte)(BiasLevel << 1);
                    break;
                case 0x4000089: // SOUNDBIAS B1
                    val |= (byte)(BiasLevel >> 7);
                    val |= (byte)(AmplitudeRes << 6);
                    break;
            }

            if (addr >= 0x4000060 && addr <= 0x4000084)
            {
                // GB Registers
                val = GbAudio.ReadHwio8(addr & 0xFF);
            }
            else if (addr >= 0x4000090 && addr <= 0x400009F)
            {
                // Wave RAM
                val = GbAudio.ReadHwio8(addr & 0xFF);
            }


            return val;
        }

        public void WriteHwio8(uint addr, byte val)
        {
            if (addr >= 0x4000060 && addr <= 0x400009F)
            {
                GbAudio.WriteHwio8(addr & 0xFF, val);
            }

            switch (addr)
            {
                case 0x4000082: // SOUNDCNT_H B0
                    SoundVolume = (uint)(val & 0b11); // 0-1
                    DmaSoundAVolume = (byte)((val >> 2) & 1); // 2
                    DmaSoundBVolume = (byte)((val >> 3) & 1); // 3
                    break;
                case 0x4000083: // SOUNDCNT_H B1
                    DmaSoundAEnableRight = BitTest(val, 8 - 8); // 8
                    DmaSoundAEnableLeft = BitTest(val, 9 - 8); // 9
                    DmaSoundATimerSelect = BitTest(val, 10 - 8); // 10
                    if (BitTest(val, 11 - 8)) A.Reset();
                    DmaSoundBEnableRight = BitTest(val, 12 - 8); // 12
                    DmaSoundBEnableLeft = BitTest(val, 13 - 8); // 13
                    DmaSoundBTimerSelect = BitTest(val, 14 - 8); // 14
                    if (BitTest(val, 15 - 8)) B.Reset();
                    break;
                case 0x4000084: // SOUNDCNT_X
                    MasterEnable = BitTest(val, 7);
                    break;
                case 0x4000088: // SOUNDBIAS B0
                    BiasLevel &= 0b110000000;
                    BiasLevel |= (uint)((val >> 1) & 0b1111111);
                    break;
                case 0x4000089: // SOUNDBIAS B1
                    BiasLevel &= 0b001111111;
                    BiasLevel |= (uint)((val & 0b11) << 7);

                    AmplitudeRes &= 0;
                    AmplitudeRes |= (uint)((val >> 6) & 0b11);
                    break;

                case 0x40000A0:
                case 0x40000A1:
                case 0x40000A2:
                case 0x40000A3:
                    // Gba.Arm7.Error("FIFO Insert");
                    A.Insert(val);
                    break;

                case 0x40000A4:
                case 0x40000A5:
                case 0x40000A6:
                case 0x40000A7:
                    // Gba.Arm7.Error("FIFO Insert");
                    B.Insert(val);
                    break;
            }
        }

        public bool CollectSamples = true;

        public bool EnablePsg = true;
        public bool EnableFifo = true;

        public BlipBuf BlipBuf = new BlipBuf(32, true, 2);
        public ResamplingMode ResamplingMode = ResamplingMode.Sinc;
        public const int SampleRate = 32768;
        const int CyclesPerSample = 16777216 / SampleRate;
        // public CircularBuffer<short> SampleBuffer = new CircularBuffer<short>(32768, 0);
        public const uint SampleBufferMax = 256;
        public short[] SampleBuffer = new short[SampleBufferMax];
        public uint SampleBufferPos = 0;
        public bool AudioReady;

        public uint VisSamplingTimer = 0;

        public void Sample(long cyclesLate)
        {
            GbAudio.Tick(CyclesPerSample / 4); // convert to GB sample rate

            BlipBuf.ReadOutSample();

            double fifoASinc = BlipBuf.CurrentValL;
            double fifoBSinc = BlipBuf.CurrentValR;

            short fifoA = 0;
            short fifoB = 0;
            short psgA = 0;
            short psgB = 0;

            if (MasterEnable)
            {
                if (EnablePsg)
                {
                    psgA += GbAudio.Out1;
                    psgB += GbAudio.Out2;
                }
                if (EnableFifo)
                {
                    switch (ResamplingMode)
                    {
                        case ResamplingMode.None:
                            if (DebugEnableA)
                            {
                                if (DmaSoundAEnableLeft) fifoA += CurrentValueA;
                                if (DmaSoundAEnableRight) fifoB += CurrentValueA;
                            }
                            if (DebugEnableB)
                            {
                                if (DmaSoundBEnableLeft) fifoA += CurrentValueB;
                                if (DmaSoundBEnableRight) fifoB += CurrentValueB;
                            }
                            break;
                        case ResamplingMode.Linear:
                            long current = Scheduler.CurrentTicks - cyclesLate;

                            if (DebugEnableA)
                            {
                                double ratio = (current - LastSampleTimeA) / (double)IntervalA;
                                double valDouble = (PreviousValueA + ratio * (double)(CurrentValueA - PreviousValueA));
                                short val = (short)valDouble;

                                if (DmaSoundAEnableLeft) fifoA += val;
                                if (DmaSoundAEnableRight) fifoB += val;
                            }
                            if (DebugEnableB)
                            {
                                double ratio = (current - LastSampleTimeB) / (double)IntervalB;
                                double valDouble = (PreviousValueB + ratio * (double)(CurrentValueB - PreviousValueB));
                                short val = (short)valDouble;

                                if (DmaSoundBEnableLeft) fifoA += val;
                                if (DmaSoundBEnableRight) fifoB += val;
                            }
                            break;
                        case ResamplingMode.Sinc:
                        case ResamplingMode.SincLowPass:
                            if (DebugEnableA)
                            {
                                if (DmaSoundAEnableLeft) fifoA += (short)(fifoASinc);
                                if (DmaSoundAEnableRight) fifoB += (short)(fifoASinc);
                            }
                            if (DebugEnableB)
                            {
                                if (DmaSoundBEnableLeft) fifoA += (short)(fifoBSinc);
                                if (DmaSoundBEnableRight) fifoB += (short)(fifoBSinc);
                            }
                            break;
                    }
                }
            }

            if (++VisSamplingTimer >= 4)
            {
                VisSamplingTimer = 0;

                VisBufA.Insert(CurrentValueA);
                VisBufB.Insert(CurrentValueB);
            }

            SampleBuffer[SampleBufferPos++] = (short)((fifoA + psgA) * 64);
            SampleBuffer[SampleBufferPos++] = (short)((fifoB + psgB) * 64);

            if (SampleBufferPos >= SampleBufferMax)
            {
                SampleBufferPos = 0;

                Gba.AudioCallback(SampleBuffer);
            }

            Scheduler.AddEventRelative(SchedulerId.ApuSample, CyclesPerSample - cyclesLate, Sample);
        }

        public void TimerOverflowFifoA(long cyclesLate, uint timerId)
        {
            LastSampleTimeA = Scheduler.CurrentTicks - cyclesLate;
            PreviousValueA = CurrentValueA;
            IntervalA = Gba.Timers.T[timerId].Interval;

            CurrentValueA = (short)((sbyte)A.Pop() << DmaSoundAVolume);

            BlipBuf.SetValue(0, (float)LastSampleTimeA / CyclesPerSample, (float)CurrentValueA, 0);

            if (A.Entries <= 16)
            {
                Gba.Dma.RepeatFifoA();
            }
        }
        public void TimerOverflowFifoB(long cyclesLate, uint timerId)
        {
            LastSampleTimeB = Scheduler.CurrentTicks - cyclesLate;
            PreviousValueB = CurrentValueB;
            IntervalB = Gba.Timers.T[timerId].Interval;

            CurrentValueB = (short)((sbyte)B.Pop() << DmaSoundBVolume);

            BlipBuf.SetValue(1, (float)LastSampleTimeB / CyclesPerSample, 0, (float)CurrentValueB);

            if (B.Entries <= 16)
            {
                Gba.Dma.RepeatFifoB();
            }
        }

        // Called when Timer 0 or 1 overflows.
        public void TimerOverflow(long cyclesLate, uint timerId)
        {
            if (timerId == 0)
            {
                if (!DmaSoundATimerSelect)
                {
                    TimerOverflowFifoA(cyclesLate, timerId);
                }
                if (!DmaSoundBTimerSelect)
                {
                    TimerOverflowFifoB(cyclesLate, timerId);
                }
            }
            else if (timerId == 1)
            {
                if (DmaSoundATimerSelect)
                {
                    TimerOverflowFifoA(cyclesLate, timerId);
                }
                if (DmaSoundBTimerSelect)
                {
                    TimerOverflowFifoB(cyclesLate, timerId);
                }
            }
        }
    }
}