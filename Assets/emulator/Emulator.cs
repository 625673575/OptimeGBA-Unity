using UnityEngine.UI;
using UnityEngine;
using OptimeGBA;
using System.IO;
using System.Runtime.InteropServices;
using System;
using static SDL2.SDL;
using System.Threading;

public class Emulator : MonoBehaviour
{
    const int FrameCycles = 70224 * 4;
    const int ScanlineCycles = 1232;
    bool SyncToAudio = true;

    const uint AUDIO_SAMPLE_THRESHOLD = 1024;
    const uint AUDIO_SAMPLE_FULL_THRESHOLD = 1024;
    const int SAMPLES_PER_CALLBACK = 32;
    SDL_AudioSpec want, have;
    uint AudioDevice;
    public int ThreadCyclesQueued;

    public RawImage screen;
    uint[] DisplayBuffer = new uint[240 * 160];
    Color32[] DisplayColorBuffer = new Color32[240 * 160];

    public bool ShowBackBuf = false;
    public bool RunEmulator;
    public bool BootBIOS = false;
    bool RomLoaded = false;

    Gba gba;
    Thread EmulationThread;
    AutoResetEvent ThreadSync = new AutoResetEvent(false);

    private void Awake()
    {
        // must set it to 60 or it won't sync with audio or run too fast.
        Application.targetFrameRate = 60;
        screen.texture = new Texture2D(240, 160, TextureFormat.RGBA32, false);
    }
    void Start()
    {
        byte[] bios = System.IO.File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, "gba_bios.bin"));
        gba = new Gba(new ProviderGba(bios, new byte[0], "", AudioReady) { BootBios = true });
        gba.Provider.BootBios = BootBIOS;
        EmulationThread = new Thread(EmulationThreadHandler);
        EmulationThread.Name = "Emulation Core";
        EmulationThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdateFrame();
        if (RomLoaded)
        {
            OnRenderFrame();
        }
    }

    private void OnDestroy()
    {

        SDL_CloseAudioDevice(AudioDevice);
        SDL_Quit();
    }
    public void OpenRom()
    {
        string[] paths = SFB.StandaloneFileBrowser.OpenFilePanel("BVA", "", new SFB.ExtensionFilter[] { new SFB.ExtensionFilter("ROM", "gba") }, false);
        if (paths.Length == 0) return;
        LoadRomFromPath(paths[0]);
    }
    public void LoadRomFromPath(string path)
    {
        byte[] rom = System.IO.File.ReadAllBytes(path);
        string savPath = path.Substring(0, path.Length - 3) + "sav";
        byte[] sav = new byte[0];
        if (System.IO.File.Exists(savPath))
        {
            Console.WriteLine(".sav exists, loading");
            try
            {
                sav = System.IO.File.ReadAllBytes(savPath);
            }
            catch
            {
                Console.WriteLine("Failed to load .sav file!");
            }
        }
        else
        {
            Console.WriteLine(".sav not available");
        }

        LoadRomAndSave(rom, sav, savPath);
        Debug.Log("Load Rom Success");
        RomLoaded = true;
        RunEmulator = true;
    }

    public void LoadRomAndSave(byte[] rom, byte[] sav, string savPath)
    {
        var bios = gba.Provider.Bios;
        gba = new Gba(new ProviderGba(bios, rom, savPath, AudioReady) { BootBios = true });
        gba.Mem.SaveProvider.LoadSave(sav);
    }
    public void ResetGba()
    {
        byte[] save = gba.Mem.SaveProvider.GetSave();
        ProviderGba p = gba.Provider;
        gba = new Gba(p);
        gba.Mem.SaveProvider.LoadSave(save);
    }

    public void EmulationThreadHandler()
    {
        SDL_Init(SDL_INIT_AUDIO);

        want.channels = 2;
        want.freq = 32768;
        want.samples = SAMPLES_PER_CALLBACK;
        want.format = AUDIO_S16LSB;
        // want.callback = NeedMoreAudioCallback;
        AudioDevice = SDL_OpenAudioDevice(null, 0, ref want, out have, (int)SDL_AUDIO_ALLOW_FORMAT_CHANGE);
        SDL_PauseAudioDevice(AudioDevice, 0);
        while (true)
        {
            ThreadSync.WaitOne();

            int cyclesLeft = 70224 * 4;
            while (cyclesLeft > 0 && !gba.Cpu.Errored)
            {
                cyclesLeft -= (int)gba.Step();
            }

            while (!SyncToAudio && !gba.Cpu.Errored && RunEmulator)
            {
                gba.Step();
                ThreadCyclesQueued = 0;
            }
        }
    }
    IntPtr AudioTempBufPtr = Marshal.AllocHGlobal(16384);
    public uint GetAudioSamplesInQueue()
    {
        return SDL_GetQueuedAudioSize(AudioDevice) / sizeof(short);
    }
    void AudioReady(short[] data)
    {
        // Don't queue audio if too much is in buffer
        if (SyncToAudio || GetAudioSamplesInQueue() < AUDIO_SAMPLE_FULL_THRESHOLD)
        {
            int bytes = sizeof(short) * data.Length;

            Marshal.Copy(data, 0, AudioTempBufPtr, data.Length);

            // Console.WriteLine("Outputting samples to SDL");

            SDL_QueueAudio(AudioDevice, AudioTempBufPtr, (uint)bytes);
        }
    }

    public void RunCycles(int cycles)
    {
        while (cycles > 0 && !gba.Cpu.Errored && RunEmulator)
        {
            cycles -= (int)gba.Step();
        }
    }

    int CyclesLeft;
    public void RunFrame()
    {
        CyclesLeft += FrameCycles;
        while (CyclesLeft > 0 && !gba.Cpu.Errored)
        {
            CyclesLeft -= (int)gba.Step();
        }
    }

    public void RunScanline()
    {
        CyclesLeft += ScanlineCycles;
        while (CyclesLeft > 0 && !gba.Cpu.Errored)
        {
            CyclesLeft -= (int)gba.Step();
        }
    }

    public void RunAudioSync()
    {
        if (GetAudioSamplesInQueue() < AUDIO_SAMPLE_THRESHOLD || !SyncToAudio)
        {
            RunFrame();
        }
    }
    public void OnUpdateFrame()
    {

        gba.Keypad.B = Input.GetKey(KeyCode.Z);
        gba.Keypad.A = Input.GetKey(KeyCode.X);
        gba.Keypad.Left = Input.GetKey(KeyCode.LeftArrow);
        gba.Keypad.Up = Input.GetKey(KeyCode.UpArrow);
        gba.Keypad.Right = Input.GetKey(KeyCode.RightArrow);
        gba.Keypad.Down = Input.GetKey(KeyCode.DownArrow);
        gba.Keypad.Start = Input.GetKey(KeyCode.KeypadEnter);
        gba.Keypad.Select = Input.GetKey(KeyCode.Backspace);
        gba.Keypad.L = Input.GetKey(KeyCode.Q);
        gba.Keypad.R = Input.GetKey(KeyCode.E);

        SyncToAudio = !(Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.Space));
        // SyncToAudio = false;

        if (RunEmulator)
        {
            ThreadSync.Set();
        }

        if (gba.Mem.SaveProvider.Dirty)
        {
            DumpSav();
        }
    }
    void OnRenderFrame()
    {
        DrawDisplay();
    }
    public void DumpSav()
    {
        try
        {
            System.IO.File.WriteAllBytesAsync(gba.Provider.SavPath, gba.Mem.SaveProvider.GetSave());
        }
        catch
        {
            Console.WriteLine("Failed to write .sav file!");
        }
    }
    public unsafe void DrawDisplay()
    {
        var buf = ShowBackBuf ? gba.Ppu.Renderer.ScreenBack : gba.Ppu.Renderer.ScreenFront;
        for (uint i = 0; i < 240 * 160; i++)
        {
            DisplayBuffer[i] = PpuRenderer.ColorLutCorrected[buf[i] & 0x7FFF];
            DisplayColorBuffer[i] = new Color32(
                Bits.GetByteIn(DisplayBuffer[i], 0),
                Bits.GetByteIn(DisplayBuffer[i], 1),
                Bits.GetByteIn(DisplayBuffer[i], 2),
                Bits.GetByteIn(DisplayBuffer[i], 3)
                );
        }
        //默认贴图需要反转Y
        Texture2D tex = screen.texture as Texture2D;
        tex.SetPixels32(DisplayColorBuffer);
        tex.Apply(false);
    }
}
