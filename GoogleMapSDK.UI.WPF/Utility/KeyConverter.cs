using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoogleMapSDK.UI.WPF.Utility
{
    public static class WPFKeyConverter
    {
        private static readonly Dictionary<Key, ConsoleKey> keyMap = new Dictionary<Key, ConsoleKey>()
    {
        { Key.A, ConsoleKey.A },
        { Key.B, ConsoleKey.B },
        { Key.C, ConsoleKey.C },
        { Key.D, ConsoleKey.D },
        { Key.E, ConsoleKey.E },
        { Key.F, ConsoleKey.F },
        { Key.G, ConsoleKey.G },
        { Key.H, ConsoleKey.H },
        { Key.I, ConsoleKey.I },
        { Key.J, ConsoleKey.J },
        { Key.K, ConsoleKey.K },
        { Key.L, ConsoleKey.L },
        { Key.M, ConsoleKey.M },
        { Key.N, ConsoleKey.N },
        { Key.O, ConsoleKey.O },
        { Key.P, ConsoleKey.P },
        { Key.Q, ConsoleKey.Q },
        { Key.R, ConsoleKey.R },
        { Key.S, ConsoleKey.S },
        { Key.T, ConsoleKey.T },
        { Key.U, ConsoleKey.U },
        { Key.V, ConsoleKey.V },
        { Key.W, ConsoleKey.W },
        { Key.X, ConsoleKey.X },
        { Key.Y, ConsoleKey.Y },
        { Key.Z, ConsoleKey.Z },

        { Key.D0, ConsoleKey.D0 },
        { Key.D1, ConsoleKey.D1 },
        { Key.D2, ConsoleKey.D2 },
        { Key.D3, ConsoleKey.D3 },
        { Key.D4, ConsoleKey.D4 },
        { Key.D5, ConsoleKey.D5 },
        { Key.D6, ConsoleKey.D6 },
        { Key.D7, ConsoleKey.D7 },
        { Key.D8, ConsoleKey.D8 },
        { Key.D9, ConsoleKey.D9 },

        { Key.Enter, ConsoleKey.Enter },
        { Key.Escape, ConsoleKey.Escape },
        { Key.Back, ConsoleKey.Backspace },
        { Key.Tab, ConsoleKey.Tab },
        { Key.Space, ConsoleKey.Spacebar },

        { Key.Left, ConsoleKey.LeftArrow },
        { Key.Up, ConsoleKey.UpArrow },
        { Key.Right, ConsoleKey.RightArrow },
        { Key.Down, ConsoleKey.DownArrow },

        { Key.F1, ConsoleKey.F1 },
        { Key.F2, ConsoleKey.F2 },
        { Key.F3, ConsoleKey.F3 },
        { Key.F4, ConsoleKey.F4 },
        { Key.F5, ConsoleKey.F5 },
        { Key.F6, ConsoleKey.F6 },
        { Key.F7, ConsoleKey.F7 },
        { Key.F8, ConsoleKey.F8 },
        { Key.F9, ConsoleKey.F9 },
        { Key.F10, ConsoleKey.F10 },
        { Key.F11, ConsoleKey.F11 },
        { Key.F12, ConsoleKey.F12 },
    };

        public static bool TryConvert(Key wpfKey, out ConsoleKey consoleKey)
        {
            return keyMap.TryGetValue(wpfKey, out consoleKey);
        }
    }
}
