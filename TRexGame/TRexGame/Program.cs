﻿using System;

namespace TRexGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new TRexGame();
            game.Run();
        }
    }
}