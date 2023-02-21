using UnityEngine.UI;
using UnityEngine;
using OptimeGBA;
using System.IO;
using System;
using System.Threading;
using Keiwando.NFSO;
using System.Runtime.InteropServices;
using UnityEngine.XR;

public class Emulator : MonoBehaviour
{
    const int FrameCycles = 70224 * 4;
    const int ScanlineCycles = 1232;
    const float FrameRate = 59.7275f;
    static bool SyncToAudio = true;


    public Renderer screenRenderer;
    AudioSource audioSource;
    uint[] DisplayBuffer = new uint[240 * 160];
    Color32[] DisplayColorBuffer = new Color32[240 * 160];

    public bool ShowBackBuf = false;
    public bool RunEmulator;
    public bool EnableAudio;
    public bool BootBIOS = false;
    bool RomLoaded = false;

    Gba gba;
    Thread EmulationThread;
    AutoResetEvent ThreadSync = new AutoResetEvent(false);

    private int _samplesAvailable;
    private PipeStream _pipeStream;
    private byte[] _buffer;
    public float audioGain = 1.0f;

    // key delegate
    public delegate bool IsKeyPressed(GBAKeyCode keyCode);
    public IsKeyPressed KeyPressed;

    private void Awake()
    {
        BetterStreamingAssets.Initialize();
        // must set it to 60 or it won't sync with audio or run too fast.
        Application.targetFrameRate = (int)FrameRate;
        audioSource = GetComponent<AudioSource>();
        AudioClip clip = AudioClip.Create("blank", GbaAudio.SampleRate * 2, 2, GbaAudio.SampleRate, true);
        audioSource.clip = clip;
        audioSource.playOnAwake = true;
        audioSource.enabled = false;
        screenRenderer.material.mainTexture = new Texture2D(240, 160, TextureFormat.RGBA32, false, false);

        // Get Unity Buffer size
        AudioSettings.GetDSPBufferSize(out int bufferLength, out _);
        _samplesAvailable = bufferLength;
        // Must be set to 32768
        var audioConfig = AudioSettings.GetConfiguration();
        audioConfig.sampleRate = GbaAudio.SampleRate;
        AudioSettings.Reset(audioConfig);
        // Prepare our buffer
        _pipeStream = new PipeStream();
        _pipeStream.MaxBufferLength = _samplesAvailable * 2 * sizeof(float);
        _buffer = new byte[_samplesAvailable * 2 * sizeof(float)];
    }
    void Start()
    {
        byte[] bios = BetterStreamingAssets.ReadAllBytes("gba_bios.bin");
        Debug.Log(bios.Length);
        gba = new Gba(new ProviderGba(bios, new byte[0], "", AudioReady) { BootBios = BootBIOS });
        EmulationThread = new Thread(EmulationThreadHandler);
        EmulationThread.Name = "Emulation Core";
        EmulationThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (RomLoaded)
        {
            OnRenderFrame();
        }
        OnUpdateFrame();
    }

    public void OpenRom()
    {
        SupportedFileType[] supportedFileTypes = { SupportedFileType.Any };
        NativeFileSO.shared.OpenFile(supportedFileTypes, delegate (bool fileWasOpened, OpenedFile file)
  {
      if (fileWasOpened && file != null)
      {
          LoadRom(file.Data, file.Name);
      }
      else
      {
          // The file selection was cancelled.	
          if (file == null)
              Debug.LogError("file is null");
          else
              Debug.LogError($"Open file failed{file.Name}");
      }
  });
    }
    public void LoadRom(byte[] rom, string name)
    {
        string savPath = Application.persistentDataPath + "/" + name.Substring(0, name.Length - 3) + "sav";
        byte[] sav = new byte[0];
        if (File.Exists(savPath))
        {
            Debug.Log($"{savPath} exists, loading");
            try
            {
                sav = File.ReadAllBytes(savPath);
            }
            catch
            {
                Debug.Log("Failed to load .sav file!");
            }
        }
        else
        {
            Debug.Log(".sav not available");
        }

        LoadRomAndSave(rom, sav, savPath);
        Debug.Log("Load Rom Success");
        audioSource.enabled = true;
        RomLoaded = true;
        RunEmulator = true;
    }

    public void LoadRomAndSave(byte[] rom, byte[] sav, string savPath)
    {
        var bios = gba.Provider.Bios;
        gba = new Gba(new ProviderGba(bios, rom, savPath, AudioReady) { BootBios = BootBIOS });
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
            }
        }
    }

    public int GetOutputSampleRate()
    {
        return AudioSettings.outputSampleRate;
    }

    public int GetSamplesAvailable()
    {
        return _samplesAvailable;
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        if (!EnableAudio) return;

        int r = _pipeStream.Read(_buffer, 0, data.Length * sizeof(float));
        float[] pcm = CoreUtil.ByteToFloatArray(_buffer);
        Array.Copy(pcm, data, data.Length);
    }

    void AudioReady(float[] data)
    {
        if (!EnableAudio) return;
        byte[] bin = CoreUtil.FloatArrayToByteBuffer(data);
        _pipeStream.Write(bin, 0, bin.Length);
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


    public void OnUpdateFrame()
    {
        gba.Keypad.B = KeyPressed(GBAKeyCode.B);
        gba.Keypad.A = KeyPressed(GBAKeyCode.A);
        gba.Keypad.Left = KeyPressed(GBAKeyCode.Left);
        gba.Keypad.Up = KeyPressed(GBAKeyCode.Up);
        gba.Keypad.Right = KeyPressed(GBAKeyCode.Right);
        gba.Keypad.Down = KeyPressed(GBAKeyCode.Down);
        gba.Keypad.Start = KeyPressed(GBAKeyCode.Start);
        gba.Keypad.Select = KeyPressed(GBAKeyCode.Select);
        gba.Keypad.L = KeyPressed(GBAKeyCode.L);
        gba.Keypad.R = KeyPressed(GBAKeyCode.R);

        SyncToAudio = !(Input.GetKey(KeyCode.Tab) || Input.GetKey(KeyCode.Space));

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
            File.WriteAllBytesAsync(gba.Provider.SavPath, gba.Mem.SaveProvider.GetSave());
        }
        catch
        {
            Debug.Log("Failed to write .sav file!");
        }
    }
    public void DrawDisplay()
    {
        var buf = ShowBackBuf ? gba.Ppu.Renderer.ScreenBack : gba.Ppu.Renderer.ScreenFront;
        unsafe
        {
            for (uint i = 0; i < 240 * 160; i++)
            {
                DisplayBuffer[i] = PpuRenderer.ColorLutCorrected[buf[i] & 0x7FFF];
                fixed (uint* p = &DisplayBuffer[i])
                {
                    byte* bp = (byte*)p;
                    DisplayColorBuffer[i] = new Color32(*(bp++), *(bp++), *(bp++), *(bp++));
                }
            }
        }

        //默认贴图需要反转Y
        Texture2D tex = screenRenderer.material.mainTexture as Texture2D;
        tex.SetPixels32(DisplayColorBuffer);
        tex.Apply(false);
    }
}
