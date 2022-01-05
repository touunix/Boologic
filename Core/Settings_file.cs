using System;
using System.Collections.Generic;
using System.Text;

namespace Boologic.Core
{
    public static class Settings_file
    {
        public static int ScreenWidth { get; set;} = 1024;
        public static int ScreenHeight { get; set;} = 768;

        public static bool Exit {get; set;} = false;

        public enum Layer {Menu_level, Game_level, Info_level, Level_0, Level_1, Level_2, Level_3, Level_4}
        public static Layer CurrentState {get; set;} = Layer.Menu_level;
    }
}