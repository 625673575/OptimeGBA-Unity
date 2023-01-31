using UnityEngine.UI;
using UnityEngine;
using OptimeGBA;
using System.IO;
using System.Runtime.InteropServices;
using System;
using System.Threading;
using Keiwando.NFSO;

public class Emulator : MonoBehaviour
{
    const int FrameCycles = 70224 * 4;
    const int ScanlineCycles = 1232;
    const float FrameRate = 59.7275f;
    static bool SyncToAudio = true;


    public RawImage screen;
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

    private void Awake()
    {
        BetterStreamingAssets.Initialize();
        // must set it to 60 or it won't sync with audio or run too fast.
        Application.targetFrameRate = (int)FrameRate;
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = true;
        audioSource.enabled = false;
        screen.texture = new Texture2D(240, 160, TextureFormat.RGBA32, false);

        // Get Unity Buffer size
        AudioSettings.GetDSPBufferSize(out int bufferLength, out _);
        _samplesAvailable = bufferLength;
        // Must be set to 32768
        AudioSettings.outputSampleRate = GbaAudio.SampleRate;
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
      if (fileWasOpened)
      {
          LoadRom(file.Data, file.Name);
      }
      else
      {
          // The file selection was cancelled.	
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
        gba.Keypad.B = Input.GetKey(KeyCode.Z);
        gba.Keypad.A = Input.GetKey(KeyCode.X);
        gba.Keypad.Left = Input.GetKey(KeyCode.LeftArrow);
        gba.Keypad.Up = Input.GetKey(KeyCode.UpArrow);
        gba.Keypad.Right = Input.GetKey(KeyCode.RightArrow);
        gba.Keypad.Down = Input.GetKey(KeyCode.DownArrow);
        gba.Keypad.Start = Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter);
        gba.Keypad.Select = Input.GetKey(KeyCode.Backspace);
        gba.Keypad.L = Input.GetKey(KeyCode.Q);
        gba.Keypad.R = Input.GetKey(KeyCode.E);
        if (KeyStart)
        {
            gba.Keypad.Start = true;
            KeyStart = false;
        }
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

    #region KeyMap
    public bool KeyStart;
    public void Button_Start()
    {
        KeyStart = true;
    }
    public void Button_A()
    {
        gba.Keypad.A = true;
    }
    public void Button_B()
    {
        gba.Keypad.B = true;
    }
    #endregion
}
