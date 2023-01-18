#region 程序集 SDL2-CS, Version=2.0.8.0, Culture=neutral, PublicKeyToken=null
// C:\Users\liuhongwei01\.nuget\packages\sdl2-cs.netcore\2.0.8\lib\netstandard2.0\SDL2-CS.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SDL2
{
    public static class SDL
    {
        public enum SDL_bool
        {
            SDL_FALSE,
            SDL_TRUE
        }

        public delegate int SDL_WinRT_mainFunction(int argc, IntPtr[] argv);

        public enum SDL_HintPriority
        {
            SDL_HINT_DEFAULT,
            SDL_HINT_NORMAL,
            SDL_HINT_OVERRIDE
        }

        public enum SDL_LogPriority
        {
            SDL_LOG_PRIORITY_VERBOSE = 1,
            SDL_LOG_PRIORITY_DEBUG,
            SDL_LOG_PRIORITY_INFO,
            SDL_LOG_PRIORITY_WARN,
            SDL_LOG_PRIORITY_ERROR,
            SDL_LOG_PRIORITY_CRITICAL,
            SDL_NUM_LOG_PRIORITIES
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SDL_LogOutputFunction(IntPtr userdata, int category, SDL_LogPriority priority, IntPtr message);

        [Flags]
        public enum SDL_MessageBoxFlags : uint
        {
            SDL_MESSAGEBOX_ERROR = 0x10u,
            SDL_MESSAGEBOX_WARNING = 0x20u,
            SDL_MESSAGEBOX_INFORMATION = 0x40u
        }

        [Flags]
        public enum SDL_MessageBoxButtonFlags : uint
        {
            SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT = 0x1u,
            SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT = 0x2u
        }

        private struct INTERNAL_SDL_MessageBoxButtonData
        {
            public SDL_MessageBoxButtonFlags flags;

            public int buttonid;

            public IntPtr text;
        }

        public struct SDL_MessageBoxButtonData
        {
            public SDL_MessageBoxButtonFlags flags;

            public int buttonid;

            public string text;
        }

        public struct SDL_MessageBoxColor
        {
            public byte r;

            public byte g;

            public byte b;
        }

        public enum SDL_MessageBoxColorType
        {
            SDL_MESSAGEBOX_COLOR_BACKGROUND,
            SDL_MESSAGEBOX_COLOR_TEXT,
            SDL_MESSAGEBOX_COLOR_BUTTON_BORDER,
            SDL_MESSAGEBOX_COLOR_BUTTON_BACKGROUND,
            SDL_MESSAGEBOX_COLOR_BUTTON_SELECTED,
            SDL_MESSAGEBOX_COLOR_MAX
        }

        public struct SDL_MessageBoxColorScheme
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.Struct)]
            public SDL_MessageBoxColor[] colors;
        }

        private struct INTERNAL_SDL_MessageBoxData
        {
            public SDL_MessageBoxFlags flags;

            public IntPtr window;

            public IntPtr title;

            public IntPtr message;

            public int numbuttons;

            public IntPtr buttons;

            public IntPtr colorScheme;
        }

        public struct SDL_MessageBoxData
        {
            public SDL_MessageBoxFlags flags;

            public IntPtr window;

            public string title;

            public string message;

            public int numbuttons;

            public SDL_MessageBoxButtonData[] buttons;

            public SDL_MessageBoxColorScheme? colorScheme;
        }

        public struct SDL_version
        {
            public byte major;

            public byte minor;

            public byte patch;
        }

        public enum SDL_GLattr
        {
            SDL_GL_RED_SIZE,
            SDL_GL_GREEN_SIZE,
            SDL_GL_BLUE_SIZE,
            SDL_GL_ALPHA_SIZE,
            SDL_GL_BUFFER_SIZE,
            SDL_GL_DOUBLEBUFFER,
            SDL_GL_DEPTH_SIZE,
            SDL_GL_STENCIL_SIZE,
            SDL_GL_ACCUM_RED_SIZE,
            SDL_GL_ACCUM_GREEN_SIZE,
            SDL_GL_ACCUM_BLUE_SIZE,
            SDL_GL_ACCUM_ALPHA_SIZE,
            SDL_GL_STEREO,
            SDL_GL_MULTISAMPLEBUFFERS,
            SDL_GL_MULTISAMPLESAMPLES,
            SDL_GL_ACCELERATED_VISUAL,
            SDL_GL_RETAINED_BACKING,
            SDL_GL_CONTEXT_MAJOR_VERSION,
            SDL_GL_CONTEXT_MINOR_VERSION,
            SDL_GL_CONTEXT_EGL,
            SDL_GL_CONTEXT_FLAGS,
            SDL_GL_CONTEXT_PROFILE_MASK,
            SDL_GL_SHARE_WITH_CURRENT_CONTEXT,
            SDL_GL_FRAMEBUFFER_SRGB_CAPABLE,
            SDL_GL_CONTEXT_RELEASE_BEHAVIOR,
            SDL_GL_CONTEXT_RESET_NOTIFICATION,
            SDL_GL_CONTEXT_NO_ERROR
        }

        [Flags]
        public enum SDL_GLprofile
        {
            SDL_GL_CONTEXT_PROFILE_CORE = 0x1,
            SDL_GL_CONTEXT_PROFILE_COMPATIBILITY = 0x2,
            SDL_GL_CONTEXT_PROFILE_ES = 0x4
        }

        [Flags]
        public enum SDL_GLcontext
        {
            SDL_GL_CONTEXT_DEBUG_FLAG = 0x1,
            SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG = 0x2,
            SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG = 0x4,
            SDL_GL_CONTEXT_RESET_ISOLATION_FLAG = 0x8
        }

        public enum SDL_WindowEventID : byte
        {
            SDL_WINDOWEVENT_NONE,
            SDL_WINDOWEVENT_SHOWN,
            SDL_WINDOWEVENT_HIDDEN,
            SDL_WINDOWEVENT_EXPOSED,
            SDL_WINDOWEVENT_MOVED,
            SDL_WINDOWEVENT_RESIZED,
            SDL_WINDOWEVENT_SIZE_CHANGED,
            SDL_WINDOWEVENT_MINIMIZED,
            SDL_WINDOWEVENT_MAXIMIZED,
            SDL_WINDOWEVENT_RESTORED,
            SDL_WINDOWEVENT_ENTER,
            SDL_WINDOWEVENT_LEAVE,
            SDL_WINDOWEVENT_FOCUS_GAINED,
            SDL_WINDOWEVENT_FOCUS_LOST,
            SDL_WINDOWEVENT_CLOSE,
            SDL_WINDOWEVENT_TAKE_FOCUS,
            SDL_WINDOWEVENT_HIT_TEST
        }

        [Flags]
        public enum SDL_WindowFlags : uint
        {
            SDL_WINDOW_FULLSCREEN = 0x1u,
            SDL_WINDOW_OPENGL = 0x2u,
            SDL_WINDOW_SHOWN = 0x4u,
            SDL_WINDOW_HIDDEN = 0x8u,
            SDL_WINDOW_BORDERLESS = 0x10u,
            SDL_WINDOW_RESIZABLE = 0x20u,
            SDL_WINDOW_MINIMIZED = 0x40u,
            SDL_WINDOW_MAXIMIZED = 0x80u,
            SDL_WINDOW_INPUT_GRABBED = 0x100u,
            SDL_WINDOW_INPUT_FOCUS = 0x200u,
            SDL_WINDOW_MOUSE_FOCUS = 0x400u,
            SDL_WINDOW_FULLSCREEN_DESKTOP = 0x1001u,
            SDL_WINDOW_FOREIGN = 0x800u,
            SDL_WINDOW_ALLOW_HIGHDPI = 0x2000u,
            SDL_WINDOW_MOUSE_CAPTURE = 0x4000u,
            SDL_WINDOW_ALWAYS_ON_TOP = 0x8000u,
            SDL_WINDOW_SKIP_TASKBAR = 0x10000u,
            SDL_WINDOW_UTILITY = 0x20000u,
            SDL_WINDOW_TOOLTIP = 0x40000u,
            SDL_WINDOW_POPUP_MENU = 0x80000u,
            SDL_WINDOW_VULKAN = 0x10000000u
        }

        public enum SDL_HitTestResult
        {
            SDL_HITTEST_NORMAL,
            SDL_HITTEST_DRAGGABLE,
            SDL_HITTEST_RESIZE_TOPLEFT,
            SDL_HITTEST_RESIZE_TOP,
            SDL_HITTEST_RESIZE_TOPRIGHT,
            SDL_HITTEST_RESIZE_RIGHT,
            SDL_HITTEST_RESIZE_BOTTOMRIGHT,
            SDL_HITTEST_RESIZE_BOTTOM,
            SDL_HITTEST_RESIZE_BOTTOMLEFT,
            SDL_HITTEST_RESIZE_LEFT
        }

        public struct SDL_DisplayMode
        {
            public uint format;

            public int w;

            public int h;

            public int refresh_rate;

            public IntPtr driverdata;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate SDL_HitTestResult SDL_HitTest(IntPtr win, IntPtr area, IntPtr data);

        [Flags]
        public enum SDL_BlendMode
        {
            SDL_BLENDMODE_NONE = 0x0,
            SDL_BLENDMODE_BLEND = 0x1,
            SDL_BLENDMODE_ADD = 0x2,
            SDL_BLENDMODE_MOD = 0x4,
            SDL_BLENDMODE_INVALID = int.MaxValue
        }

        public enum SDL_BlendOperation
        {
            SDL_BLENDOPERATION_ADD = 1,
            SDL_BLENDOPERATION_SUBTRACT,
            SDL_BLENDOPERATION_REV_SUBTRACT,
            SDL_BLENDOPERATION_MINIMUM,
            SDL_BLENDOPERATION_MAXIMUM
        }

        public enum SDL_BlendFactor
        {
            SDL_BLENDFACTOR_ZERO = 1,
            SDL_BLENDFACTOR_ONE,
            SDL_BLENDFACTOR_SRC_COLOR,
            SDL_BLENDFACTOR_ONE_MINUS_SRC_COLOR,
            SDL_BLENDFACTOR_SRC_ALPHA,
            SDL_BLENDFACTOR_ONE_MINUS_SRC_ALPHA,
            SDL_BLENDFACTOR_DST_COLOR,
            SDL_BLENDFACTOR_ONE_MINUS_DST_COLOR,
            SDL_BLENDFACTOR_DST_ALPHA,
            SDL_BLENDFACTOR_ONE_MINUS_DST_ALPHA
        }

        [Flags]
        public enum SDL_RendererFlags : uint
        {
            SDL_RENDERER_SOFTWARE = 0x1u,
            SDL_RENDERER_ACCELERATED = 0x2u,
            SDL_RENDERER_PRESENTVSYNC = 0x4u,
            SDL_RENDERER_TARGETTEXTURE = 0x8u
        }

        [Flags]
        public enum SDL_RendererFlip
        {
            SDL_FLIP_NONE = 0x0,
            SDL_FLIP_HORIZONTAL = 0x1,
            SDL_FLIP_VERTICAL = 0x2
        }

        public enum SDL_TextureAccess
        {
            SDL_TEXTUREACCESS_STATIC,
            SDL_TEXTUREACCESS_STREAMING,
            SDL_TEXTUREACCESS_TARGET
        }

        [Flags]
        public enum SDL_TextureModulate
        {
            SDL_TEXTUREMODULATE_NONE = 0x0,
            SDL_TEXTUREMODULATE_HORIZONTAL = 0x1,
            SDL_TEXTUREMODULATE_VERTICAL = 0x2
        }

        public struct SDL_RendererInfo
        {
            public IntPtr name;

            public uint flags;

            public uint num_texture_formats;

            public unsafe fixed uint texture_formats[16];

            public int max_texture_width;

            public int max_texture_height;
        }

        public enum SDL_PIXELTYPE_ENUM
        {
            SDL_PIXELTYPE_UNKNOWN,
            SDL_PIXELTYPE_INDEX1,
            SDL_PIXELTYPE_INDEX4,
            SDL_PIXELTYPE_INDEX8,
            SDL_PIXELTYPE_PACKED8,
            SDL_PIXELTYPE_PACKED16,
            SDL_PIXELTYPE_PACKED32,
            SDL_PIXELTYPE_ARRAYU8,
            SDL_PIXELTYPE_ARRAYU16,
            SDL_PIXELTYPE_ARRAYU32,
            SDL_PIXELTYPE_ARRAYF16,
            SDL_PIXELTYPE_ARRAYF32
        }

        public enum SDL_PIXELORDER_ENUM
        {
            SDL_BITMAPORDER_NONE = 0,
            SDL_BITMAPORDER_4321 = 1,
            SDL_BITMAPORDER_1234 = 2,
            SDL_PACKEDORDER_NONE = 0,
            SDL_PACKEDORDER_XRGB = 1,
            SDL_PACKEDORDER_RGBX = 2,
            SDL_PACKEDORDER_ARGB = 3,
            SDL_PACKEDORDER_RGBA = 4,
            SDL_PACKEDORDER_XBGR = 5,
            SDL_PACKEDORDER_BGRX = 6,
            SDL_PACKEDORDER_ABGR = 7,
            SDL_PACKEDORDER_BGRA = 8,
            SDL_ARRAYORDER_NONE = 0,
            SDL_ARRAYORDER_RGB = 1,
            SDL_ARRAYORDER_RGBA = 2,
            SDL_ARRAYORDER_ARGB = 3,
            SDL_ARRAYORDER_BGR = 4,
            SDL_ARRAYORDER_BGRA = 5,
            SDL_ARRAYORDER_ABGR = 6
        }

        public enum SDL_PACKEDLAYOUT_ENUM
        {
            SDL_PACKEDLAYOUT_NONE,
            SDL_PACKEDLAYOUT_332,
            SDL_PACKEDLAYOUT_4444,
            SDL_PACKEDLAYOUT_1555,
            SDL_PACKEDLAYOUT_5551,
            SDL_PACKEDLAYOUT_565,
            SDL_PACKEDLAYOUT_8888,
            SDL_PACKEDLAYOUT_2101010,
            SDL_PACKEDLAYOUT_1010102
        }

        public struct SDL_Color
        {
            public byte r;

            public byte g;

            public byte b;

            public byte a;
        }

        public struct SDL_Palette
        {
            public int ncolors;

            public IntPtr colors;

            public int version;

            public int refcount;
        }

        public struct SDL_PixelFormat
        {
            public uint format;

            public IntPtr palette;

            public byte BitsPerPixel;

            public byte BytesPerPixel;

            public uint Rmask;

            public uint Gmask;

            public uint Bmask;

            public uint Amask;

            public byte Rloss;

            public byte Gloss;

            public byte Bloss;

            public byte Aloss;

            public byte Rshift;

            public byte Gshift;

            public byte Bshift;

            public byte Ashift;

            public int refcount;

            public IntPtr next;
        }

        public struct SDL_Point
        {
            public int x;

            public int y;
        }

        public struct SDL_Rect
        {
            public int x;

            public int y;

            public int w;

            public int h;
        }

        public struct SDL_Surface
        {
            public uint flags;

            public IntPtr format;

            public int w;

            public int h;

            public int pitch;

            public IntPtr pixels;

            public IntPtr userdata;

            public int locked;

            public IntPtr lock_data;

            public SDL_Rect clip_rect;

            public IntPtr map;

            public int refcount;
        }

        public enum SDL_EventType : uint
        {
            SDL_FIRSTEVENT = 0u,
            SDL_QUIT = 0x100u,
            SDL_WINDOWEVENT = 0x200u,
            SDL_SYSWMEVENT = 513u,
            SDL_KEYDOWN = 768u,
            SDL_KEYUP = 769u,
            SDL_TEXTEDITING = 770u,
            SDL_TEXTINPUT = 771u,
            SDL_MOUSEMOTION = 0x400u,
            SDL_MOUSEBUTTONDOWN = 1025u,
            SDL_MOUSEBUTTONUP = 1026u,
            SDL_MOUSEWHEEL = 1027u,
            SDL_JOYAXISMOTION = 1536u,
            SDL_JOYBALLMOTION = 1537u,
            SDL_JOYHATMOTION = 1538u,
            SDL_JOYBUTTONDOWN = 1539u,
            SDL_JOYBUTTONUP = 1540u,
            SDL_JOYDEVICEADDED = 1541u,
            SDL_JOYDEVICEREMOVED = 1542u,
            SDL_CONTROLLERAXISMOTION = 1616u,
            SDL_CONTROLLERBUTTONDOWN = 1617u,
            SDL_CONTROLLERBUTTONUP = 1618u,
            SDL_CONTROLLERDEVICEADDED = 1619u,
            SDL_CONTROLLERDEVICEREMOVED = 1620u,
            SDL_CONTROLLERDEVICEREMAPPED = 1621u,
            SDL_FINGERDOWN = 1792u,
            SDL_FINGERUP = 1793u,
            SDL_FINGERMOTION = 1794u,
            SDL_DOLLARGESTURE = 0x800u,
            SDL_DOLLARRECORD = 2049u,
            SDL_MULTIGESTURE = 2050u,
            SDL_CLIPBOARDUPDATE = 2304u,
            SDL_DROPFILE = 0x1000u,
            SDL_DROPTEXT = 4097u,
            SDL_DROPBEGIN = 4098u,
            SDL_DROPCOMPLETE = 4099u,
            SDL_AUDIODEVICEADDED = 4352u,
            SDL_AUDIODEVICEREMOVED = 4353u,
            SDL_RENDER_TARGETS_RESET = 0x2000u,
            SDL_RENDER_DEVICE_RESET = 8193u,
            SDL_USEREVENT = 0x8000u,
            SDL_LASTEVENT = 0xFFFFu
        }

        public enum SDL_MouseWheelDirection : uint
        {
            SDL_MOUSEWHEEL_NORMAL,
            SDL_MOUSEWHEEL_FLIPPED
        }

        public struct SDL_GenericEvent
        {
            public SDL_EventType type;

            public uint timestamp;
        }

        public struct SDL_WindowEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public uint windowID;

            public SDL_WindowEventID windowEvent;

            private byte padding1;

            private byte padding2;

            private byte padding3;

            public int data1;

            public int data2;
        }

        public struct SDL_KeyboardEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public uint windowID;

            public byte state;

            public byte repeat;

            private byte padding2;

            private byte padding3;

            public SDL_Keysym keysym;
        }

        public struct SDL_TextEditingEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public uint windowID;

            public unsafe fixed byte text[32];

            public int start;

            public int length;
        }

        public struct SDL_TextInputEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public uint windowID;

            public unsafe fixed byte text[32];
        }

        public struct SDL_MouseMotionEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public uint windowID;

            public uint which;

            public byte state;

            private byte padding1;

            private byte padding2;

            private byte padding3;

            public int x;

            public int y;

            public int xrel;

            public int yrel;
        }

        public struct SDL_MouseButtonEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public uint windowID;

            public uint which;

            public byte button;

            public byte state;

            public byte clicks;

            private byte padding1;

            public int x;

            public int y;
        }

        public struct SDL_MouseWheelEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public uint windowID;

            public uint which;

            public int x;

            public int y;

            public uint direction;
        }

        public struct SDL_JoyAxisEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public int which;

            public byte axis;

            private byte padding1;

            private byte padding2;

            private byte padding3;

            public short axisValue;

            public ushort padding4;
        }

        public struct SDL_JoyBallEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public int which;

            public byte ball;

            private byte padding1;

            private byte padding2;

            private byte padding3;

            public short xrel;

            public short yrel;
        }

        public struct SDL_JoyHatEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public int which;

            public byte hat;

            public byte hatValue;

            private byte padding1;

            private byte padding2;
        }

        public struct SDL_JoyButtonEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public int which;

            public byte button;

            public byte state;

            private byte padding1;

            private byte padding2;
        }

        public struct SDL_JoyDeviceEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public int which;
        }

        public struct SDL_ControllerAxisEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public int which;

            public byte axis;

            private byte padding1;

            private byte padding2;

            private byte padding3;

            public short axisValue;

            private ushort padding4;
        }

        public struct SDL_ControllerButtonEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public int which;

            public byte button;

            public byte state;

            private byte padding1;

            private byte padding2;
        }

        public struct SDL_ControllerDeviceEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public int which;
        }

        public struct SDL_AudioDeviceEvent
        {
            public uint type;

            public uint timestamp;

            public uint which;

            public byte iscapture;

            private byte padding1;

            private byte padding2;

            private byte padding3;
        }

        public struct SDL_TouchFingerEvent
        {
            public uint type;

            public uint timestamp;

            public long touchId;

            public long fingerId;

            public float x;

            public float y;

            public float dx;

            public float dy;

            public float pressure;
        }

        public struct SDL_MultiGestureEvent
        {
            public uint type;

            public uint timestamp;

            public long touchId;

            public float dTheta;

            public float dDist;

            public float x;

            public float y;

            public ushort numFingers;

            public ushort padding;
        }

        public struct SDL_DollarGestureEvent
        {
            public uint type;

            public uint timestamp;

            public long touchId;

            public long gestureId;

            public uint numFingers;

            public float error;

            public float x;

            public float y;
        }

        public struct SDL_DropEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public IntPtr file;
        }

        public struct SDL_QuitEvent
        {
            public SDL_EventType type;

            public uint timestamp;
        }

        public struct SDL_UserEvent
        {
            public uint type;

            public uint timestamp;

            public uint windowID;

            public int code;

            public IntPtr data1;

            public IntPtr data2;
        }

        public struct SDL_SysWMEvent
        {
            public SDL_EventType type;

            public uint timestamp;

            public IntPtr msg;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct SDL_Event
        {
            [FieldOffset(0)]
            public SDL_EventType type;

            [FieldOffset(0)]
            public SDL_WindowEvent window;

            [FieldOffset(0)]
            public SDL_KeyboardEvent key;

            [FieldOffset(0)]
            public SDL_TextEditingEvent edit;

            [FieldOffset(0)]
            public SDL_TextInputEvent text;

            [FieldOffset(0)]
            public SDL_MouseMotionEvent motion;

            [FieldOffset(0)]
            public SDL_MouseButtonEvent button;

            [FieldOffset(0)]
            public SDL_MouseWheelEvent wheel;

            [FieldOffset(0)]
            public SDL_JoyAxisEvent jaxis;

            [FieldOffset(0)]
            public SDL_JoyBallEvent jball;

            [FieldOffset(0)]
            public SDL_JoyHatEvent jhat;

            [FieldOffset(0)]
            public SDL_JoyButtonEvent jbutton;

            [FieldOffset(0)]
            public SDL_JoyDeviceEvent jdevice;

            [FieldOffset(0)]
            public SDL_ControllerAxisEvent caxis;

            [FieldOffset(0)]
            public SDL_ControllerButtonEvent cbutton;

            [FieldOffset(0)]
            public SDL_ControllerDeviceEvent cdevice;

            [FieldOffset(0)]
            public SDL_AudioDeviceEvent adevice;

            [FieldOffset(0)]
            public SDL_QuitEvent quit;

            [FieldOffset(0)]
            public SDL_UserEvent user;

            [FieldOffset(0)]
            public SDL_SysWMEvent syswm;

            [FieldOffset(0)]
            public SDL_TouchFingerEvent tfinger;

            [FieldOffset(0)]
            public SDL_MultiGestureEvent mgesture;

            [FieldOffset(0)]
            public SDL_DollarGestureEvent dgesture;

            [FieldOffset(0)]
            public SDL_DropEvent drop;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SDL_EventFilter(IntPtr userdata, IntPtr sdlevent);

        public enum SDL_eventaction
        {
            SDL_ADDEVENT,
            SDL_PEEKEVENT,
            SDL_GETEVENT
        }

        public enum SDL_Scancode
        {
            SDL_SCANCODE_UNKNOWN = 0,
            SDL_SCANCODE_A = 4,
            SDL_SCANCODE_B = 5,
            SDL_SCANCODE_C = 6,
            SDL_SCANCODE_D = 7,
            SDL_SCANCODE_E = 8,
            SDL_SCANCODE_F = 9,
            SDL_SCANCODE_G = 10,
            SDL_SCANCODE_H = 11,
            SDL_SCANCODE_I = 12,
            SDL_SCANCODE_J = 13,
            SDL_SCANCODE_K = 14,
            SDL_SCANCODE_L = 0xF,
            SDL_SCANCODE_M = 0x10,
            SDL_SCANCODE_N = 17,
            SDL_SCANCODE_O = 18,
            SDL_SCANCODE_P = 19,
            SDL_SCANCODE_Q = 20,
            SDL_SCANCODE_R = 21,
            SDL_SCANCODE_S = 22,
            SDL_SCANCODE_T = 23,
            SDL_SCANCODE_U = 24,
            SDL_SCANCODE_V = 25,
            SDL_SCANCODE_W = 26,
            SDL_SCANCODE_X = 27,
            SDL_SCANCODE_Y = 28,
            SDL_SCANCODE_Z = 29,
            SDL_SCANCODE_1 = 30,
            SDL_SCANCODE_2 = 0x1F,
            SDL_SCANCODE_3 = 0x20,
            SDL_SCANCODE_4 = 33,
            SDL_SCANCODE_5 = 34,
            SDL_SCANCODE_6 = 35,
            SDL_SCANCODE_7 = 36,
            SDL_SCANCODE_8 = 37,
            SDL_SCANCODE_9 = 38,
            SDL_SCANCODE_0 = 39,
            SDL_SCANCODE_RETURN = 40,
            SDL_SCANCODE_ESCAPE = 41,
            SDL_SCANCODE_BACKSPACE = 42,
            SDL_SCANCODE_TAB = 43,
            SDL_SCANCODE_SPACE = 44,
            SDL_SCANCODE_MINUS = 45,
            SDL_SCANCODE_EQUALS = 46,
            SDL_SCANCODE_LEFTBRACKET = 47,
            SDL_SCANCODE_RIGHTBRACKET = 48,
            SDL_SCANCODE_BACKSLASH = 49,
            SDL_SCANCODE_NONUSHASH = 50,
            SDL_SCANCODE_SEMICOLON = 51,
            SDL_SCANCODE_APOSTROPHE = 52,
            SDL_SCANCODE_GRAVE = 53,
            SDL_SCANCODE_COMMA = 54,
            SDL_SCANCODE_PERIOD = 55,
            SDL_SCANCODE_SLASH = 56,
            SDL_SCANCODE_CAPSLOCK = 57,
            SDL_SCANCODE_F1 = 58,
            SDL_SCANCODE_F2 = 59,
            SDL_SCANCODE_F3 = 60,
            SDL_SCANCODE_F4 = 61,
            SDL_SCANCODE_F5 = 62,
            SDL_SCANCODE_F6 = 0x3F,
            SDL_SCANCODE_F7 = 0x40,
            SDL_SCANCODE_F8 = 65,
            SDL_SCANCODE_F9 = 66,
            SDL_SCANCODE_F10 = 67,
            SDL_SCANCODE_F11 = 68,
            SDL_SCANCODE_F12 = 69,
            SDL_SCANCODE_PRINTSCREEN = 70,
            SDL_SCANCODE_SCROLLLOCK = 71,
            SDL_SCANCODE_PAUSE = 72,
            SDL_SCANCODE_INSERT = 73,
            SDL_SCANCODE_HOME = 74,
            SDL_SCANCODE_PAGEUP = 75,
            SDL_SCANCODE_DELETE = 76,
            SDL_SCANCODE_END = 77,
            SDL_SCANCODE_PAGEDOWN = 78,
            SDL_SCANCODE_RIGHT = 79,
            SDL_SCANCODE_LEFT = 80,
            SDL_SCANCODE_DOWN = 81,
            SDL_SCANCODE_UP = 82,
            SDL_SCANCODE_NUMLOCKCLEAR = 83,
            SDL_SCANCODE_KP_DIVIDE = 84,
            SDL_SCANCODE_KP_MULTIPLY = 85,
            SDL_SCANCODE_KP_MINUS = 86,
            SDL_SCANCODE_KP_PLUS = 87,
            SDL_SCANCODE_KP_ENTER = 88,
            SDL_SCANCODE_KP_1 = 89,
            SDL_SCANCODE_KP_2 = 90,
            SDL_SCANCODE_KP_3 = 91,
            SDL_SCANCODE_KP_4 = 92,
            SDL_SCANCODE_KP_5 = 93,
            SDL_SCANCODE_KP_6 = 94,
            SDL_SCANCODE_KP_7 = 95,
            SDL_SCANCODE_KP_8 = 96,
            SDL_SCANCODE_KP_9 = 97,
            SDL_SCANCODE_KP_0 = 98,
            SDL_SCANCODE_KP_PERIOD = 99,
            SDL_SCANCODE_NONUSBACKSLASH = 100,
            SDL_SCANCODE_APPLICATION = 101,
            SDL_SCANCODE_POWER = 102,
            SDL_SCANCODE_KP_EQUALS = 103,
            SDL_SCANCODE_F13 = 104,
            SDL_SCANCODE_F14 = 105,
            SDL_SCANCODE_F15 = 106,
            SDL_SCANCODE_F16 = 107,
            SDL_SCANCODE_F17 = 108,
            SDL_SCANCODE_F18 = 109,
            SDL_SCANCODE_F19 = 110,
            SDL_SCANCODE_F20 = 111,
            SDL_SCANCODE_F21 = 112,
            SDL_SCANCODE_F22 = 113,
            SDL_SCANCODE_F23 = 114,
            SDL_SCANCODE_F24 = 115,
            SDL_SCANCODE_EXECUTE = 116,
            SDL_SCANCODE_HELP = 117,
            SDL_SCANCODE_MENU = 118,
            SDL_SCANCODE_SELECT = 119,
            SDL_SCANCODE_STOP = 120,
            SDL_SCANCODE_AGAIN = 121,
            SDL_SCANCODE_UNDO = 122,
            SDL_SCANCODE_CUT = 123,
            SDL_SCANCODE_COPY = 124,
            SDL_SCANCODE_PASTE = 125,
            SDL_SCANCODE_FIND = 126,
            SDL_SCANCODE_MUTE = 0x7F,
            SDL_SCANCODE_VOLUMEUP = 0x80,
            SDL_SCANCODE_VOLUMEDOWN = 129,
            SDL_SCANCODE_KP_COMMA = 133,
            SDL_SCANCODE_KP_EQUALSAS400 = 134,
            SDL_SCANCODE_INTERNATIONAL1 = 135,
            SDL_SCANCODE_INTERNATIONAL2 = 136,
            SDL_SCANCODE_INTERNATIONAL3 = 137,
            SDL_SCANCODE_INTERNATIONAL4 = 138,
            SDL_SCANCODE_INTERNATIONAL5 = 139,
            SDL_SCANCODE_INTERNATIONAL6 = 140,
            SDL_SCANCODE_INTERNATIONAL7 = 141,
            SDL_SCANCODE_INTERNATIONAL8 = 142,
            SDL_SCANCODE_INTERNATIONAL9 = 143,
            SDL_SCANCODE_LANG1 = 144,
            SDL_SCANCODE_LANG2 = 145,
            SDL_SCANCODE_LANG3 = 146,
            SDL_SCANCODE_LANG4 = 147,
            SDL_SCANCODE_LANG5 = 148,
            SDL_SCANCODE_LANG6 = 149,
            SDL_SCANCODE_LANG7 = 150,
            SDL_SCANCODE_LANG8 = 151,
            SDL_SCANCODE_LANG9 = 152,
            SDL_SCANCODE_ALTERASE = 153,
            SDL_SCANCODE_SYSREQ = 154,
            SDL_SCANCODE_CANCEL = 155,
            SDL_SCANCODE_CLEAR = 156,
            SDL_SCANCODE_PRIOR = 157,
            SDL_SCANCODE_RETURN2 = 158,
            SDL_SCANCODE_SEPARATOR = 159,
            SDL_SCANCODE_OUT = 160,
            SDL_SCANCODE_OPER = 161,
            SDL_SCANCODE_CLEARAGAIN = 162,
            SDL_SCANCODE_CRSEL = 163,
            SDL_SCANCODE_EXSEL = 164,
            SDL_SCANCODE_KP_00 = 176,
            SDL_SCANCODE_KP_000 = 177,
            SDL_SCANCODE_THOUSANDSSEPARATOR = 178,
            SDL_SCANCODE_DECIMALSEPARATOR = 179,
            SDL_SCANCODE_CURRENCYUNIT = 180,
            SDL_SCANCODE_CURRENCYSUBUNIT = 181,
            SDL_SCANCODE_KP_LEFTPAREN = 182,
            SDL_SCANCODE_KP_RIGHTPAREN = 183,
            SDL_SCANCODE_KP_LEFTBRACE = 184,
            SDL_SCANCODE_KP_RIGHTBRACE = 185,
            SDL_SCANCODE_KP_TAB = 186,
            SDL_SCANCODE_KP_BACKSPACE = 187,
            SDL_SCANCODE_KP_A = 188,
            SDL_SCANCODE_KP_B = 189,
            SDL_SCANCODE_KP_C = 190,
            SDL_SCANCODE_KP_D = 191,
            SDL_SCANCODE_KP_E = 192,
            SDL_SCANCODE_KP_F = 193,
            SDL_SCANCODE_KP_XOR = 194,
            SDL_SCANCODE_KP_POWER = 195,
            SDL_SCANCODE_KP_PERCENT = 196,
            SDL_SCANCODE_KP_LESS = 197,
            SDL_SCANCODE_KP_GREATER = 198,
            SDL_SCANCODE_KP_AMPERSAND = 199,
            SDL_SCANCODE_KP_DBLAMPERSAND = 200,
            SDL_SCANCODE_KP_VERTICALBAR = 201,
            SDL_SCANCODE_KP_DBLVERTICALBAR = 202,
            SDL_SCANCODE_KP_COLON = 203,
            SDL_SCANCODE_KP_HASH = 204,
            SDL_SCANCODE_KP_SPACE = 205,
            SDL_SCANCODE_KP_AT = 206,
            SDL_SCANCODE_KP_EXCLAM = 207,
            SDL_SCANCODE_KP_MEMSTORE = 208,
            SDL_SCANCODE_KP_MEMRECALL = 209,
            SDL_SCANCODE_KP_MEMCLEAR = 210,
            SDL_SCANCODE_KP_MEMADD = 211,
            SDL_SCANCODE_KP_MEMSUBTRACT = 212,
            SDL_SCANCODE_KP_MEMMULTIPLY = 213,
            SDL_SCANCODE_KP_MEMDIVIDE = 214,
            SDL_SCANCODE_KP_PLUSMINUS = 215,
            SDL_SCANCODE_KP_CLEAR = 216,
            SDL_SCANCODE_KP_CLEARENTRY = 217,
            SDL_SCANCODE_KP_BINARY = 218,
            SDL_SCANCODE_KP_OCTAL = 219,
            SDL_SCANCODE_KP_DECIMAL = 220,
            SDL_SCANCODE_KP_HEXADECIMAL = 221,
            SDL_SCANCODE_LCTRL = 224,
            SDL_SCANCODE_LSHIFT = 225,
            SDL_SCANCODE_LALT = 226,
            SDL_SCANCODE_LGUI = 227,
            SDL_SCANCODE_RCTRL = 228,
            SDL_SCANCODE_RSHIFT = 229,
            SDL_SCANCODE_RALT = 230,
            SDL_SCANCODE_RGUI = 231,
            SDL_SCANCODE_MODE = 257,
            SDL_SCANCODE_AUDIONEXT = 258,
            SDL_SCANCODE_AUDIOPREV = 259,
            SDL_SCANCODE_AUDIOSTOP = 260,
            SDL_SCANCODE_AUDIOPLAY = 261,
            SDL_SCANCODE_AUDIOMUTE = 262,
            SDL_SCANCODE_MEDIASELECT = 263,
            SDL_SCANCODE_WWW = 264,
            SDL_SCANCODE_MAIL = 265,
            SDL_SCANCODE_CALCULATOR = 266,
            SDL_SCANCODE_COMPUTER = 267,
            SDL_SCANCODE_AC_SEARCH = 268,
            SDL_SCANCODE_AC_HOME = 269,
            SDL_SCANCODE_AC_BACK = 270,
            SDL_SCANCODE_AC_FORWARD = 271,
            SDL_SCANCODE_AC_STOP = 272,
            SDL_SCANCODE_AC_REFRESH = 273,
            SDL_SCANCODE_AC_BOOKMARKS = 274,
            SDL_SCANCODE_BRIGHTNESSDOWN = 275,
            SDL_SCANCODE_BRIGHTNESSUP = 276,
            SDL_SCANCODE_DISPLAYSWITCH = 277,
            SDL_SCANCODE_KBDILLUMTOGGLE = 278,
            SDL_SCANCODE_KBDILLUMDOWN = 279,
            SDL_SCANCODE_KBDILLUMUP = 280,
            SDL_SCANCODE_EJECT = 281,
            SDL_SCANCODE_SLEEP = 282,
            SDL_SCANCODE_APP1 = 283,
            SDL_SCANCODE_APP2 = 284,
            SDL_NUM_SCANCODES = 0x200
        }

        public enum SDL_Keycode
        {
            SDLK_UNKNOWN = 0,
            SDLK_RETURN = 13,
            SDLK_ESCAPE = 27,
            SDLK_BACKSPACE = 8,
            SDLK_TAB = 9,
            SDLK_SPACE = 0x20,
            SDLK_EXCLAIM = 33,
            SDLK_QUOTEDBL = 34,
            SDLK_HASH = 35,
            SDLK_PERCENT = 37,
            SDLK_DOLLAR = 36,
            SDLK_AMPERSAND = 38,
            SDLK_QUOTE = 39,
            SDLK_LEFTPAREN = 40,
            SDLK_RIGHTPAREN = 41,
            SDLK_ASTERISK = 42,
            SDLK_PLUS = 43,
            SDLK_COMMA = 44,
            SDLK_MINUS = 45,
            SDLK_PERIOD = 46,
            SDLK_SLASH = 47,
            SDLK_0 = 48,
            SDLK_1 = 49,
            SDLK_2 = 50,
            SDLK_3 = 51,
            SDLK_4 = 52,
            SDLK_5 = 53,
            SDLK_6 = 54,
            SDLK_7 = 55,
            SDLK_8 = 56,
            SDLK_9 = 57,
            SDLK_COLON = 58,
            SDLK_SEMICOLON = 59,
            SDLK_LESS = 60,
            SDLK_EQUALS = 61,
            SDLK_GREATER = 62,
            SDLK_QUESTION = 0x3F,
            SDLK_AT = 0x40,
            SDLK_LEFTBRACKET = 91,
            SDLK_BACKSLASH = 92,
            SDLK_RIGHTBRACKET = 93,
            SDLK_CARET = 94,
            SDLK_UNDERSCORE = 95,
            SDLK_BACKQUOTE = 96,
            SDLK_a = 97,
            SDLK_b = 98,
            SDLK_c = 99,
            SDLK_d = 100,
            SDLK_e = 101,
            SDLK_f = 102,
            SDLK_g = 103,
            SDLK_h = 104,
            SDLK_i = 105,
            SDLK_j = 106,
            SDLK_k = 107,
            SDLK_l = 108,
            SDLK_m = 109,
            SDLK_n = 110,
            SDLK_o = 111,
            SDLK_p = 112,
            SDLK_q = 113,
            SDLK_r = 114,
            SDLK_s = 115,
            SDLK_t = 116,
            SDLK_u = 117,
            SDLK_v = 118,
            SDLK_w = 119,
            SDLK_x = 120,
            SDLK_y = 121,
            SDLK_z = 122,
            SDLK_CAPSLOCK = 1073741881,
            SDLK_F1 = 1073741882,
            SDLK_F2 = 1073741883,
            SDLK_F3 = 1073741884,
            SDLK_F4 = 1073741885,
            SDLK_F5 = 1073741886,
            SDLK_F6 = 1073741887,
            SDLK_F7 = 1073741888,
            SDLK_F8 = 1073741889,
            SDLK_F9 = 1073741890,
            SDLK_F10 = 1073741891,
            SDLK_F11 = 1073741892,
            SDLK_F12 = 1073741893,
            SDLK_PRINTSCREEN = 1073741894,
            SDLK_SCROLLLOCK = 1073741895,
            SDLK_PAUSE = 1073741896,
            SDLK_INSERT = 1073741897,
            SDLK_HOME = 1073741898,
            SDLK_PAGEUP = 1073741899,
            SDLK_DELETE = 0x7F,
            SDLK_END = 1073741901,
            SDLK_PAGEDOWN = 1073741902,
            SDLK_RIGHT = 1073741903,
            SDLK_LEFT = 1073741904,
            SDLK_DOWN = 1073741905,
            SDLK_UP = 1073741906,
            SDLK_NUMLOCKCLEAR = 1073741907,
            SDLK_KP_DIVIDE = 1073741908,
            SDLK_KP_MULTIPLY = 1073741909,
            SDLK_KP_MINUS = 1073741910,
            SDLK_KP_PLUS = 1073741911,
            SDLK_KP_ENTER = 1073741912,
            SDLK_KP_1 = 1073741913,
            SDLK_KP_2 = 1073741914,
            SDLK_KP_3 = 1073741915,
            SDLK_KP_4 = 1073741916,
            SDLK_KP_5 = 1073741917,
            SDLK_KP_6 = 1073741918,
            SDLK_KP_7 = 1073741919,
            SDLK_KP_8 = 1073741920,
            SDLK_KP_9 = 1073741921,
            SDLK_KP_0 = 1073741922,
            SDLK_KP_PERIOD = 1073741923,
            SDLK_APPLICATION = 1073741925,
            SDLK_POWER = 1073741926,
            SDLK_KP_EQUALS = 1073741927,
            SDLK_F13 = 1073741928,
            SDLK_F14 = 1073741929,
            SDLK_F15 = 1073741930,
            SDLK_F16 = 1073741931,
            SDLK_F17 = 1073741932,
            SDLK_F18 = 1073741933,
            SDLK_F19 = 1073741934,
            SDLK_F20 = 1073741935,
            SDLK_F21 = 1073741936,
            SDLK_F22 = 1073741937,
            SDLK_F23 = 1073741938,
            SDLK_F24 = 1073741939,
            SDLK_EXECUTE = 1073741940,
            SDLK_HELP = 1073741941,
            SDLK_MENU = 1073741942,
            SDLK_SELECT = 1073741943,
            SDLK_STOP = 1073741944,
            SDLK_AGAIN = 1073741945,
            SDLK_UNDO = 1073741946,
            SDLK_CUT = 1073741947,
            SDLK_COPY = 1073741948,
            SDLK_PASTE = 1073741949,
            SDLK_FIND = 1073741950,
            SDLK_MUTE = 1073741951,
            SDLK_VOLUMEUP = 1073741952,
            SDLK_VOLUMEDOWN = 1073741953,
            SDLK_KP_COMMA = 1073741957,
            SDLK_KP_EQUALSAS400 = 1073741958,
            SDLK_ALTERASE = 1073741977,
            SDLK_SYSREQ = 1073741978,
            SDLK_CANCEL = 1073741979,
            SDLK_CLEAR = 1073741980,
            SDLK_PRIOR = 1073741981,
            SDLK_RETURN2 = 1073741982,
            SDLK_SEPARATOR = 1073741983,
            SDLK_OUT = 1073741984,
            SDLK_OPER = 1073741985,
            SDLK_CLEARAGAIN = 1073741986,
            SDLK_CRSEL = 1073741987,
            SDLK_EXSEL = 1073741988,
            SDLK_KP_00 = 1073742000,
            SDLK_KP_000 = 1073742001,
            SDLK_THOUSANDSSEPARATOR = 1073742002,
            SDLK_DECIMALSEPARATOR = 1073742003,
            SDLK_CURRENCYUNIT = 1073742004,
            SDLK_CURRENCYSUBUNIT = 1073742005,
            SDLK_KP_LEFTPAREN = 1073742006,
            SDLK_KP_RIGHTPAREN = 1073742007,
            SDLK_KP_LEFTBRACE = 1073742008,
            SDLK_KP_RIGHTBRACE = 1073742009,
            SDLK_KP_TAB = 1073742010,
            SDLK_KP_BACKSPACE = 1073742011,
            SDLK_KP_A = 1073742012,
            SDLK_KP_B = 1073742013,
            SDLK_KP_C = 1073742014,
            SDLK_KP_D = 1073742015,
            SDLK_KP_E = 1073742016,
            SDLK_KP_F = 1073742017,
            SDLK_KP_XOR = 1073742018,
            SDLK_KP_POWER = 1073742019,
            SDLK_KP_PERCENT = 1073742020,
            SDLK_KP_LESS = 1073742021,
            SDLK_KP_GREATER = 1073742022,
            SDLK_KP_AMPERSAND = 1073742023,
            SDLK_KP_DBLAMPERSAND = 1073742024,
            SDLK_KP_VERTICALBAR = 1073742025,
            SDLK_KP_DBLVERTICALBAR = 1073742026,
            SDLK_KP_COLON = 1073742027,
            SDLK_KP_HASH = 1073742028,
            SDLK_KP_SPACE = 1073742029,
            SDLK_KP_AT = 1073742030,
            SDLK_KP_EXCLAM = 1073742031,
            SDLK_KP_MEMSTORE = 1073742032,
            SDLK_KP_MEMRECALL = 1073742033,
            SDLK_KP_MEMCLEAR = 1073742034,
            SDLK_KP_MEMADD = 1073742035,
            SDLK_KP_MEMSUBTRACT = 1073742036,
            SDLK_KP_MEMMULTIPLY = 1073742037,
            SDLK_KP_MEMDIVIDE = 1073742038,
            SDLK_KP_PLUSMINUS = 1073742039,
            SDLK_KP_CLEAR = 1073742040,
            SDLK_KP_CLEARENTRY = 1073742041,
            SDLK_KP_BINARY = 1073742042,
            SDLK_KP_OCTAL = 1073742043,
            SDLK_KP_DECIMAL = 1073742044,
            SDLK_KP_HEXADECIMAL = 1073742045,
            SDLK_LCTRL = 1073742048,
            SDLK_LSHIFT = 1073742049,
            SDLK_LALT = 1073742050,
            SDLK_LGUI = 1073742051,
            SDLK_RCTRL = 1073742052,
            SDLK_RSHIFT = 1073742053,
            SDLK_RALT = 1073742054,
            SDLK_RGUI = 1073742055,
            SDLK_MODE = 1073742081,
            SDLK_AUDIONEXT = 1073742082,
            SDLK_AUDIOPREV = 1073742083,
            SDLK_AUDIOSTOP = 1073742084,
            SDLK_AUDIOPLAY = 1073742085,
            SDLK_AUDIOMUTE = 1073742086,
            SDLK_MEDIASELECT = 1073742087,
            SDLK_WWW = 1073742088,
            SDLK_MAIL = 1073742089,
            SDLK_CALCULATOR = 1073742090,
            SDLK_COMPUTER = 1073742091,
            SDLK_AC_SEARCH = 1073742092,
            SDLK_AC_HOME = 1073742093,
            SDLK_AC_BACK = 1073742094,
            SDLK_AC_FORWARD = 1073742095,
            SDLK_AC_STOP = 1073742096,
            SDLK_AC_REFRESH = 1073742097,
            SDLK_AC_BOOKMARKS = 1073742098,
            SDLK_BRIGHTNESSDOWN = 1073742099,
            SDLK_BRIGHTNESSUP = 1073742100,
            SDLK_DISPLAYSWITCH = 1073742101,
            SDLK_KBDILLUMTOGGLE = 1073742102,
            SDLK_KBDILLUMDOWN = 1073742103,
            SDLK_KBDILLUMUP = 1073742104,
            SDLK_EJECT = 1073742105,
            SDLK_SLEEP = 1073742106
        }

        [Flags]
        public enum SDL_Keymod : ushort
        {
            KMOD_NONE = 0x0,
            KMOD_LSHIFT = 0x1,
            KMOD_RSHIFT = 0x2,
            KMOD_LCTRL = 0x40,
            KMOD_RCTRL = 0x80,
            KMOD_LALT = 0x100,
            KMOD_RALT = 0x200,
            KMOD_LGUI = 0x400,
            KMOD_RGUI = 0x800,
            KMOD_NUM = 0x1000,
            KMOD_CAPS = 0x2000,
            KMOD_MODE = 0x4000,
            KMOD_RESERVED = 0x8000,
            KMOD_CTRL = 0xC0,
            KMOD_SHIFT = 0x3,
            KMOD_ALT = 0x300,
            KMOD_GUI = 0xC00
        }

        public struct SDL_Keysym
        {
            public SDL_Scancode scancode;

            public SDL_Keycode sym;

            public SDL_Keymod mod;

            public uint unicode;
        }

        public enum SDL_SystemCursor
        {
            SDL_SYSTEM_CURSOR_ARROW,
            SDL_SYSTEM_CURSOR_IBEAM,
            SDL_SYSTEM_CURSOR_WAIT,
            SDL_SYSTEM_CURSOR_CROSSHAIR,
            SDL_SYSTEM_CURSOR_WAITARROW,
            SDL_SYSTEM_CURSOR_SIZENWSE,
            SDL_SYSTEM_CURSOR_SIZENESW,
            SDL_SYSTEM_CURSOR_SIZEWE,
            SDL_SYSTEM_CURSOR_SIZENS,
            SDL_SYSTEM_CURSOR_SIZEALL,
            SDL_SYSTEM_CURSOR_NO,
            SDL_SYSTEM_CURSOR_HAND,
            SDL_NUM_SYSTEM_CURSORS
        }

        public struct SDL_Finger
        {
            public long id;

            public float x;

            public float y;

            public float pressure;
        }

        public enum SDL_JoystickPowerLevel
        {
            SDL_JOYSTICK_POWER_UNKNOWN = -1,
            SDL_JOYSTICK_POWER_EMPTY,
            SDL_JOYSTICK_POWER_LOW,
            SDL_JOYSTICK_POWER_MEDIUM,
            SDL_JOYSTICK_POWER_FULL,
            SDL_JOYSTICK_POWER_WIRED,
            SDL_JOYSTICK_POWER_MAX
        }

        public enum SDL_JoystickType
        {
            SDL_JOYSTICK_TYPE_UNKNOWN,
            SDL_JOYSTICK_TYPE_GAMECONTROLLER,
            SDL_JOYSTICK_TYPE_WHEEL,
            SDL_JOYSTICK_TYPE_ARCADE_STICK,
            SDL_JOYSTICK_TYPE_FLIGHT_STICK,
            SDL_JOYSTICK_TYPE_DANCE_PAD,
            SDL_JOYSTICK_TYPE_GUITAR,
            SDL_JOYSTICK_TYPE_DRUM_KIT,
            SDL_JOYSTICK_TYPE_ARCADE_PAD
        }

        public enum SDL_GameControllerBindType
        {
            SDL_CONTROLLER_BINDTYPE_NONE,
            SDL_CONTROLLER_BINDTYPE_BUTTON,
            SDL_CONTROLLER_BINDTYPE_AXIS,
            SDL_CONTROLLER_BINDTYPE_HAT
        }

        public enum SDL_GameControllerAxis
        {
            SDL_CONTROLLER_AXIS_INVALID = -1,
            SDL_CONTROLLER_AXIS_LEFTX,
            SDL_CONTROLLER_AXIS_LEFTY,
            SDL_CONTROLLER_AXIS_RIGHTX,
            SDL_CONTROLLER_AXIS_RIGHTY,
            SDL_CONTROLLER_AXIS_TRIGGERLEFT,
            SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
            SDL_CONTROLLER_AXIS_MAX
        }

        public enum SDL_GameControllerButton
        {
            SDL_CONTROLLER_BUTTON_INVALID = -1,
            SDL_CONTROLLER_BUTTON_A,
            SDL_CONTROLLER_BUTTON_B,
            SDL_CONTROLLER_BUTTON_X,
            SDL_CONTROLLER_BUTTON_Y,
            SDL_CONTROLLER_BUTTON_BACK,
            SDL_CONTROLLER_BUTTON_GUIDE,
            SDL_CONTROLLER_BUTTON_START,
            SDL_CONTROLLER_BUTTON_LEFTSTICK,
            SDL_CONTROLLER_BUTTON_RIGHTSTICK,
            SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
            SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
            SDL_CONTROLLER_BUTTON_DPAD_UP,
            SDL_CONTROLLER_BUTTON_DPAD_DOWN,
            SDL_CONTROLLER_BUTTON_DPAD_LEFT,
            SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
            SDL_CONTROLLER_BUTTON_MAX
        }

        public struct INTERNAL_GameControllerButtonBind_hat
        {
            public int hat;

            public int hat_mask;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct INTERNAL_GameControllerButtonBind_union
        {
            [FieldOffset(0)]
            public int button;

            [FieldOffset(0)]
            public int axis;

            [FieldOffset(0)]
            public INTERNAL_GameControllerButtonBind_hat hat;
        }

        public struct SDL_GameControllerButtonBind
        {
            public SDL_GameControllerBindType bindType;

            public INTERNAL_GameControllerButtonBind_union value;
        }

        private struct INTERNAL_SDL_GameControllerButtonBind
        {
            public int bindType;

            public int unionVal0;

            public int unionVal1;
        }

        public struct SDL_HapticDirection
        {
            public byte type;

            public unsafe fixed int dir[3];
        }

        public struct SDL_HapticConstant
        {
            public ushort type;

            public SDL_HapticDirection direction;

            public uint length;

            public ushort delay;

            public ushort button;

            public ushort interval;

            public short level;

            public ushort attack_length;

            public ushort attack_level;

            public ushort fade_length;

            public ushort fade_level;
        }

        public struct SDL_HapticPeriodic
        {
            public ushort type;

            public SDL_HapticDirection direction;

            public uint length;

            public ushort delay;

            public ushort button;

            public ushort interval;

            public ushort period;

            public short magnitude;

            public short offset;

            public ushort phase;

            public ushort attack_length;

            public ushort attack_level;

            public ushort fade_length;

            public ushort fade_level;
        }

        public struct SDL_HapticCondition
        {
            public ushort type;

            public SDL_HapticDirection direction;

            public uint length;

            public ushort delay;

            public ushort button;

            public ushort interval;

            public unsafe fixed ushort right_sat[3];

            public unsafe fixed ushort left_sat[3];

            public unsafe fixed short right_coeff[3];

            public unsafe fixed short left_coeff[3];

            public unsafe fixed ushort deadband[3];

            public unsafe fixed short center[3];
        }

        public struct SDL_HapticRamp
        {
            public ushort type;

            public SDL_HapticDirection direction;

            public uint length;

            public ushort delay;

            public ushort button;

            public ushort interval;

            public short start;

            public short end;

            public ushort attack_length;

            public ushort attack_level;

            public ushort fade_length;

            public ushort fade_level;
        }

        public struct SDL_HapticLeftRight
        {
            public ushort type;

            public uint length;

            public ushort large_magnitude;

            public ushort small_magnitude;
        }

        public struct SDL_HapticCustom
        {
            public ushort type;

            public SDL_HapticDirection direction;

            public uint length;

            public ushort delay;

            public ushort button;

            public ushort interval;

            public byte channels;

            public ushort period;

            public ushort samples;

            public IntPtr data;

            public ushort attack_length;

            public ushort attack_level;

            public ushort fade_length;

            public ushort fade_level;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct SDL_HapticEffect
        {
            [FieldOffset(0)]
            public ushort type;

            [FieldOffset(0)]
            public SDL_HapticConstant constant;

            [FieldOffset(0)]
            public SDL_HapticPeriodic periodic;

            [FieldOffset(0)]
            public SDL_HapticCondition condition;

            [FieldOffset(0)]
            public SDL_HapticRamp ramp;

            [FieldOffset(0)]
            public SDL_HapticLeftRight leftright;

            [FieldOffset(0)]
            public SDL_HapticCustom custom;
        }

        public enum SDL_AudioStatus
        {
            SDL_AUDIO_STOPPED,
            SDL_AUDIO_PLAYING,
            SDL_AUDIO_PAUSED
        }

        public struct SDL_AudioSpec
        {
            public int freq;

            public ushort format;

            public byte channels;

            public byte silence;

            public ushort samples;

            public uint size;

            public SDL_AudioCallback callback;

            public IntPtr userdata;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SDL_AudioCallback(IntPtr userdata, IntPtr stream, int len);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint SDL_TimerCallback(uint interval, IntPtr param);

        public enum SDL_SYSWM_TYPE
        {
            SDL_SYSWM_UNKNOWN,
            SDL_SYSWM_WINDOWS,
            SDL_SYSWM_X11,
            SDL_SYSWM_DIRECTFB,
            SDL_SYSWM_COCOA,
            SDL_SYSWM_UIKIT,
            SDL_SYSWM_WAYLAND,
            SDL_SYSWM_MIR,
            SDL_SYSWM_WINRT,
            SDL_SYSWM_ANDROID
        }

        public struct INTERNAL_windows_wminfo
        {
            public IntPtr window;

            public IntPtr hdc;
        }

        public struct INTERNAL_winrt_wminfo
        {
            public IntPtr window;
        }

        public struct INTERNAL_x11_wminfo
        {
            public IntPtr display;

            public IntPtr window;
        }

        public struct INTERNAL_directfb_wminfo
        {
            public IntPtr dfb;

            public IntPtr window;

            public IntPtr surface;
        }

        public struct INTERNAL_cocoa_wminfo
        {
            public IntPtr window;
        }

        public struct INTERNAL_uikit_wminfo
        {
            public IntPtr window;

            public uint framebuffer;

            public uint colorbuffer;

            public uint resolveFramebuffer;
        }

        public struct INTERNAL_wayland_wminfo
        {
            public IntPtr display;

            public IntPtr surface;

            public IntPtr shell_surface;
        }

        public struct INTERNAL_mir_wminfo
        {
            public IntPtr connection;

            public IntPtr surface;
        }

        public struct INTERNAL_android_wminfo
        {
            public IntPtr window;

            public IntPtr surface;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct INTERNAL_SysWMDriverUnion
        {
            [FieldOffset(0)]
            public INTERNAL_windows_wminfo win;

            [FieldOffset(0)]
            public INTERNAL_winrt_wminfo winrt;

            [FieldOffset(0)]
            public INTERNAL_x11_wminfo x11;

            [FieldOffset(0)]
            public INTERNAL_directfb_wminfo dfb;

            [FieldOffset(0)]
            public INTERNAL_cocoa_wminfo cocoa;

            [FieldOffset(0)]
            public INTERNAL_uikit_wminfo uikit;

            [FieldOffset(0)]
            public INTERNAL_wayland_wminfo wl;

            [FieldOffset(0)]
            public INTERNAL_mir_wminfo mir;

            [FieldOffset(0)]
            public INTERNAL_android_wminfo android;
        }

        public struct SDL_SysWMinfo
        {
            public SDL_version version;

            public SDL_SYSWM_TYPE subsystem;

            public INTERNAL_SysWMDriverUnion info;
        }

        public enum SDL_PowerState
        {
            SDL_POWERSTATE_UNKNOWN,
            SDL_POWERSTATE_ON_BATTERY,
            SDL_POWERSTATE_NO_BATTERY,
            SDL_POWERSTATE_CHARGING,
            SDL_POWERSTATE_CHARGED
        }

        private const string nativeLibName = "SDL2.dll";

        public const uint SDL_INIT_TIMER = 1u;

        public const uint SDL_INIT_AUDIO = 16u;

        public const uint SDL_INIT_VIDEO = 32u;

        public const uint SDL_INIT_JOYSTICK = 512u;

        public const uint SDL_INIT_HAPTIC = 4096u;

        public const uint SDL_INIT_GAMECONTROLLER = 8192u;

        public const uint SDL_INIT_NOPARACHUTE = 1048576u;

        public const uint SDL_INIT_EVERYTHING = 12849u;

        public const string SDL_HINT_FRAMEBUFFER_ACCELERATION = "SDL_FRAMEBUFFER_ACCELERATION";

        public const string SDL_HINT_RENDER_DRIVER = "SDL_RENDER_DRIVER";

        public const string SDL_HINT_RENDER_OPENGL_SHADERS = "SDL_RENDER_OPENGL_SHADERS";

        public const string SDL_HINT_RENDER_DIRECT3D_THREADSAFE = "SDL_RENDER_DIRECT3D_THREADSAFE";

        public const string SDL_HINT_RENDER_VSYNC = "SDL_RENDER_VSYNC";

        public const string SDL_HINT_VIDEO_X11_XVIDMODE = "SDL_VIDEO_X11_XVIDMODE";

        public const string SDL_HINT_VIDEO_X11_XINERAMA = "SDL_VIDEO_X11_XINERAMA";

        public const string SDL_HINT_VIDEO_X11_XRANDR = "SDL_VIDEO_X11_XRANDR";

        public const string SDL_HINT_GRAB_KEYBOARD = "SDL_GRAB_KEYBOARD";

        public const string SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS = "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";

        public const string SDL_HINT_IDLE_TIMER_DISABLED = "SDL_IOS_IDLE_TIMER_DISABLED";

        public const string SDL_HINT_ORIENTATIONS = "SDL_IOS_ORIENTATIONS";

        public const string SDL_HINT_XINPUT_ENABLED = "SDL_XINPUT_ENABLED";

        public const string SDL_HINT_GAMECONTROLLERCONFIG = "SDL_GAMECONTROLLERCONFIG";

        public const string SDL_HINT_JOYSTICK_ALLOW_BACKGROUND_EVENTS = "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";

        public const string SDL_HINT_ALLOW_TOPMOST = "SDL_ALLOW_TOPMOST";

        public const string SDL_HINT_TIMER_RESOLUTION = "SDL_TIMER_RESOLUTION";

        public const string SDL_HINT_RENDER_SCALE_QUALITY = "SDL_RENDER_SCALE_QUALITY";

        public const string SDL_HINT_VIDEO_HIGHDPI_DISABLED = "SDL_VIDEO_HIGHDPI_DISABLED";

        public const string SDL_HINT_CTRL_CLICK_EMULATE_RIGHT_CLICK = "SDL_CTRL_CLICK_EMULATE_RIGHT_CLICK";

        public const string SDL_HINT_VIDEO_WIN_D3DCOMPILER = "SDL_VIDEO_WIN_D3DCOMPILER";

        public const string SDL_HINT_MOUSE_RELATIVE_MODE_WARP = "SDL_MOUSE_RELATIVE_MODE_WARP";

        public const string SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT = "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";

        public const string SDL_HINT_VIDEO_ALLOW_SCREENSAVER = "SDL_VIDEO_ALLOW_SCREENSAVER";

        public const string SDL_HINT_ACCELEROMETER_AS_JOYSTICK = "SDL_ACCELEROMETER_AS_JOYSTICK";

        public const string SDL_HINT_VIDEO_MAC_FULLSCREEN_SPACES = "SDL_VIDEO_MAC_FULLSCREEN_SPACES";

        public const string SDL_HINT_WINRT_PRIVACY_POLICY_URL = "SDL_WINRT_PRIVACY_POLICY_URL";

        public const string SDL_HINT_WINRT_PRIVACY_POLICY_LABEL = "SDL_WINRT_PRIVACY_POLICY_LABEL";

        public const string SDL_HINT_WINRT_HANDLE_BACK_BUTTON = "SDL_WINRT_HANDLE_BACK_BUTTON";

        public const string SDL_HINT_NO_SIGNAL_HANDLERS = "SDL_NO_SIGNAL_HANDLERS";

        public const string SDL_HINT_IME_INTERNAL_EDITING = "SDL_IME_INTERNAL_EDITING";

        public const string SDL_HINT_ANDROID_SEPARATE_MOUSE_AND_TOUCH = "SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";

        public const string SDL_HINT_EMSCRIPTEN_KEYBOARD_ELEMENT = "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";

        public const string SDL_HINT_THREAD_STACK_SIZE = "SDL_THREAD_STACK_SIZE";

        public const string SDL_HINT_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN = "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";

        public const string SDL_HINT_WINDOWS_ENABLE_MESSAGELOOP = "SDL_WINDOWS_ENABLE_MESSAGELOOP";

        public const string SDL_HINT_WINDOWS_NO_CLOSE_ON_ALT_F4 = "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";

        public const string SDL_HINT_XINPUT_USE_OLD_JOYSTICK_MAPPING = "SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";

        public const string SDL_HINT_MAC_BACKGROUND_APP = "SDL_MAC_BACKGROUND_APP";

        public const string SDL_HINT_VIDEO_X11_NET_WM_PING = "SDL_VIDEO_X11_NET_WM_PING";

        public const string SDL_HINT_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION = "SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";

        public const string SDL_HINT_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION = "SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";

        public const string SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH = "SDL_MOUSE_FOCUS_CLICKTHROUGH";

        public const string SDL_HINT_BMP_SAVE_LEGACY_FORMAT = "SDL_BMP_SAVE_LEGACY_FORMAT";

        public const string SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING = "SDL_WINDOWS_DISABLE_THREAD_NAMING";

        public const string SDL_HINT_APPLE_TV_REMOTE_ALLOW_ROTATION = "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

        public const string SDL_HINT_AUDIO_RESAMPLING_MODE = "SDL_AUDIO_RESAMPLING_MODE";

        public const string SDL_HINT_RENDER_LOGICAL_SIZE_MODE = "SDL_RENDER_LOGICAL_SIZE_MODE";

        public const string SDL_HINT_MOUSE_NORMAL_SPEED_SCALE = "SDL_MOUSE_NORMAL_SPEED_SCALE";

        public const string SDL_HINT_MOUSE_RELATIVE_SPEED_SCALE = "SDL_MOUSE_RELATIVE_SPEED_SCALE";

        public const string SDL_HINT_TOUCH_MOUSE_EVENTS = "SDL_TOUCH_MOUSE_EVENTS";

        public const string SDL_HINT_WINDOWS_INTRESOURCE_ICON = "SDL_WINDOWS_INTRESOURCE_ICON";

        public const string SDL_HINT_WINDOWS_INTRESOURCE_ICON_SMALL = "SDL_WINDOWS_INTRESOURCE_ICON_SMALL";

        public const int SDL_LOG_CATEGORY_APPLICATION = 0;

        public const int SDL_LOG_CATEGORY_ERROR = 1;

        public const int SDL_LOG_CATEGORY_ASSERT = 2;

        public const int SDL_LOG_CATEGORY_SYSTEM = 3;

        public const int SDL_LOG_CATEGORY_AUDIO = 4;

        public const int SDL_LOG_CATEGORY_VIDEO = 5;

        public const int SDL_LOG_CATEGORY_RENDER = 6;

        public const int SDL_LOG_CATEGORY_INPUT = 7;

        public const int SDL_LOG_CATEGORY_TEST = 8;

        public const int SDL_LOG_CATEGORY_RESERVED1 = 9;

        public const int SDL_LOG_CATEGORY_RESERVED2 = 10;

        public const int SDL_LOG_CATEGORY_RESERVED3 = 11;

        public const int SDL_LOG_CATEGORY_RESERVED4 = 12;

        public const int SDL_LOG_CATEGORY_RESERVED5 = 13;

        public const int SDL_LOG_CATEGORY_RESERVED6 = 14;

        public const int SDL_LOG_CATEGORY_RESERVED7 = 15;

        public const int SDL_LOG_CATEGORY_RESERVED8 = 16;

        public const int SDL_LOG_CATEGORY_RESERVED9 = 17;

        public const int SDL_LOG_CATEGORY_RESERVED10 = 18;

        public const int SDL_LOG_CATEGORY_CUSTOM = 19;

        public const int SDL_MAJOR_VERSION = 2;

        public const int SDL_MINOR_VERSION = 0;

        public const int SDL_PATCHLEVEL = 8;

        public static readonly int SDL_COMPILEDVERSION = SDL_VERSIONNUM(2, 0, 8);

        public const int SDL_WINDOWPOS_UNDEFINED_MASK = 536805376;

        public const int SDL_WINDOWPOS_CENTERED_MASK = 805240832;

        public const int SDL_WINDOWPOS_UNDEFINED = 536805376;

        public const int SDL_WINDOWPOS_CENTERED = 805240832;

        public static readonly uint SDL_PIXELFORMAT_UNKNOWN = 0u;

        public static readonly uint SDL_PIXELFORMAT_INDEX1LSB = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 1, 0);

        public static readonly uint SDL_PIXELFORMAT_INDEX1MSB = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_1234, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 1, 0);

        public static readonly uint SDL_PIXELFORMAT_INDEX4LSB = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 4, 0);

        public static readonly uint SDL_PIXELFORMAT_INDEX4MSB = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_1234, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 4, 0);

        public static readonly uint SDL_PIXELFORMAT_INDEX8 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX8, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_NONE, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 8, 1);

        public static readonly uint SDL_PIXELFORMAT_RGB332 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED8, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_332, 8, 1);

        public static readonly uint SDL_PIXELFORMAT_RGB444 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444, 12, 2);

        public static readonly uint SDL_PIXELFORMAT_RGB555 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555, 15, 2);

        public static readonly uint SDL_PIXELFORMAT_BGR555 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555, 15, 2);

        public static readonly uint SDL_PIXELFORMAT_ARGB4444 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444, 16, 2);

        public static readonly uint SDL_PIXELFORMAT_RGBA4444 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444, 16, 2);

        public static readonly uint SDL_PIXELFORMAT_ABGR4444 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444, 16, 2);

        public static readonly uint SDL_PIXELFORMAT_BGRA4444 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_4444, 16, 2);

        public static readonly uint SDL_PIXELFORMAT_ARGB1555 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555, 16, 2);

        public static readonly uint SDL_PIXELFORMAT_RGBA5551 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_5551, 16, 2);

        public static readonly uint SDL_PIXELFORMAT_ABGR1555 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_1555, 16, 2);

        public static readonly uint SDL_PIXELFORMAT_BGRA5551 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_5551, 16, 2);

        public static readonly uint SDL_PIXELFORMAT_RGB565 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_565, 16, 2);

        public static readonly uint SDL_PIXELFORMAT_BGR565 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED16, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XBGR, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_565, 16, 2);

        public static readonly uint SDL_PIXELFORMAT_RGB24 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_ARRAYU8, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 24, 3);

        public static readonly uint SDL_PIXELFORMAT_BGR24 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_ARRAYU8, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_NONE, 24, 3);

        public static readonly uint SDL_PIXELFORMAT_RGB888 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_4321, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 24, 4);

        public static readonly uint SDL_PIXELFORMAT_RGBX8888 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL_PIXELORDER_ENUM.SDL_BITMAPORDER_1234, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 24, 4);

        public static readonly uint SDL_PIXELFORMAT_BGR888 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_XBGR, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 24, 4);

        public static readonly uint SDL_PIXELFORMAT_BGRX8888 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRX, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 24, 4);

        public static readonly uint SDL_PIXELFORMAT_ARGB8888 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 32, 4);

        public static readonly uint SDL_PIXELFORMAT_RGBA8888 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 32, 4);

        public static readonly uint SDL_PIXELFORMAT_ABGR8888 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 32, 4);

        public static readonly uint SDL_PIXELFORMAT_BGRA8888 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_8888, 32, 4);

        public static readonly uint SDL_PIXELFORMAT_ARGB2101010 = SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_PACKED32, SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB, SDL_PACKEDLAYOUT_ENUM.SDL_PACKEDLAYOUT_2101010, 32, 4);

        public static readonly uint SDL_PIXELFORMAT_YV12 = SDL_DEFINE_PIXELFOURCC(89, 86, 49, 50);

        public static readonly uint SDL_PIXELFORMAT_IYUV = SDL_DEFINE_PIXELFOURCC(73, 89, 85, 86);

        public static readonly uint SDL_PIXELFORMAT_YUY2 = SDL_DEFINE_PIXELFOURCC(89, 85, 89, 50);

        public static readonly uint SDL_PIXELFORMAT_UYVY = SDL_DEFINE_PIXELFOURCC(85, 89, 86, 89);

        public static readonly uint SDL_PIXELFORMAT_YVYU = SDL_DEFINE_PIXELFOURCC(89, 86, 89, 85);

        public const uint SDL_SWSURFACE = 0u;

        public const uint SDL_PREALLOC = 1u;

        public const uint SDL_RLEACCEL = 2u;

        public const uint SDL_DONTFREE = 4u;

        public const byte SDL_PRESSED = 1;

        public const byte SDL_RELEASED = 0;

        public const int SDL_TEXTEDITINGEVENT_TEXT_SIZE = 32;

        public const int SDL_TEXTINPUTEVENT_TEXT_SIZE = 32;

        public const int SDL_QUERY = -1;

        public const int SDL_IGNORE = 0;

        public const int SDL_DISABLE = 0;

        public const int SDL_ENABLE = 1;

        public const int SDLK_SCANCODE_MASK = 1073741824;

        public const uint SDL_BUTTON_LEFT = 1u;

        public const uint SDL_BUTTON_MIDDLE = 2u;

        public const uint SDL_BUTTON_RIGHT = 3u;

        public const uint SDL_BUTTON_X1 = 4u;

        public const uint SDL_BUTTON_X2 = 5u;

        public static readonly uint SDL_BUTTON_LMASK = SDL_BUTTON(1u);

        public static readonly uint SDL_BUTTON_MMASK = SDL_BUTTON(2u);

        public static readonly uint SDL_BUTTON_RMASK = SDL_BUTTON(3u);

        public static readonly uint SDL_BUTTON_X1MASK = SDL_BUTTON(4u);

        public static readonly uint SDL_BUTTON_X2MASK = SDL_BUTTON(5u);

        public const uint SDL_TOUCH_MOUSEID = uint.MaxValue;

        public const byte SDL_HAT_CENTERED = 0;

        public const byte SDL_HAT_UP = 1;

        public const byte SDL_HAT_RIGHT = 2;

        public const byte SDL_HAT_DOWN = 4;

        public const byte SDL_HAT_LEFT = 8;

        public const byte SDL_HAT_RIGHTUP = 3;

        public const byte SDL_HAT_RIGHTDOWN = 6;

        public const byte SDL_HAT_LEFTUP = 9;

        public const byte SDL_HAT_LEFTDOWN = 12;

        public const ushort SDL_HAPTIC_CONSTANT = 1;

        public const ushort SDL_HAPTIC_SINE = 2;

        public const ushort SDL_HAPTIC_LEFTRIGHT = 4;

        public const ushort SDL_HAPTIC_TRIANGLE = 8;

        public const ushort SDL_HAPTIC_SAWTOOTHUP = 16;

        public const ushort SDL_HAPTIC_SAWTOOTHDOWN = 32;

        public const ushort SDL_HAPTIC_SPRING = 128;

        public const ushort SDL_HAPTIC_DAMPER = 256;

        public const ushort SDL_HAPTIC_INERTIA = 512;

        public const ushort SDL_HAPTIC_FRICTION = 1024;

        public const ushort SDL_HAPTIC_CUSTOM = 2048;

        public const ushort SDL_HAPTIC_GAIN = 4096;

        public const ushort SDL_HAPTIC_AUTOCENTER = 8192;

        public const ushort SDL_HAPTIC_STATUS = 16384;

        public const ushort SDL_HAPTIC_PAUSE = 32768;

        public const byte SDL_HAPTIC_POLAR = 0;

        public const byte SDL_HAPTIC_CARTESIAN = 1;

        public const byte SDL_HAPTIC_SPHERICAL = 2;

        public const uint SDL_HAPTIC_INFINITY = 4292967295u;

        public const ushort SDL_AUDIO_MASK_BITSIZE = 255;

        public const ushort SDL_AUDIO_MASK_DATATYPE = 256;

        public const ushort SDL_AUDIO_MASK_ENDIAN = 4096;

        public const ushort SDL_AUDIO_MASK_SIGNED = 32768;

        public const ushort AUDIO_U8 = 8;

        public const ushort AUDIO_S8 = 32776;

        public const ushort AUDIO_U16LSB = 16;

        public const ushort AUDIO_S16LSB = 32784;

        public const ushort AUDIO_U16MSB = 4112;

        public const ushort AUDIO_S16MSB = 36880;

        public const ushort AUDIO_U16 = 16;

        public const ushort AUDIO_S16 = 32784;

        public const ushort AUDIO_S32LSB = 32800;

        public const ushort AUDIO_S32MSB = 36896;

        public const ushort AUDIO_S32 = 32800;

        public const ushort AUDIO_F32LSB = 33056;

        public const ushort AUDIO_F32MSB = 37152;

        public const ushort AUDIO_F32 = 33056;

        public static readonly ushort AUDIO_U16SYS = (ushort)(BitConverter.IsLittleEndian ? 16 : 4112);

        public static readonly ushort AUDIO_S16SYS = (ushort)(BitConverter.IsLittleEndian ? 32784 : 36880);

        public static readonly ushort AUDIO_S32SYS = (ushort)(BitConverter.IsLittleEndian ? 32800 : 36896);

        public static readonly ushort AUDIO_F32SYS = (ushort)(BitConverter.IsLittleEndian ? 33056 : 37152);

        public const uint SDL_AUDIO_ALLOW_FREQUENCY_CHANGE = 1u;

        public const uint SDL_AUDIO_ALLOW_FORMAT_CHANGE = 1u;

        public const uint SDL_AUDIO_ALLOW_CHANNELS_CHANGE = 1u;

        public const uint SDL_AUDIO_ALLOW_ANY_CHANGE = 1u;

        public const int SDL_MIX_MAXVOLUME = 128;

        internal static byte[] UTF8_ToNative(string s)
        {
            if (s == null)
            {
                return null;
            }

            return Encoding.UTF8.GetBytes(s + "\0");
        }

        internal unsafe static string UTF8_ToManaged(IntPtr s, bool freePtr = false)
        {
            if (s == IntPtr.Zero)
            {
                return null;
            }

            byte* ptr;
            for (ptr = (byte*)(void*)s; *ptr != 0; ptr++)
            {
            }

            string @string = Encoding.UTF8.GetString((byte*)(void*)s, (int)(ptr - (byte*)(void*)s));
            if (freePtr)
            {
                SDL_free(s);
            }

            return @string;
        }

        public static uint SDL_FOURCC(byte A, byte B, byte C, byte D)
        {
            return (uint)(A | (B << 8) | (C << 16) | (D << 24));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SDL_malloc(IntPtr size);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SDL_free(IntPtr memblock);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromFile")]
        private static extern IntPtr INTERNAL_SDL_RWFromFile(byte[] file, byte[] mode);

        internal static IntPtr INTERNAL_SDL_RWFromFile(string file, string mode)
        {
            return INTERNAL_SDL_RWFromFile(UTF8_ToNative(file), UTF8_ToNative(mode));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromMem(IntPtr mem, int size);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetMainReady();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WinRTRunApp(SDL_WinRT_mainFunction mainFunction, IntPtr reserved);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_Init(uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_InitSubSystem(uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Quit();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_QuitSubSystem(uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WasInit(uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPlatform")]
        private static extern IntPtr INTERNAL_SDL_GetPlatform();

        public static string SDL_GetPlatform()
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetPlatform());
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearHints();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetHint")]
        private static extern IntPtr INTERNAL_SDL_GetHint(byte[] name);

        public static string SDL_GetHint(string name)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetHint(UTF8_ToNative(name)));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetHint")]
        private static extern SDL_bool INTERNAL_SDL_SetHint(byte[] name, byte[] value);

        public static SDL_bool SDL_SetHint(string name, string value)
        {
            return INTERNAL_SDL_SetHint(UTF8_ToNative(name), UTF8_ToNative(value));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetHintWithPriority")]
        private static extern SDL_bool INTERNAL_SDL_SetHintWithPriority(byte[] name, byte[] value, SDL_HintPriority priority);

        public static SDL_bool SDL_SetHintWithPriority(string name, string value, SDL_HintPriority priority)
        {
            return INTERNAL_SDL_SetHintWithPriority(UTF8_ToNative(name), UTF8_ToNative(value), priority);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetHintBoolean")]
        private static extern SDL_bool INTERNAL_SDL_GetHintBoolean(byte[] name, SDL_bool default_value);

        public static SDL_bool SDL_GetHintBoolean(string name, SDL_bool default_value)
        {
            return INTERNAL_SDL_GetHintBoolean(UTF8_ToNative(name), default_value);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearError();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetError")]
        private static extern IntPtr INTERNAL_SDL_GetError();

        public static string SDL_GetError()
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetError());
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetError")]
        private static extern void INTERNAL_SDL_SetError(byte[] fmtAndArglist);

        public static void SDL_SetError(string fmtAndArglist)
        {
            INTERNAL_SDL_SetError(UTF8_ToNative(fmtAndArglist));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Log")]
        private static extern void INTERNAL_SDL_Log(byte[] fmtAndArglist);

        public static void SDL_Log(string fmtAndArglist)
        {
            INTERNAL_SDL_Log(UTF8_ToNative(fmtAndArglist));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogVerbose")]
        private static extern void INTERNAL_SDL_LogVerbose(int category, byte[] fmtAndArglist);

        public static void SDL_LogVerbose(int category, string fmtAndArglist)
        {
            INTERNAL_SDL_LogVerbose(category, UTF8_ToNative(fmtAndArglist));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogDebug")]
        private static extern void INTERNAL_SDL_LogDebug(int category, byte[] fmtAndArglist);

        public static void SDL_LogDebug(int category, string fmtAndArglist)
        {
            INTERNAL_SDL_LogDebug(category, UTF8_ToNative(fmtAndArglist));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogInfo")]
        private static extern void INTERNAL_SDL_LogInfo(int category, byte[] fmtAndArglist);

        public static void SDL_LogInfo(int category, string fmtAndArglist)
        {
            INTERNAL_SDL_LogInfo(category, UTF8_ToNative(fmtAndArglist));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogWarn")]
        private static extern void INTERNAL_SDL_LogWarn(int category, byte[] fmtAndArglist);

        public static void SDL_LogWarn(int category, string fmtAndArglist)
        {
            INTERNAL_SDL_LogWarn(category, UTF8_ToNative(fmtAndArglist));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogError")]
        private static extern void INTERNAL_SDL_LogError(int category, byte[] fmtAndArglist);

        public static void SDL_LogError(int category, string fmtAndArglist)
        {
            INTERNAL_SDL_LogError(category, UTF8_ToNative(fmtAndArglist));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogCritical")]
        private static extern void INTERNAL_SDL_LogCritical(int category, byte[] fmtAndArglist);

        public static void SDL_LogCritical(int category, string fmtAndArglist)
        {
            INTERNAL_SDL_LogCritical(category, UTF8_ToNative(fmtAndArglist));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogMessage")]
        private static extern void INTERNAL_SDL_LogMessage(int category, SDL_LogPriority priority, byte[] fmtAndArglist);

        public static void SDL_LogMessage(int category, SDL_LogPriority priority, string fmtAndArglist)
        {
            INTERNAL_SDL_LogMessage(category, priority, UTF8_ToNative(fmtAndArglist));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogMessageV")]
        private static extern void INTERNAL_SDL_LogMessageV(int category, SDL_LogPriority priority, byte[] fmtAndArglist);

        public static void SDL_LogMessageV(int category, SDL_LogPriority priority, string fmtAndArglist)
        {
            INTERNAL_SDL_LogMessageV(category, priority, UTF8_ToNative(fmtAndArglist));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_LogPriority SDL_LogGetPriority(int category);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetPriority(int category, SDL_LogPriority priority);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetAllPriority(SDL_LogPriority priority);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogResetPriorities();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_LogGetOutputFunction(out IntPtr callback, out IntPtr userdata);

        public static void SDL_LogGetOutputFunction(out SDL_LogOutputFunction callback, out IntPtr userdata)
        {
            IntPtr callback2 = IntPtr.Zero;
            SDL_LogGetOutputFunction(out callback2, out userdata);
            if (callback2 != IntPtr.Zero)
            {
                callback = (SDL_LogOutputFunction)Marshal.GetDelegateForFunctionPointer(callback2, typeof(SDL_LogOutputFunction));
            }
            else
            {
                callback = null;
            }
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetOutputFunction(SDL_LogOutputFunction callback, IntPtr userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowMessageBox")]
        private static extern int INTERNAL_SDL_ShowMessageBox([In] ref INTERNAL_SDL_MessageBoxData messageboxdata, out int buttonid);

        private static IntPtr INTERNAL_AllocUTF8(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return IntPtr.Zero;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(str + "\0");
            IntPtr intPtr = SDL_malloc((IntPtr)bytes.Length);
            Marshal.Copy(bytes, 0, intPtr, bytes.Length);
            return intPtr;
        }

        public unsafe static int SDL_ShowMessageBox([In] ref SDL_MessageBoxData messageboxdata, out int buttonid)
        {
            INTERNAL_SDL_MessageBoxData iNTERNAL_SDL_MessageBoxData = default(INTERNAL_SDL_MessageBoxData);
            iNTERNAL_SDL_MessageBoxData.flags = messageboxdata.flags;
            iNTERNAL_SDL_MessageBoxData.window = messageboxdata.window;
            iNTERNAL_SDL_MessageBoxData.title = INTERNAL_AllocUTF8(messageboxdata.title);
            iNTERNAL_SDL_MessageBoxData.message = INTERNAL_AllocUTF8(messageboxdata.message);
            iNTERNAL_SDL_MessageBoxData.numbuttons = messageboxdata.numbuttons;
            INTERNAL_SDL_MessageBoxData messageboxdata2 = iNTERNAL_SDL_MessageBoxData;
            INTERNAL_SDL_MessageBoxButtonData[] array = new INTERNAL_SDL_MessageBoxButtonData[messageboxdata.numbuttons];
            for (int i = 0; i < messageboxdata.numbuttons; i++)
            {
                array[i] = new INTERNAL_SDL_MessageBoxButtonData
                {
                    flags = messageboxdata.buttons[i].flags,
                    buttonid = messageboxdata.buttons[i].buttonid,
                    text = INTERNAL_AllocUTF8(messageboxdata.buttons[i].text)
                };
            }

            if (messageboxdata.colorScheme.HasValue)
            {
                messageboxdata2.colorScheme = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SDL_MessageBoxColorScheme)));
                Marshal.StructureToPtr(messageboxdata.colorScheme.Value, messageboxdata2.colorScheme, fDeleteOld: false);
            }

            int result;
            fixed (INTERNAL_SDL_MessageBoxButtonData* ptr = &array[0])
            {
                messageboxdata2.buttons = (IntPtr)ptr;
                result = INTERNAL_SDL_ShowMessageBox(ref messageboxdata2, out buttonid);
            }

            Marshal.FreeHGlobal(messageboxdata2.colorScheme);
            for (int j = 0; j < messageboxdata.numbuttons; j++)
            {
                SDL_free(array[j].text);
            }

            SDL_free(messageboxdata2.message);
            SDL_free(messageboxdata2.title);
            return result;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowSimpleMessageBox")]
        private static extern int INTERNAL_SDL_ShowSimpleMessageBox(SDL_MessageBoxFlags flags, byte[] title, byte[] message, IntPtr window);

        public static int SDL_ShowSimpleMessageBox(SDL_MessageBoxFlags flags, string title, string message, IntPtr window)
        {
            return INTERNAL_SDL_ShowSimpleMessageBox(flags, UTF8_ToNative(title), UTF8_ToNative(message), window);
        }

        public static void SDL_VERSION(out SDL_version x)
        {
            x.major = 2;
            x.minor = 0;
            x.patch = 8;
        }

        public static int SDL_VERSIONNUM(int X, int Y, int Z)
        {
            return X * 1000 + Y * 100 + Z;
        }

        public static bool SDL_VERSION_ATLEAST(int X, int Y, int Z)
        {
            return SDL_COMPILEDVERSION >= SDL_VERSIONNUM(X, Y, Z);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetVersion(out SDL_version ver);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRevision")]
        private static extern IntPtr INTERNAL_SDL_GetRevision();

        public static string SDL_GetRevision()
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetRevision());
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRevisionNumber();

        public static int SDL_WINDOWPOS_UNDEFINED_DISPLAY(int X)
        {
            return 0x1FFF0000 | X;
        }

        public static bool SDL_WINDOWPOS_ISUNDEFINED(int X)
        {
            return (X & 0xFFFF0000u) == 536805376;
        }

        public static int SDL_WINDOWPOS_CENTERED_DISPLAY(int X)
        {
            return 0x2FFF0000 | X;
        }

        public static bool SDL_WINDOWPOS_ISCENTERED(int X)
        {
            return (X & 0xFFFF0000u) == 805240832;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindow")]
        private static extern IntPtr INTERNAL_SDL_CreateWindow(byte[] title, int x, int y, int w, int h, SDL_WindowFlags flags);

        public static IntPtr SDL_CreateWindow(string title, int x, int y, int w, int h, SDL_WindowFlags flags)
        {
            return INTERNAL_SDL_CreateWindow(UTF8_ToNative(title), x, y, w, h, flags);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CreateWindowAndRenderer(int width, int height, SDL_WindowFlags window_flags, out IntPtr window, out IntPtr renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateWindowFrom(IntPtr data);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyWindow(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DisableScreenSaver();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_EnableScreenSaver();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetClosestDisplayMode(int displayIndex, ref SDL_DisplayMode mode, out SDL_DisplayMode closest);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetCurrentDisplayMode(int displayIndex, out SDL_DisplayMode mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentVideoDriver")]
        private static extern IntPtr INTERNAL_SDL_GetCurrentVideoDriver();

        public static string SDL_GetCurrentVideoDriver()
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetCurrentVideoDriver());
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDesktopDisplayMode(int displayIndex, out SDL_DisplayMode mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayName")]
        private static extern IntPtr INTERNAL_SDL_GetDisplayName(int index);

        public static string SDL_GetDisplayName(int index)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetDisplayName(index));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayBounds(int displayIndex, out SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayDPI(int displayIndex, out float ddpi, out float hdpi, out float vdpi);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayMode(int displayIndex, int modeIndex, out SDL_DisplayMode mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayUsableBounds(int displayIndex, out SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumDisplayModes(int displayIndex);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDisplays();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDrivers();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVideoDriver")]
        private static extern IntPtr INTERNAL_SDL_GetVideoDriver(int index);

        public static string SDL_GetVideoDriver(int index)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetVideoDriver(index));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float SDL_GetWindowBrightness(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowOpacity(IntPtr window, float opacity);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowOpacity(IntPtr window, out float out_opacity);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowModalFor(IntPtr modal_window, IntPtr parent_window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowInputFocus(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowData")]
        private static extern IntPtr INTERNAL_SDL_GetWindowData(IntPtr window, byte[] name);

        public static IntPtr SDL_GetWindowData(IntPtr window, string name)
        {
            return INTERNAL_SDL_GetWindowData(window, UTF8_ToNative(name));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayIndex(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayMode(IntPtr window, out SDL_DisplayMode mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowFlags(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowFromID(uint id);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowGammaRamp(IntPtr window, [Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GetWindowGrab(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowID(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowPixelFormat(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowMaximumSize(IntPtr window, out int max_w, out int max_h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowMinimumSize(IntPtr window, out int min_w, out int min_h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowPosition(IntPtr window, out int x, out int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowSize(IntPtr window, out int w, out int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowSurface(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowTitle")]
        private static extern IntPtr INTERNAL_SDL_GetWindowTitle(IntPtr window);

        public static string SDL_GetWindowTitle(IntPtr window)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetWindowTitle(window));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_BindTexture(IntPtr texture, out float texw, out float texh);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_CreateContext(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_DeleteContext(IntPtr context);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetProcAddress")]
        private static extern IntPtr INTERNAL_SDL_GL_GetProcAddress(byte[] proc);

        public static IntPtr SDL_GL_GetProcAddress(string proc)
        {
            return INTERNAL_SDL_GL_GetProcAddress(UTF8_ToNative(proc));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetProcAddress(IntPtr proc);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_ExtensionSupported")]
        private static extern SDL_bool INTERNAL_SDL_GL_ExtensionSupported(byte[] extension);

        public static SDL_bool SDL_GL_ExtensionSupported(string extension)
        {
            return INTERNAL_SDL_GL_ExtensionSupported(UTF8_ToNative(extension));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_ResetAttributes();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetAttribute(SDL_GLattr attr, out int value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetSwapInterval();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_MakeCurrent(IntPtr window, IntPtr context);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetCurrentWindow();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetCurrentContext();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_GetDrawableSize(IntPtr window, out int w, out int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetAttribute(SDL_GLattr attr, int value);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetSwapInterval(int interval);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_SwapWindow(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_UnbindTexture(IntPtr texture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HideWindow(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IsScreenSaverEnabled();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MaximizeWindow(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MinimizeWindow(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RaiseWindow(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RestoreWindow(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowBrightness(IntPtr window, float brightness);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowData")]
        private static extern IntPtr INTERNAL_SDL_SetWindowData(IntPtr window, byte[] name, IntPtr userdata);

        public static IntPtr SDL_SetWindowData(IntPtr window, string name, IntPtr userdata)
        {
            return INTERNAL_SDL_SetWindowData(window, UTF8_ToNative(name), userdata);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowDisplayMode(IntPtr window, ref SDL_DisplayMode mode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowFullscreen(IntPtr window, uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowGammaRamp(IntPtr window, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] blue);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowGrab(IntPtr window, SDL_bool grabbed);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowIcon(IntPtr window, IntPtr icon);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMaximumSize(IntPtr window, int max_w, int max_h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMinimumSize(IntPtr window, int min_w, int min_h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowPosition(IntPtr window, int x, int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowSize(IntPtr window, int w, int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowBordered(IntPtr window, SDL_bool bordered);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowBordersSize(IntPtr window, out int top, out int left, out int bottom, out int right);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowResizable(IntPtr window, SDL_bool resizable);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowTitle")]
        private static extern void INTERNAL_SDL_SetWindowTitle(IntPtr window, byte[] title);

        public static void SDL_SetWindowTitle(IntPtr window, string title)
        {
            INTERNAL_SDL_SetWindowTitle(window, UTF8_ToNative(title));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ShowWindow(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurface(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurfaceRects(IntPtr window, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] SDL_Rect[] rects, int numrects);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_VideoInit")]
        private static extern int INTERNAL_SDL_VideoInit(byte[] driver_name);

        public static int SDL_VideoInit(string driver_name)
        {
            return INTERNAL_SDL_VideoInit(UTF8_ToNative(driver_name));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_VideoQuit();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowHitTest(IntPtr window, SDL_HitTest callback, IntPtr callback_data);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetGrabbedWindow();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_BlendMode SDL_ComposeCustomBlendMode(SDL_BlendFactor srcColorFactor, SDL_BlendFactor dstColorFactor, SDL_BlendOperation colorOperation, SDL_BlendFactor srcAlphaFactor, SDL_BlendFactor dstAlphaFactor, SDL_BlendOperation alphaOperation);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Vulkan_LoadLibrary")]
        private static extern int INTERNAL_SDL_Vulkan_LoadLibrary(byte[] path);

        public static int SDL_Vulkan_LoadLibrary(string path)
        {
            return INTERNAL_SDL_Vulkan_LoadLibrary(UTF8_ToNative(path));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_Vulkan_GetVkGetInstanceProcAddr();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Vulkan_UnloadLibrary();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_Vulkan_GetInstanceExtensions(IntPtr window, out uint pCount, IntPtr[] pNames);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_Vulkan_CreateSurface(IntPtr window, IntPtr instance, out IntPtr surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Vulkan_GetDrawableSize(IntPtr window, out int w, out int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRenderer(IntPtr window, int index, SDL_RendererFlags flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateSoftwareRenderer(IntPtr surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateTexture(IntPtr renderer, uint format, int access, int w, int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateTextureFromSurface(IntPtr renderer, IntPtr surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyRenderer(IntPtr renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyTexture(IntPtr texture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumRenderDrivers();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDrawBlendMode(IntPtr renderer, out SDL_BlendMode blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDriverInfo(int index, out SDL_RendererInfo info);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetRenderer(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRendererInfo(IntPtr renderer, out SDL_RendererInfo info);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRendererOutputSize(IntPtr renderer, out int w, out int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureAlphaMod(IntPtr texture, out byte alpha);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureBlendMode(IntPtr texture, out SDL_BlendMode blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureColorMod(IntPtr texture, out byte r, out byte g, out byte b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTexture(IntPtr texture, ref SDL_Rect rect, out IntPtr pixels, out int pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTexture(IntPtr texture, IntPtr rect, out IntPtr pixels, out int pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_QueryTexture(IntPtr texture, out uint format, out int access, out int w, out int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderClear(IntPtr renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, ref SDL_Rect srcrect, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, IntPtr srcrect, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, ref SDL_Rect srcrect, IntPtr dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, IntPtr srcrect, IntPtr dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, ref SDL_Rect srcrect, ref SDL_Rect dstrect, double angle, ref SDL_Point center, SDL_RendererFlip flip);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcrect, ref SDL_Rect dstrect, double angle, ref SDL_Point center, SDL_RendererFlip flip);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, ref SDL_Rect srcrect, IntPtr dstrect, double angle, ref SDL_Point center, SDL_RendererFlip flip);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, ref SDL_Rect srcrect, ref SDL_Rect dstrect, double angle, IntPtr center, SDL_RendererFlip flip);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcrect, IntPtr dstrect, double angle, ref SDL_Point center, SDL_RendererFlip flip);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcrect, ref SDL_Rect dstrect, double angle, IntPtr center, SDL_RendererFlip flip);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, ref SDL_Rect srcrect, IntPtr dstrect, double angle, IntPtr center, SDL_RendererFlip flip);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, IntPtr srcrect, IntPtr dstrect, double angle, IntPtr center, SDL_RendererFlip flip);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLine(IntPtr renderer, int x1, int y1, int x2, int y2);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLines(IntPtr renderer, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] SDL_Point[] points, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPoint(IntPtr renderer, int x, int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPoints(IntPtr renderer, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] SDL_Point[] points, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRect(IntPtr renderer, ref SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRect(IntPtr renderer, IntPtr rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRects(IntPtr renderer, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] SDL_Rect[] rects, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRect(IntPtr renderer, ref SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRect(IntPtr renderer, IntPtr rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRects(IntPtr renderer, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] SDL_Rect[] rects, int count);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetClipRect(IntPtr renderer, out SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetLogicalSize(IntPtr renderer, out int w, out int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetScale(IntPtr renderer, out float scaleX, out float scaleY);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderGetViewport(IntPtr renderer, out SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderPresent(IntPtr renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderReadPixels(IntPtr renderer, ref SDL_Rect rect, uint format, IntPtr pixels, int pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetClipRect(IntPtr renderer, ref SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetClipRect(IntPtr renderer, IntPtr rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetLogicalSize(IntPtr renderer, int w, int h);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetScale(IntPtr renderer, float scaleX, float scaleY);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetIntegerScale(IntPtr renderer, SDL_bool enable);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetViewport(IntPtr renderer, ref SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderDrawBlendMode(IntPtr renderer, SDL_BlendMode blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderTarget(IntPtr renderer, IntPtr texture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureAlphaMod(IntPtr texture, byte alpha);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureBlendMode(IntPtr texture, SDL_BlendMode blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureColorMod(IntPtr texture, byte r, byte g, byte b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockTexture(IntPtr texture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateTexture(IntPtr texture, ref SDL_Rect rect, IntPtr pixels, int pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateTexture(IntPtr texture, IntPtr rect, IntPtr pixels, int pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_RenderTargetSupported(IntPtr renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetRenderTarget(IntPtr renderer);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_RenderIsClipEnabled(IntPtr renderer);

        public static uint SDL_DEFINE_PIXELFOURCC(byte A, byte B, byte C, byte D)
        {
            return SDL_FOURCC(A, B, C, D);
        }

        public static uint SDL_DEFINE_PIXELFORMAT(SDL_PIXELTYPE_ENUM type, SDL_PIXELORDER_ENUM order, SDL_PACKEDLAYOUT_ENUM layout, byte bits, byte bytes)
        {
            return 0x10000000u | (uint)((byte)type << 24) | (uint)((byte)order << 20) | (uint)((byte)layout << 16) | (uint)(bits << 8) | bytes;
        }

        public static byte SDL_PIXELFLAG(uint X)
        {
            return (byte)((X >> 28) & 0xFu);
        }

        public static byte SDL_PIXELTYPE(uint X)
        {
            return (byte)((X >> 24) & 0xFu);
        }

        public static byte SDL_PIXELORDER(uint X)
        {
            return (byte)((X >> 20) & 0xFu);
        }

        public static byte SDL_PIXELLAYOUT(uint X)
        {
            return (byte)((X >> 16) & 0xFu);
        }

        public static byte SDL_BITSPERPIXEL(uint X)
        {
            return (byte)((X >> 8) & 0xFFu);
        }

        public static byte SDL_BYTESPERPIXEL(uint X)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(X))
            {
                if (X == SDL_PIXELFORMAT_YUY2 || X == SDL_PIXELFORMAT_UYVY || X == SDL_PIXELFORMAT_YVYU)
                {
                    return 2;
                }

                return 1;
            }

            return (byte)(X & 0xFFu);
        }

        public static bool SDL_ISPIXELFORMAT_INDEXED(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                return false;
            }

            SDL_PIXELTYPE_ENUM sDL_PIXELTYPE_ENUM = (SDL_PIXELTYPE_ENUM)SDL_PIXELTYPE(format);
            if (sDL_PIXELTYPE_ENUM != SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX1 && sDL_PIXELTYPE_ENUM != SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX4)
            {
                return sDL_PIXELTYPE_ENUM == SDL_PIXELTYPE_ENUM.SDL_PIXELTYPE_INDEX8;
            }

            return true;
        }

        public static bool SDL_ISPIXELFORMAT_ALPHA(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                return false;
            }

            SDL_PIXELORDER_ENUM sDL_PIXELORDER_ENUM = (SDL_PIXELORDER_ENUM)SDL_PIXELORDER(format);
            if (sDL_PIXELORDER_ENUM != SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ARGB && sDL_PIXELORDER_ENUM != SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_RGBA && sDL_PIXELORDER_ENUM != SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_ABGR)
            {
                return sDL_PIXELORDER_ENUM == SDL_PIXELORDER_ENUM.SDL_PACKEDORDER_BGRA;
            }

            return true;
        }

        public static bool SDL_ISPIXELFORMAT_FOURCC(uint format)
        {
            if (format == 0)
            {
                return SDL_PIXELFLAG(format) != 1;
            }

            return false;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocFormat(uint pixel_format);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocPalette(int ncolors);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CalculateGammaRamp(float gamma, [Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] ramp);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeFormat(IntPtr format);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreePalette(IntPtr palette);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPixelFormatName")]
        private static extern IntPtr INTERNAL_SDL_GetPixelFormatName(uint format);

        public static string SDL_GetPixelFormatName(uint format)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetPixelFormatName(format));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetRGB(uint pixel, IntPtr format, out byte r, out byte g, out byte b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetRGBA(uint pixel, IntPtr format, out byte r, out byte g, out byte b, out byte a);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGB(IntPtr format, byte r, byte g, byte b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGBA(IntPtr format, byte r, byte g, byte b, byte a);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MasksToPixelFormatEnum(int bpp, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_PixelFormatEnumToMasks(uint format, out int bpp, out uint Rmask, out uint Gmask, out uint Bmask, out uint Amask);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetPaletteColors(IntPtr palette, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct)] SDL_Color[] colors, int firstcolor, int ncolors);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetPixelFormatPalette(IntPtr format, IntPtr palette);

        public static SDL_bool SDL_PointInRect(ref SDL_Point p, ref SDL_Rect r)
        {
            if (p.x < r.x || p.x >= r.x + r.w || p.y < r.y || p.y >= r.y + r.h)
            {
                return SDL_bool.SDL_FALSE;
            }

            return SDL_bool.SDL_TRUE;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_EnclosePoints([In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 1)] SDL_Point[] points, int count, ref SDL_Rect clip, out SDL_Rect result);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_HasIntersection(ref SDL_Rect A, ref SDL_Rect B);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IntersectRect(ref SDL_Rect A, ref SDL_Rect B, out SDL_Rect result);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IntersectRectAndLine(ref SDL_Rect rect, ref int X1, ref int Y1, ref int X2, ref int Y2);

        public static SDL_bool SDL_RectEmpty(ref SDL_Rect r)
        {
            if (r.w > 0 && r.h > 0)
            {
                return SDL_bool.SDL_FALSE;
            }

            return SDL_bool.SDL_TRUE;
        }

        public static SDL_bool SDL_RectEquals(ref SDL_Rect a, ref SDL_Rect b)
        {
            if (a.x != b.x || a.y != b.y || a.w != b.w || a.h != b.h)
            {
                return SDL_bool.SDL_FALSE;
            }

            return SDL_bool.SDL_TRUE;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnionRect(ref SDL_Rect A, ref SDL_Rect B, out SDL_Rect result);

        public static bool SDL_MUSTLOCK(IntPtr surface)
        {
            return (((SDL_Surface)Marshal.PtrToStructure(surface, typeof(SDL_Surface))).flags & 2) != 0;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
        public static extern int SDL_BlitSurface(IntPtr src, ref SDL_Rect srcrect, IntPtr dst, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
        public static extern int SDL_BlitSurface(IntPtr src, IntPtr srcrect, IntPtr dst, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
        public static extern int SDL_BlitSurface(IntPtr src, ref SDL_Rect srcrect, IntPtr dst, IntPtr dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
        public static extern int SDL_BlitSurface(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
        public static extern int SDL_BlitScaled(IntPtr src, ref SDL_Rect srcrect, IntPtr dst, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
        public static extern int SDL_BlitScaled(IntPtr src, IntPtr srcrect, IntPtr dst, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
        public static extern int SDL_BlitScaled(IntPtr src, ref SDL_Rect srcrect, IntPtr dst, IntPtr dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
        public static extern int SDL_BlitScaled(IntPtr src, IntPtr srcrect, IntPtr dst, IntPtr dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ConvertPixels(int width, int height, uint src_format, IntPtr src, int src_pitch, uint dst_format, IntPtr dst, int dst_pitch);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_ConvertSurface(IntPtr src, IntPtr fmt, uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_ConvertSurfaceFormat(IntPtr src, uint pixel_format, uint flags);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurface(uint flags, int width, int height, int depth, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth, int pitch, uint Rmask, uint Gmask, uint Bmask, uint Amask);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceWithFormat(uint flags, int width, int height, int depth, uint format);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceWithFormatFrom(IntPtr pixels, int width, int height, int depth, int pitch, uint format);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRect(IntPtr dst, ref SDL_Rect rect, uint color);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRect(IntPtr dst, IntPtr rect, uint color);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRects(IntPtr dst, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] SDL_Rect[] rects, int count, uint color);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeSurface(IntPtr surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetClipRect(IntPtr surface, out SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetColorKey(IntPtr surface, out uint key);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceAlphaMod(IntPtr surface, out byte alpha);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceBlendMode(IntPtr surface, out SDL_BlendMode blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceColorMod(IntPtr surface, out byte r, out byte g, out byte b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadBMP_RW")]
        private static extern IntPtr INTERNAL_SDL_LoadBMP_RW(IntPtr src, int freesrc);

        public static IntPtr SDL_LoadBMP(string file)
        {
            return INTERNAL_SDL_LoadBMP_RW(INTERNAL_SDL_RWFromFile(file, "rb"), 1);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockSurface(IntPtr surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LowerBlit(IntPtr src, ref SDL_Rect srcrect, IntPtr dst, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LowerBlitScaled(IntPtr src, ref SDL_Rect srcrect, IntPtr dst, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SaveBMP_RW")]
        private static extern int INTERNAL_SDL_SaveBMP_RW(IntPtr surface, IntPtr src, int freesrc);

        public static int SDL_SaveBMP(IntPtr surface, string file)
        {
            IntPtr src = INTERNAL_SDL_RWFromFile(file, "wb");
            return INTERNAL_SDL_SaveBMP_RW(surface, src, 1);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_SetClipRect(IntPtr surface, ref SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetColorKey(IntPtr surface, int flag, uint key);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceAlphaMod(IntPtr surface, byte alpha);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceBlendMode(IntPtr surface, SDL_BlendMode blendMode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceColorMod(IntPtr surface, byte r, byte g, byte b);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfacePalette(IntPtr surface, IntPtr palette);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceRLE(IntPtr surface, int flag);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SoftStretch(IntPtr src, ref SDL_Rect srcrect, IntPtr dst, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockSurface(IntPtr surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpperBlit(IntPtr src, ref SDL_Rect srcrect, IntPtr dst, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpperBlitScaled(IntPtr src, ref SDL_Rect srcrect, IntPtr dst, ref SDL_Rect dstrect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_DuplicateSurface(IntPtr surface);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_HasClipboardText();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipboardText")]
        private static extern IntPtr INTERNAL_SDL_GetClipboardText();

        public static string SDL_GetClipboardText()
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetClipboardText());
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetClipboardText")]
        private static extern int INTERNAL_SDL_SetClipboardText(byte[] text);

        public static int SDL_SetClipboardText(string text)
        {
            return INTERNAL_SDL_SetClipboardText(UTF8_ToNative(text));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PumpEvents();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PeepEvents([Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 1)] SDL_Event[] events, int numevents, SDL_eventaction action, SDL_EventType minType, SDL_EventType maxType);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_HasEvent(SDL_EventType type);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_HasEvents(SDL_EventType minType, SDL_EventType maxType);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FlushEvent(SDL_EventType type);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FlushEvents(SDL_EventType min, SDL_EventType max);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PollEvent(out SDL_Event _event);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WaitEvent(out SDL_Event _event);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WaitEventTimeout(out SDL_Event _event, int timeout);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PushEvent(ref SDL_Event _event);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetEventFilter(SDL_EventFilter filter, IntPtr userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern SDL_bool SDL_GetEventFilter(out IntPtr filter, out IntPtr userdata);

        public static SDL_bool SDL_GetEventFilter(out SDL_EventFilter filter, out IntPtr userdata)
        {
            IntPtr filter2 = IntPtr.Zero;
            SDL_bool result = SDL_GetEventFilter(out filter2, out userdata);
            if (filter2 != IntPtr.Zero)
            {
                filter = (SDL_EventFilter)Marshal.GetDelegateForFunctionPointer(filter2, typeof(SDL_EventFilter));
                return result;
            }

            filter = null;
            return result;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AddEventWatch(SDL_EventFilter filter, IntPtr userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DelEventWatch(SDL_EventFilter filter, IntPtr userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FilterEvents(SDL_EventFilter filter, IntPtr userdata);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_EventState(SDL_EventType type, int state);

        public static byte SDL_GetEventState(SDL_EventType type)
        {
            return SDL_EventState(type, -1);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_RegisterEvents(int numevents);

        public static SDL_Keycode SDL_SCANCODE_TO_KEYCODE(SDL_Scancode X)
        {
            return (SDL_Keycode)(X | (SDL_Scancode)1073741824);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetKeyboardFocus();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetKeyboardState(out int numkeys);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Keymod SDL_GetModState();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetModState(SDL_Keymod modstate);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Keycode SDL_GetKeyFromScancode(SDL_Scancode scancode);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_Scancode SDL_GetScancodeFromKey(SDL_Keycode key);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeName")]
        private static extern IntPtr INTERNAL_SDL_GetScancodeName(SDL_Scancode scancode);

        public static string SDL_GetScancodeName(SDL_Scancode scancode)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetScancodeName(scancode));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeFromName")]
        private static extern SDL_Scancode INTERNAL_SDL_GetScancodeFromName(byte[] name);

        public static SDL_Scancode SDL_GetScancodeFromName(string name)
        {
            return INTERNAL_SDL_GetScancodeFromName(UTF8_ToNative(name));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyName")]
        private static extern IntPtr INTERNAL_SDL_GetKeyName(SDL_Keycode key);

        public static string SDL_GetKeyName(SDL_Keycode key)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetKeyName(key));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyFromName")]
        private static extern SDL_Keycode INTERNAL_SDL_GetKeyFromName(byte[] name);

        public static SDL_Keycode SDL_GetKeyFromName(string name)
        {
            return INTERNAL_SDL_GetKeyFromName(UTF8_ToNative(name));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_StartTextInput();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IsTextInputActive();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_StopTextInput();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetTextInputRect(ref SDL_Rect rect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_HasScreenKeyboardSupport();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IsScreenKeyboardShown(IntPtr window);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetMouseFocus();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(out int x, out int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(IntPtr x, out int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(out int x, IntPtr y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(IntPtr x, IntPtr y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(out int x, out int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(IntPtr x, out int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(out int x, IntPtr y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(IntPtr x, IntPtr y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetRelativeMouseState(out int x, out int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_WarpMouseInWindow(IntPtr window, int x, int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WarpMouseGlobal(int x, int y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRelativeMouseMode(SDL_bool enabled);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CaptureMouse(SDL_bool enabled);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GetRelativeMouseMode();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateCursor(IntPtr data, IntPtr mask, int w, int h, int hot_x, int hot_y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateColorCursor(IntPtr surface, int hot_x, int hot_y);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateSystemCursor(SDL_SystemCursor id);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetCursor(IntPtr cursor);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetCursor();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeCursor(IntPtr cursor);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ShowCursor(int toggle);

        public static uint SDL_BUTTON(uint X)
        {
            return (uint)(1 << (int)(X - 1));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumTouchDevices();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_GetTouchDevice(int index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumTouchFingers(long touchID);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetTouchFinger(long touchID, int index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickClose(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickEventState(int state);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_JoystickGetAxis(IntPtr joystick, int axis);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_JoystickGetAxisInitialState(IntPtr joystick, int axis, out ushort state);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetBall(IntPtr joystick, int ball, out int dx, out int dy);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetButton(IntPtr joystick, int button);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetHat(IntPtr joystick, int hat);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickName")]
        private static extern IntPtr INTERNAL_SDL_JoystickName(IntPtr joystick);

        public static string SDL_JoystickName(IntPtr joystick)
        {
            return UTF8_ToManaged(INTERNAL_SDL_JoystickName(joystick));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNameForIndex")]
        private static extern IntPtr INTERNAL_SDL_JoystickNameForIndex(int device_index);

        public static string SDL_JoystickNameForIndex(int device_index)
        {
            return UTF8_ToManaged(INTERNAL_SDL_JoystickNameForIndex(device_index));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumAxes(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumBalls(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumButtons(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumHats(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickOpen(int device_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickUpdate();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumJoysticks();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetDeviceGUID(int device_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetGUID(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickGetGUIDString(Guid guid, byte[] pszGUID, int cbGUID);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetGUIDFromString")]
        private static extern Guid INTERNAL_SDL_JoystickGetGUIDFromString(byte[] pchGUID);

        public static Guid SDL_JoystickGetGUIDFromString(string pchGuid)
        {
            return INTERNAL_SDL_JoystickGetGUIDFromString(UTF8_ToNative(pchGuid));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceVendor(int device_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceProduct(int device_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceProductVersion(int device_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_JoystickType SDL_JoystickGetDeviceType(int device_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetDeviceInstanceID(int device_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetVendor(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetProduct(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetProductVersion(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_JoystickType SDL_JoystickGetType(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_JoystickGetAttached(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickInstanceID(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_JoystickPowerLevel SDL_JoystickCurrentPowerLevel(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickFromInstanceID(int joyid);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockJoysticks();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockJoysticks();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerAddMapping")]
        private static extern int INTERNAL_SDL_GameControllerAddMapping(byte[] mappingString);

        public static int SDL_GameControllerAddMapping(string mappingString)
        {
            return INTERNAL_SDL_GameControllerAddMapping(UTF8_ToNative(mappingString));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerNumMappings();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMappingForIndex")]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForIndex(int mapping_index);

        public static string SDL_GameControllerMappingForIndex(int mapping_index)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GameControllerMappingForIndex(mapping_index));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerAddMappingsFromRW")]
        private static extern int INTERNAL_SDL_GameControllerAddMappingsFromRW(IntPtr rw, int freerw);

        public static int SDL_GameControllerAddMappingsFromFile(string file)
        {
            return INTERNAL_SDL_GameControllerAddMappingsFromRW(INTERNAL_SDL_RWFromFile(file, "rb"), 1);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMappingForGUID")]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForGUID(Guid guid);

        public static string SDL_GameControllerMappingForGUID(Guid guid)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GameControllerMappingForGUID(guid));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMapping")]
        private static extern IntPtr INTERNAL_SDL_GameControllerMapping(IntPtr gamecontroller);

        public static string SDL_GameControllerMapping(IntPtr gamecontroller)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GameControllerMapping(gamecontroller));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_IsGameController(int joystick_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerNameForIndex")]
        private static extern IntPtr INTERNAL_SDL_GameControllerNameForIndex(int joystick_index);

        public static string SDL_GameControllerNameForIndex(int joystick_index)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GameControllerNameForIndex(joystick_index));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerOpen(int joystick_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerName")]
        private static extern IntPtr INTERNAL_SDL_GameControllerName(IntPtr gamecontroller);

        public static string SDL_GameControllerName(IntPtr gamecontroller)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GameControllerName(gamecontroller));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetVendor(IntPtr gamecontroller);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetProduct(IntPtr gamecontroller);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetProductVersion(IntPtr gamecontroller);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GameControllerGetAttached(IntPtr gamecontroller);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerGetJoystick(IntPtr gamecontroller);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerEventState(int state);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerUpdate();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetAxisFromString")]
        private static extern SDL_GameControllerAxis INTERNAL_SDL_GameControllerGetAxisFromString(byte[] pchString);

        public static SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(string pchString)
        {
            return INTERNAL_SDL_GameControllerGetAxisFromString(UTF8_ToNative(pchString));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetStringForAxis")]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForAxis(SDL_GameControllerAxis axis);

        public static string SDL_GameControllerGetStringForAxis(SDL_GameControllerAxis axis)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GameControllerGetStringForAxis(axis));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetBindForAxis")]
        private static extern INTERNAL_SDL_GameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForAxis(IntPtr gamecontroller, SDL_GameControllerAxis axis);

        public static SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(IntPtr gamecontroller, SDL_GameControllerAxis axis)
        {
            INTERNAL_SDL_GameControllerButtonBind iNTERNAL_SDL_GameControllerButtonBind = INTERNAL_SDL_GameControllerGetBindForAxis(gamecontroller, axis);
            SDL_GameControllerButtonBind result = default(SDL_GameControllerButtonBind);
            result.bindType = (SDL_GameControllerBindType)iNTERNAL_SDL_GameControllerButtonBind.bindType;
            result.value.hat.hat = iNTERNAL_SDL_GameControllerButtonBind.unionVal0;
            result.value.hat.hat_mask = iNTERNAL_SDL_GameControllerButtonBind.unionVal1;
            return result;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_GameControllerGetAxis(IntPtr gamecontroller, SDL_GameControllerAxis axis);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetButtonFromString")]
        private static extern SDL_GameControllerButton INTERNAL_SDL_GameControllerGetButtonFromString(byte[] pchString);

        public static SDL_GameControllerButton SDL_GameControllerGetButtonFromString(string pchString)
        {
            return INTERNAL_SDL_GameControllerGetButtonFromString(UTF8_ToNative(pchString));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetStringForButton")]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForButton(SDL_GameControllerButton button);

        public static string SDL_GameControllerGetStringForButton(SDL_GameControllerButton button)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GameControllerGetStringForButton(button));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetBindForButton")]
        private static extern INTERNAL_SDL_GameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForButton(IntPtr gamecontroller, SDL_GameControllerButton button);

        public static SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(IntPtr gamecontroller, SDL_GameControllerButton button)
        {
            INTERNAL_SDL_GameControllerButtonBind iNTERNAL_SDL_GameControllerButtonBind = INTERNAL_SDL_GameControllerGetBindForButton(gamecontroller, button);
            SDL_GameControllerButtonBind result = default(SDL_GameControllerButtonBind);
            result.bindType = (SDL_GameControllerBindType)iNTERNAL_SDL_GameControllerButtonBind.bindType;
            result.value.hat.hat = iNTERNAL_SDL_GameControllerButtonBind.unionVal0;
            result.value.hat.hat_mask = iNTERNAL_SDL_GameControllerButtonBind.unionVal1;
            return result;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_GameControllerGetButton(IntPtr gamecontroller, SDL_GameControllerButton button);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerClose(IntPtr gamecontroller);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerFromInstanceID(int joyid);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HapticClose(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HapticDestroyEffect(IntPtr haptic, int effect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticEffectSupported(IntPtr haptic, ref SDL_HapticEffect effect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticGetEffectStatus(IntPtr haptic, int effect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticIndex(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticName")]
        private static extern IntPtr INTERNAL_SDL_HapticName(int device_index);

        public static string SDL_HapticName(int device_index)
        {
            return UTF8_ToManaged(INTERNAL_SDL_HapticName(device_index));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNewEffect(IntPtr haptic, ref SDL_HapticEffect effect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumAxes(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumEffects(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumEffectsPlaying(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpen(int device_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticOpened(int device_index);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpenFromJoystick(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpenFromMouse();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticPause(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_HapticQuery(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleInit(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumblePlay(IntPtr haptic, float strength, uint length);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleStop(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleSupported(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRunEffect(IntPtr haptic, int effect, uint iterations);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticSetAutocenter(IntPtr haptic, int autocenter);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticSetGain(IntPtr haptic, int gain);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticStopAll(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticStopEffect(IntPtr haptic, int effect);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticUnpause(IntPtr haptic);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticUpdateEffect(IntPtr haptic, int effect, ref SDL_HapticEffect data);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickIsHaptic(IntPtr joystick);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_MouseIsHaptic();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumHaptics();

        public static ushort SDL_AUDIO_BITSIZE(ushort x)
        {
            return (ushort)(x & 0xFFu);
        }

        public static bool SDL_AUDIO_ISFLOAT(ushort x)
        {
            return (x & 0x100) != 0;
        }

        public static bool SDL_AUDIO_ISBIGENDIAN(ushort x)
        {
            return (x & 0x1000) != 0;
        }

        public static bool SDL_AUDIO_ISSIGNED(ushort x)
        {
            return (x & 0x8000) != 0;
        }

        public static bool SDL_AUDIO_ISINT(ushort x)
        {
            return (x & 0x100) == 0;
        }

        public static bool SDL_AUDIO_ISLITTLEENDIAN(ushort x)
        {
            return (x & 0x1000) == 0;
        }

        public static bool SDL_AUDIO_ISUNSIGNED(ushort x)
        {
            return (x & 0x8000) == 0;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AudioInit")]
        private static extern int INTERNAL_SDL_AudioInit(byte[] driver_name);

        public static int SDL_AudioInit(string driver_name)
        {
            return INTERNAL_SDL_AudioInit(UTF8_ToNative(driver_name));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AudioQuit();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseAudio();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseAudioDevice(uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeWAV(IntPtr audio_buf);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDeviceName")]
        private static extern IntPtr INTERNAL_SDL_GetAudioDeviceName(int index, int iscapture);

        public static string SDL_GetAudioDeviceName(int index, int iscapture)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetAudioDeviceName(index, iscapture));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_AudioStatus SDL_GetAudioDeviceStatus(uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDriver")]
        private static extern IntPtr INTERNAL_SDL_GetAudioDriver(int index);

        public static string SDL_GetAudioDriver(int index)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetAudioDriver(index));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_AudioStatus SDL_GetAudioStatus();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentAudioDriver")]
        private static extern IntPtr INTERNAL_SDL_GetCurrentAudioDriver();

        public static string SDL_GetCurrentAudioDriver()
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetCurrentAudioDriver());
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumAudioDevices(int iscapture);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumAudioDrivers();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadWAV_RW")]
        private static extern IntPtr INTERNAL_SDL_LoadWAV_RW(IntPtr src, int freesrc, ref SDL_AudioSpec spec, out IntPtr audio_buf, out uint audio_len);

        public static SDL_AudioSpec SDL_LoadWAV(string file, ref SDL_AudioSpec spec, out IntPtr audio_buf, out uint audio_len)
        {
            return (SDL_AudioSpec)Marshal.PtrToStructure(INTERNAL_SDL_LoadWAV_RW(INTERNAL_SDL_RWFromFile(file, "rb"), 1, ref spec, out audio_buf, out audio_len), typeof(SDL_AudioSpec));
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockAudio();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockAudioDevice(uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudio([Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] dst, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] src, uint len, int volume);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudioFormat([Out][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] byte[] dst, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] byte[] src, ushort format, uint len, int volume);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_OpenAudio(ref SDL_AudioSpec desired, out SDL_AudioSpec obtained);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_OpenAudio(ref SDL_AudioSpec desired, IntPtr obtained);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_OpenAudioDevice")]
        private static extern uint INTERNAL_SDL_OpenAudioDevice(byte[] device, int iscapture, ref SDL_AudioSpec desired, out SDL_AudioSpec obtained, int allowed_changes);

        public static uint SDL_OpenAudioDevice(string device, int iscapture, ref SDL_AudioSpec desired, out SDL_AudioSpec obtained, int allowed_changes)
        {
            return INTERNAL_SDL_OpenAudioDevice(UTF8_ToNative(device), iscapture, ref desired, out obtained, allowed_changes);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PauseAudio(int pause_on);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PauseAudioDevice(uint dev, int pause_on);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockAudio();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockAudioDevice(uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_QueueAudio(uint dev, IntPtr data, uint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_DequeueAudio(uint dev, IntPtr data, uint len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetQueuedAudioSize(uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearQueuedAudio(uint dev);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_NewAudioStream(ushort src_format, byte src_channels, int src_rate, ushort dst_format, byte dst_channels, int dst_rate);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamPut(IntPtr stream, IntPtr buf, int len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamGet(IntPtr stream, IntPtr buf, int len);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamAvailable(IntPtr stream);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AudioStreamClear(IntPtr stream);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeAudioStream(IntPtr stream);

        public static bool SDL_TICKS_PASSED(uint A, uint B)
        {
            return (int)(B - A) <= 0;
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Delay(uint ms);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetTicks();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetPerformanceCounter();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetPerformanceFrequency();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AddTimer(uint interval, SDL_TimerCallback callback, IntPtr param);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_RemoveTimer(int id);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_bool SDL_GetWindowWMInfo(IntPtr window, ref SDL_SysWMinfo info);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetBasePath")]
        private static extern IntPtr INTERNAL_SDL_GetBasePath();

        public static string SDL_GetBasePath()
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetBasePath(), freePtr: true);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPrefPath")]
        private static extern IntPtr INTERNAL_SDL_GetPrefPath(byte[] org, byte[] app);

        public static string SDL_GetPrefPath(string org, string app)
        {
            return UTF8_ToManaged(INTERNAL_SDL_GetPrefPath(UTF8_ToNative(org), UTF8_ToNative(app)), freePtr: true);
        }

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern SDL_PowerState SDL_GetPowerInfo(out int secs, out int pct);

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetCPUCount();

        [DllImport("SDL2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSystemRAM();
    }
}
#if false // 反编译日志
缓存中的 202 项
------------------
解析: "netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
警告: 版本不匹配。应为: "2.0.0.0"，实际为: "2.1.0.0"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\netstandard.dll"
------------------
解析: "System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Runtime.dll"
------------------
解析: "System.IO.MemoryMappedFiles, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.IO.MemoryMappedFiles, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.IO.MemoryMappedFiles.dll"
------------------
解析: "System.IO.Pipes, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.IO.Pipes, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.IO.Pipes.dll"
------------------
解析: "System.Diagnostics.Process, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.Process, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Diagnostics.Process.dll"
------------------
解析: "System.Security.Cryptography, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Security.Cryptography, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Security.Cryptography.dll"
------------------
解析: "System.Memory, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Memory, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Memory.dll"
------------------
解析: "System.Collections, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Collections, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Collections.dll"
------------------
解析: "System.Collections.NonGeneric, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Collections.NonGeneric, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Collections.NonGeneric.dll"
------------------
解析: "System.Collections.Concurrent, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Collections.Concurrent, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Collections.Concurrent.dll"
------------------
解析: "System.ObjectModel, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.ObjectModel, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.ObjectModel.dll"
------------------
解析: "System.Collections.Specialized, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Collections.Specialized, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Collections.Specialized.dll"
------------------
解析: "System.ComponentModel.TypeConverter, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.ComponentModel.TypeConverter, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.ComponentModel.TypeConverter.dll"
------------------
解析: "System.ComponentModel.EventBasedAsync, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.ComponentModel.EventBasedAsync, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.ComponentModel.EventBasedAsync.dll"
------------------
解析: "System.ComponentModel.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.ComponentModel.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.ComponentModel.Primitives.dll"
------------------
解析: "System.ComponentModel, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.ComponentModel, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.ComponentModel.dll"
------------------
解析: "Microsoft.Win32.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "Microsoft.Win32.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\Microsoft.Win32.Primitives.dll"
------------------
解析: "System.Console, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Console, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Console.dll"
------------------
解析: "System.Data.Common, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Data.Common, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Data.Common.dll"
------------------
解析: "System.Runtime.InteropServices, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.InteropServices, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Runtime.InteropServices.dll"
------------------
解析: "System.Diagnostics.TraceSource, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.TraceSource, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Diagnostics.TraceSource.dll"
------------------
解析: "System.Diagnostics.Contracts, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.Contracts, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Diagnostics.Contracts.dll"
------------------
解析: "System.Diagnostics.TextWriterTraceListener, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.TextWriterTraceListener, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Diagnostics.TextWriterTraceListener.dll"
------------------
解析: "System.Diagnostics.FileVersionInfo, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.FileVersionInfo, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Diagnostics.FileVersionInfo.dll"
------------------
解析: "System.Diagnostics.StackTrace, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.StackTrace, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Diagnostics.StackTrace.dll"
------------------
解析: "System.Diagnostics.Tracing, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.Tracing, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Diagnostics.Tracing.dll"
------------------
解析: "System.Drawing.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Drawing.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Drawing.Primitives.dll"
------------------
解析: "System.Linq.Expressions, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Linq.Expressions, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Linq.Expressions.dll"
------------------
解析: "System.IO.Compression.Brotli, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
找到单个程序集: "System.IO.Compression.Brotli, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.IO.Compression.Brotli.dll"
------------------
解析: "System.IO.Compression, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
找到单个程序集: "System.IO.Compression, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.IO.Compression.dll"
------------------
解析: "System.IO.Compression.ZipFile, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
找到单个程序集: "System.IO.Compression.ZipFile, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.IO.Compression.ZipFile.dll"
------------------
解析: "System.IO.FileSystem.DriveInfo, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.IO.FileSystem.DriveInfo, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.IO.FileSystem.DriveInfo.dll"
------------------
解析: "System.IO.FileSystem.Watcher, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.IO.FileSystem.Watcher, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.IO.FileSystem.Watcher.dll"
------------------
解析: "System.IO.IsolatedStorage, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.IO.IsolatedStorage, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.IO.IsolatedStorage.dll"
------------------
解析: "System.Linq, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Linq, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Linq.dll"
------------------
解析: "System.Linq.Queryable, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Linq.Queryable, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Linq.Queryable.dll"
------------------
解析: "System.Linq.Parallel, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Linq.Parallel, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Linq.Parallel.dll"
------------------
解析: "System.Threading.Thread, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Threading.Thread, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Threading.Thread.dll"
------------------
解析: "System.Net.Requests, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.Requests, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.Requests.dll"
------------------
解析: "System.Net.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.Primitives.dll"
------------------
解析: "System.Net.HttpListener, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Net.HttpListener, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.HttpListener.dll"
------------------
解析: "System.Net.ServicePoint, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Net.ServicePoint, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.ServicePoint.dll"
------------------
解析: "System.Net.NameResolution, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.NameResolution, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.NameResolution.dll"
------------------
解析: "System.Net.WebClient, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Net.WebClient, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.WebClient.dll"
------------------
解析: "System.Net.Http, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.Http, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.Http.dll"
------------------
解析: "System.Net.WebHeaderCollection, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.WebHeaderCollection, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.WebHeaderCollection.dll"
------------------
解析: "System.Net.WebProxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Net.WebProxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.WebProxy.dll"
------------------
解析: "System.Net.Mail, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Net.Mail, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.Mail.dll"
------------------
解析: "System.Net.NetworkInformation, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.NetworkInformation, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.NetworkInformation.dll"
------------------
解析: "System.Net.Ping, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.Ping, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.Ping.dll"
------------------
解析: "System.Net.Security, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.Security, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.Security.dll"
------------------
解析: "System.Net.Sockets, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.Sockets, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.Sockets.dll"
------------------
解析: "System.Net.WebSockets.Client, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.WebSockets.Client, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.WebSockets.Client.dll"
------------------
解析: "System.Net.WebSockets, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Net.WebSockets, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Net.WebSockets.dll"
------------------
解析: "System.Runtime.Numerics, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.Numerics, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Runtime.Numerics.dll"
------------------
解析: "System.Numerics.Vectors, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Numerics.Vectors, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Numerics.Vectors.dll"
------------------
解析: "System.Reflection.DispatchProxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Reflection.DispatchProxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Reflection.DispatchProxy.dll"
------------------
解析: "System.Reflection.Emit, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Reflection.Emit, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Reflection.Emit.dll"
------------------
解析: "System.Reflection.Emit.ILGeneration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Reflection.Emit.ILGeneration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Reflection.Emit.ILGeneration.dll"
------------------
解析: "System.Reflection.Emit.Lightweight, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Reflection.Emit.Lightweight, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Reflection.Emit.Lightweight.dll"
------------------
解析: "System.Reflection.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Reflection.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Reflection.Primitives.dll"
------------------
解析: "System.Resources.Writer, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Resources.Writer, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Resources.Writer.dll"
------------------
解析: "System.Runtime.CompilerServices.VisualC, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.CompilerServices.VisualC, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Runtime.CompilerServices.VisualC.dll"
------------------
解析: "System.Runtime.Serialization.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.Serialization.Primitives, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Runtime.Serialization.Primitives.dll"
------------------
解析: "System.Runtime.Serialization.Xml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.Serialization.Xml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Runtime.Serialization.Xml.dll"
------------------
解析: "System.Runtime.Serialization.Json, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.Serialization.Json, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Runtime.Serialization.Json.dll"
------------------
解析: "System.Runtime.Serialization.Formatters, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.Serialization.Formatters, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Runtime.Serialization.Formatters.dll"
------------------
解析: "System.Security.Claims, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Security.Claims, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Security.Claims.dll"
------------------
解析: "System.Text.Encoding.Extensions, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Text.Encoding.Extensions, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Text.Encoding.Extensions.dll"
------------------
解析: "System.Text.RegularExpressions, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Text.RegularExpressions, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Text.RegularExpressions.dll"
------------------
解析: "System.Threading, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Threading, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Threading.dll"
------------------
解析: "System.Threading.Overlapped, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Threading.Overlapped, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Threading.Overlapped.dll"
------------------
解析: "System.Threading.ThreadPool, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Threading.ThreadPool, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Threading.ThreadPool.dll"
------------------
解析: "System.Threading.Tasks.Parallel, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Threading.Tasks.Parallel, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Threading.Tasks.Parallel.dll"
------------------
解析: "System.Transactions.Local, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Transactions.Local, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Transactions.Local.dll"
------------------
解析: "System.Web.HttpUtility, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Web.HttpUtility, Version=7.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Web.HttpUtility.dll"
------------------
解析: "System.Xml.ReaderWriter, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Xml.ReaderWriter, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Xml.ReaderWriter.dll"
------------------
解析: "System.Xml.XDocument, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Xml.XDocument, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Xml.XDocument.dll"
------------------
解析: "System.Xml.XmlSerializer, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Xml.XmlSerializer, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Xml.XmlSerializer.dll"
------------------
解析: "System.Xml.XPath.XDocument, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Xml.XPath.XDocument, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Xml.XPath.XDocument.dll"
------------------
解析: "System.Xml.XPath, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Xml.XPath, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\7.0.2\ref\net7.0\System.Xml.XPath.dll"
#endif
