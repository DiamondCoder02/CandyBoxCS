using Spectre.Console;
using CandyBoxCS.src.Coding.Other;
using CandyBoxCS.src.Coding.Locations;

namespace CandyBoxCS.src.Coding
{
    internal class MenuControl
    {
        public static ConsoleKey pressedKeyForControl;
        public static string[]? debugInfoAtTop;
        public static void MainTableRender()
        {
            string[] defMenu = DefaultMenu();
            string[] RowTextControl;
            switch (IVariables.currentLocation)
            {
                case "Clicker": RowTextControl = Clicker.Pclicker(); break;
                case "Village": RowTextControl = Village.Pvillage(); break;
                case "Save": RowTextControl = Save.Psave(); break;
                case "Config": RowTextControl = Config.Pconfig(); break;
                default: RowTextControl = ["ERROR", IVariables.currentLocation, "ERROR"]; IVariables.currentLocation = "Clicker"; break;
            }

            Console.SetCursorPosition(0, 0);
            pressedKeyForControl = ConsoleKey.None;

            if (IVariables.debugMode)
            {
                if (debugInfoAtTop != null) { for (int i = 0; i < debugInfoAtTop.Length; i++) { Console.WriteLine(debugInfoAtTop[i]); } }
                Console.WriteLine("---|||---|||---|||---|||---|||---");
            }

            if (IVariables.unlockedMenus[0])
            {
                var table = new Table();
                table.Title("CBCS - CandyBox C#");

                table.AddColumn((IVariables.debugMode ? "DebugMode: ON" : ""));
                // 40 dashes 
                table.AddColumn(defMenu[0] + "\n----------------------------------------\n" + defMenu[1] + "\n----------------------------------------\n" + defMenu[2]);
                table.AddColumn("Current location: \n" + IVariables.currentLocation);

                table.Columns[0].Width(20);
                table.Columns[1].Width(100);
                table.Columns[2].Width(20);

                // table.Expand();
                table.Width = 200;

                table.AddRow(
                    "Controls:\n" +
                    defMenu[3] +
                    RowTextControl[0],
                    RowTextControl[1],
                    RowTextControl[2]
                );

                AnsiConsole.Write(table); // Render the table to the console

                int consoleHeight = Console.WindowHeight;
                (int Left, int Top) value = Console.GetCursorPosition();
                for (int i = 0; i < (consoleHeight - value.Top - 1); i++)
                {
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                }
            } else
            {
                Console.WriteLine(IVariables.candies >= 0 ? "Candies: " + IVariables.candies + "" : ""); Console.WriteLine();
                Console.WriteLine(RowTextControl[1]); Console.WriteLine();
            }
        }

        private static string[] DefaultMenu()
        {
            bool[] unMen = IVariables.unlockedMenus;
            string topMenu = "", sweets = (IVariables.candies >= 0 ? "Candies: " + IVariables.candies : ""), basicControls = "";

            if (IVariables.unlockedMenus[0]) 
            {
                topMenu =
                (unMen[0] ? "CandyBox" : " - ") + " | " +
                (unMen[4] ? "Inventory" : " - ") + " | " +
                (unMen[5] ? "Map" : " - ") + " | " +
                (unMen[6] ? "Lollipop Farm" : " - ") + " | " +
                (unMen[7] ? "Cauldron" : " - ") + " | " +
                (unMen[2] ? "Save" : " - ") + " | " +
                (unMen[1] ? "Config" : " - ");
            }

            if (IVariables.unlockedMenus[1])
            {
                sweets = (IVariables.candies >= 0 ? "Candies: " + IVariables.candies + "  ||  " : "") +
                (IVariables.chocolate >= 0 ? "Chocolate: " + IVariables.chocolate + "  ||  \n" : "") +
                (IVariables.lollipops >= 0 ? "Lollipops: " + IVariables.lollipops + "  ||  " : "") +
                (IVariables.painsAuChocolat >= 0 ? "painsAuChocolat: " + IVariables.painsAuChocolat : "");

                // Add some rows
                basicControls =
                    "----------\n" +
                    "Esc - quit\n" + 
                    (unMen[0] ? "1 - CandyBox" : "? - ???") + "\n" +
                    (unMen[4] ? "2 - Inventory" : "? - ???") + "\n" +
                    (unMen[5] ? "3 - Map" : "? - ???") + "\n" +
                    (unMen[6] ? "4 - Lollipop Farm" : "? - ???") + "\n" +
                    (unMen[7] ? "5 - Cauldron" : "? - ???") + "\n" +
                    (unMen[2] ? "6 - Save" : "? - ???") + "\n" +
                    (unMen[1] ? "7 - Config" : "? - ???") +
                    "\n----------\n";
            }

            string healthBar = (IVariables.unlockedMenus[3] ? "Health: " + IVariables.currentHealth + " / " + IVariables.maxHealth : "");



            return [topMenu, sweets, healthBar, basicControls];
        }
    }
}
