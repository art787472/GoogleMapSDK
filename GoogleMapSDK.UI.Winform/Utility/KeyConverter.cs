using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoogleMapSDK.UI.Winform.Utility
{
    public static class KeyConverter

    {

        private static readonly Dictionary<Keys, ConsoleKey> KeyCodeToConsole = new Dictionary<Keys, ConsoleKey>();

        static KeyConverter()
        {
            // 建立反向對應表
            foreach (var pair in ConsoleToKeyCode)
            {
                KeyCodeToConsole[pair.Value] = pair.Key;
            }
        }
        // ConsoleKey 到 Keys 的對應表 (KeyCode 實際上就是 Keys 枚舉)
        private static readonly Dictionary<ConsoleKey, Keys> ConsoleToKeyCode = new Dictionary<ConsoleKey, Keys>
        {
        { ConsoleKey.A, Keys.A },
        { ConsoleKey.B, Keys.B },
        { ConsoleKey.C, Keys.C },
        { ConsoleKey.D, Keys.D },
        { ConsoleKey.E, Keys.E },
        { ConsoleKey.F, Keys.F },
        { ConsoleKey.G, Keys.G },
        { ConsoleKey.H, Keys.H },
        { ConsoleKey.I, Keys.I },
        { ConsoleKey.J, Keys.J },
        { ConsoleKey.K, Keys.K },
        { ConsoleKey.L, Keys.L },
        { ConsoleKey.M, Keys.M },
        { ConsoleKey.N, Keys.N },
        { ConsoleKey.O, Keys.O },
        { ConsoleKey.P, Keys.P },
        { ConsoleKey.Q, Keys.Q },
        { ConsoleKey.R, Keys.R },
        { ConsoleKey.S, Keys.S },
        { ConsoleKey.T, Keys.T },
        { ConsoleKey.U, Keys.U },
        { ConsoleKey.V, Keys.V },
        { ConsoleKey.W, Keys.W },
        { ConsoleKey.X, Keys.X },
        { ConsoleKey.Y, Keys.Y },
        { ConsoleKey.Z, Keys.Z },
        { ConsoleKey.D0, Keys.D0 },
        { ConsoleKey.D1, Keys.D1 },
        { ConsoleKey.D2, Keys.D2 },
        { ConsoleKey.D3, Keys.D3 },
        { ConsoleKey.D4, Keys.D4 },
        { ConsoleKey.D5, Keys.D5 },
        { ConsoleKey.D6, Keys.D6 },
        { ConsoleKey.D7, Keys.D7 },
        { ConsoleKey.D8, Keys.D8 },
        { ConsoleKey.D9, Keys.D9 },
        { ConsoleKey.NumPad0, Keys.NumPad0 },
        { ConsoleKey.NumPad1, Keys.NumPad1 },
        { ConsoleKey.NumPad2, Keys.NumPad2 },
        { ConsoleKey.NumPad3, Keys.NumPad3 },
        { ConsoleKey.NumPad4, Keys.NumPad4 },
        { ConsoleKey.NumPad5, Keys.NumPad5 },
        { ConsoleKey.NumPad6, Keys.NumPad6 },
        { ConsoleKey.NumPad7, Keys.NumPad7 },
        { ConsoleKey.NumPad8, Keys.NumPad8 },
        { ConsoleKey.NumPad9, Keys.NumPad9 },
        { ConsoleKey.F1, Keys.F1 },
        { ConsoleKey.F2, Keys.F2 },
        { ConsoleKey.F3, Keys.F3 },
        { ConsoleKey.F4, Keys.F4 },
        { ConsoleKey.F5, Keys.F5 },
        { ConsoleKey.F6, Keys.F6 },
        { ConsoleKey.F7, Keys.F7 },
        { ConsoleKey.F8, Keys.F8 },
        { ConsoleKey.F9, Keys.F9 },
        { ConsoleKey.F10, Keys.F10 },
        { ConsoleKey.F11, Keys.F11 },
        { ConsoleKey.F12, Keys.F12 },
        { ConsoleKey.F13, Keys.F13 },
        { ConsoleKey.F14, Keys.F14 },
        { ConsoleKey.F15, Keys.F15 },
        { ConsoleKey.F16, Keys.F16 },
        { ConsoleKey.F17, Keys.F17 },
        { ConsoleKey.F18, Keys.F18 },
        { ConsoleKey.F19, Keys.F19 },
        { ConsoleKey.F20, Keys.F20 },
        { ConsoleKey.F21, Keys.F21 },
        { ConsoleKey.F22, Keys.F22 },
        { ConsoleKey.F23, Keys.F23 },
        { ConsoleKey.F24, Keys.F24 },
        { ConsoleKey.LeftArrow, Keys.Left },
        { ConsoleKey.RightArrow, Keys.Right },
        { ConsoleKey.UpArrow, Keys.Up },
        { ConsoleKey.DownArrow, Keys.Down },
        { ConsoleKey.Enter, Keys.Return },
        { ConsoleKey.Backspace, Keys.Back },
        { ConsoleKey.Tab, Keys.Tab },
        { ConsoleKey.Escape, Keys.Escape },
        { ConsoleKey.Spacebar, Keys.Space },
        { ConsoleKey.Delete, Keys.Delete },
        { ConsoleKey.Insert, Keys.Insert },
        { ConsoleKey.Home, Keys.Home },
        { ConsoleKey.End, Keys.End },
        { ConsoleKey.PageUp, Keys.PageUp },
        { ConsoleKey.PageDown, Keys.PageDown },
        { ConsoleKey.PrintScreen, Keys.PrintScreen },
        { ConsoleKey.Pause, Keys.Pause },
        { ConsoleKey.Applications, Keys.Apps },
        { ConsoleKey.Select, Keys.Select },
        { ConsoleKey.Print, Keys.Print },
        { ConsoleKey.Execute, Keys.Execute },
        { ConsoleKey.Help, Keys.Help },
        { ConsoleKey.Sleep, Keys.Sleep },
        { ConsoleKey.Multiply, Keys.Multiply },
        { ConsoleKey.Add, Keys.Add },
        { ConsoleKey.Separator, Keys.Separator },
        { ConsoleKey.Subtract, Keys.Subtract },
        { ConsoleKey.Decimal, Keys.Decimal },
        { ConsoleKey.Divide, Keys.Divide },
        { ConsoleKey.Clear, Keys.Clear },
            { ConsoleKey.Add , Keys.Shift}
        };



        public static ConsoleKey KeyCodeToConsoleKey(Keys keyCode)
        {
            if (KeyCodeToConsole.TryGetValue(keyCode, out ConsoleKey result))
            {
                return result;
            }

            throw new ArgumentException($"無法轉換 KeyCode {keyCode} 到 ConsoleKey");
        }
    }
}

