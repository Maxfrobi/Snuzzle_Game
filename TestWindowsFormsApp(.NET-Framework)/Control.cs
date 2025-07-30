using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsFormsApp_.NET_Framework_
{
    internal static class Con
    {
        public static int DeltaY;
        public static int DeltaX;

        public static bool FoodReplenish = false;
        public static int BoardStateIndex;
        public static bool Playing = false;
        public static bool Victory = false;
        public static bool VicEdit = false;
        public static int PastCoveredVicTiles = 0;
        public static int CurrentLevel = -1;
        public static int NextLevel = 0;
        public static List<int> PlayedLevels = new List<int>() { -1};
    }
}
