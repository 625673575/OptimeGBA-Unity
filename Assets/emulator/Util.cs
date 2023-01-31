using System;
using System.Collections;

static class Util
{
    public static void Each<T>(this System.Collections.Generic.IEnumerable<T> ie, Action<T, int> action)
    {
        var i = 0;
        foreach (var e in ie) action(e, i++);
    }

    public static void WriteDebug(string text)
    {
        // Debug.Log(text);
    }

    public static string Pad(string n, int width, char padChar)
    {
        return n.Length >= width ? n : string.Join(padChar, new int[width - (n.Length + 1)]) + n;
    }

    public static string RightPad(string n, int width, char z)
    {
        return n.Length >= width ? n : n + string.Join(z, new int[width - (n.Length + 1)]);
    }

    public static string Hex(long i, int digits)
    {
        return $"0x{i.ToString("X").ToUpper().PadLeft(digits, '0')}";
    }

    public static string Hex(ulong i, int digits)
    {
        return $"0x{i.ToString("X").ToUpper().PadLeft(digits, '0')}";
    }

    public static string HexN(long i, int digits)
    {
        return i.ToString("X").ToUpper().PadLeft(digits, '0');
    }

    public static string HexN_LC(long i, int digits)
    {
        return i.ToString("X").ToLower().PadLeft(digits, '0');
    }

    public static string Binary(long i, int digits)
    {
        return Convert.ToString(i, 2).ToLower().PadLeft(digits, '0');
    }
}
