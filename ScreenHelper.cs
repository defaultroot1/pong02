using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pong02
{
    internal static class ScreenHelper
    {
        public static int ScreenWidth { get; private set; }
        public static int ScreenHeight { get; private set; }
        public static void Initialise(int screenWidth, int screenHeight) 
        { 
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
        }
    }
}
