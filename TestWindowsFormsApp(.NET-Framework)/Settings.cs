using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsFormsApp_.NET_Framework_
{
    internal static class Set
    {
        public static bool GameRunning = true;

        public static int BoardWidth = 0;

        public static int BoardHeight = 0;

        public static int CanvasWidth = Screen.PrimaryScreen.Bounds.Width; //Math.Min(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        public static int CanvasHeight = Screen.PrimaryScreen.Bounds.Height; //Math.Min(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        public static int SquareSide = Math.Min(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        public static int TileHeight = 0;
        public static int TileWidth = 0;
    }
}
