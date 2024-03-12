using System.Timers;
using CandyBoxCS.src.Coding;

namespace CandyBoxCS.src
{
    // https://candybox2.github.io/
    // https://candybox2.fandom.com/wiki/Savegame_cheats#Finish_the_game
    internal class Controller
    {

        public static void MainGame(bool newGame)
        {
            Console.Clear();
            if (!newGame)
            {
                Console.WriteLine("TODO - Atempting to load old save...");
            }
            TimerThread();
            Console.Clear();
            while (MenuControl.pressedKeyForControl != ConsoleKey.Escape)
            {
                MenuControl.pressedKeyForControl = Console.ReadKey(true).Key;
                if (MenuControl.pressedKeyForControl == ConsoleKey.Escape) { return; }
                keyPressDetectionAndLocationChange();
                MenuControl.MainTableRender();
            }
        }

        private static void TimerThread()
        {
            System.Timers.Timer timer = new() { Interval = 1000 };
            timer.Elapsed += Timer_elapsed;
            timer.Start();
        }

        // TODO - Lollipop Counter is broken if multiplier below 1
        static int minute = 0;
        private static void Timer_elapsed(object? sender, ElapsedEventArgs e)
        {
            // TODO https://candybox2.fandom.com/wiki/The_Lollipop_farm#Trivia
            // Fibonachi
            IVariables.candies += 1 * IVariables.candyMultip;
            if (IVariables.loliMultip <= 21) { IVariables.lollipops += 1 * ((int)IVariables.loliMultip); }
            MenuControl.MainTableRender();
        }
        private static void keyPressDetectionAndLocationChange()
        {
            bool[] unMen = IVariables.unlockedMenus;

            switch (MenuControl.pressedKeyForControl)
            {
                case ConsoleKey.D1: { if (unMen[0]) { IVariables.currentLocation = "Clicker"; }; break; }
                case ConsoleKey.D2: { if (unMen[4]) { IVariables.currentLocation = "Inventory"; }; break; }
                case ConsoleKey.D3: { if (unMen[5]) { IVariables.currentLocation = (IVariables.foundControls[1][0] ? "Map" : "Village"); } break; }
                case ConsoleKey.D4: { if (unMen[6]) { IVariables.currentLocation = "LollipopFarm"; }; break; }
                case ConsoleKey.D5: { if (unMen[7]) { IVariables.currentLocation = "Cauldron"; }; break; }
                case ConsoleKey.D6: { if (unMen[2]) { IVariables.currentLocation = "Save"; }; break; }
                case ConsoleKey.D7: { if (unMen[1]) { IVariables.currentLocation = "Config"; }; break; }
            }
        }
    }
}
