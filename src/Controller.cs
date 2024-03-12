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
            while (MenuControl.pressedKeyForControl != ConsoleKey.Escape)
            {
                MenuControl.pressedKeyForControl = Console.ReadKey(true).Key;
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

    }
}
