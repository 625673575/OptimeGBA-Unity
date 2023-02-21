using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmulatorGUI : MonoBehaviour
{
    private Dictionary<GBAKeyCode, KeyCode> keyboardKeyCodeMap;
    private Emulator emulator;
    public KeyMappingButton[] buttons;
    private Dictionary<GBAKeyCode, KeyMappingButton> keyMap;

    void Start()
    {
        keyboardKeyCodeMap = new Dictionary<GBAKeyCode, KeyCode>()
        {
            { GBAKeyCode.Start,KeyCode.Return},
            { GBAKeyCode.Select,KeyCode.Backspace},
            { GBAKeyCode.Left,KeyCode.A},
            { GBAKeyCode.Right,KeyCode.D},
            { GBAKeyCode.Up,KeyCode.W},
            { GBAKeyCode.Down,KeyCode.S},
            { GBAKeyCode.A,KeyCode.J},
            { GBAKeyCode.B,KeyCode.K},
            { GBAKeyCode.L,KeyCode.U},
            { GBAKeyCode.R,KeyCode.I},
            };
        emulator = GameObject.FindObjectOfType<Emulator>();
        emulator.KeyPressed += GetKey;

        keyMap = new Dictionary<GBAKeyCode, KeyMappingButton>();
        foreach (var button in buttons)
        {
            keyMap.Add(button.keyCode, button);
        }
    }
    public bool GetKey(GBAKeyCode keyCode)
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        bool input = Input.GetKey( keyboardKeyCodeMap[keyCode]);
        if(input) return true;
#endif
        return keyMap[keyCode].pressed;
    }
}
