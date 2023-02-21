using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum GBAKeyCode
{
    Start,
    Select,
    Left,
    Right,
    Up,
    Down,
    A,
    B,
    L,
    R,
}

public class KeyMappingButton : Button, IPointerDownHandler, IPointerUpHandler
{
    public bool pressed { private set; get; }
    public GBAKeyCode keyCode { private set; get; }
    protected override void Awake()
    {
        pressed = false;
        keyCode = System.Enum.Parse<GBAKeyCode>(gameObject.name);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        pressed = true;
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        pressed = false;
    }
}
