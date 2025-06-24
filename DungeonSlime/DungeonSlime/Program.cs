using System;

namespace DungeonSlime
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new DungeonSlimeGame();
            game.Run();
        }
    }
}