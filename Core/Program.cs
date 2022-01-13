using System;

namespace Boologic.Core
{
    /// <summary>
    /// Starts game
    /// </summary>

    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}