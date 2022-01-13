using System;
using System.Collections.Generic;
using System.Text;

namespace Boologic.Core
{
    /// <summary>
    /// Settings about Layers etc.
    /// </summary>

    public static class Settings_file
    {
        public static int ScreenWidth { get; set;} = 1024;
        public static int ScreenHeight { get; set;} = 768;

        public static bool Exit {get; set;} = false;

        public enum Layer {Menu_level, Game_level, Info_level, Level_0, Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9, Level_10, Level_11, Level_12}
        public static Layer CurrentState {get; set;} = Layer.Menu_level;
    }
}