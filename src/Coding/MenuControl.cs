using Spectre.Console;
using CandyBoxCS.src.Coding.Other;

namespace CandyBoxCS.src.Coding
{
    internal class MenuControl
    {
        public static ConsoleKey pressedKeyForControl;
        public static void MainTableRender()
        {
            keyPressDetectionAndLocationChange();
            string[] RowTextControl;
            switch (IVariables.currentLocation)
            {
                case "Clicker": RowTextControl = Clicker.Pclicker(); break;
                // case "Village": RowTextControl = Village.Pvillage(); break;
                case "Config": RowTextControl = Config.Pconfig(); break;
                default: RowTextControl = ["ERROR", IVariables.currentLocation, "ERROR"]; IVariables.currentLocation = "Clicker"; break;
            }

            string[] defMenu = defaultMenu();

            Console.SetCursorPosition(0, 0);
            pressedKeyForControl = ConsoleKey.None;


            if (IVariables.unlockedMenus[0])
            {
                var table = new Table();
                table.Title("CBCS - CandyBox C#");

                table.AddColumn((IVariables.debugMode ? "DebugMode: ON" : ""));
                // 40 dashes 
                table.AddColumn(defMenu[0] + "\n----------------------------------------\n" + defMenu[1] + "\n----------------------------------------\n" + defMenu[2]);
                table.AddColumn("NotSureWhat\nToWriteHere... \nHi :3");

                table.Columns[0].Width(15);
                table.Columns[1].Width(70);
                table.Columns[2].Width(15);

                table.AddRow(
                    "Controls:\n" +
                    defMenu[3] +
                    RowTextControl[0],
                    RowTextControl[1],
                    RowTextControl[2]
                );
                table.Expand();
                AnsiConsole.Write(table); // Render the table to the console
            } else
            {
                Console.WriteLine(IVariables.candies >= 0 ? "Candies: " + IVariables.candies + "" : ""); Console.WriteLine();
                Console.WriteLine(RowTextControl[1]); Console.WriteLine();
            }
        }

        private static void keyPressDetectionAndLocationChange()
        {
            bool[] unMen = IVariables.unlockedMenus;

            switch (pressedKeyForControl)
            {
                case ConsoleKey.D1: { if (IVariables.unlockedMenus[0]) { IVariables.currentLocation = "Clicker"; }; break; }
                case ConsoleKey.D2: { if (IVariables.unlockedMenus[4]) { IVariables.currentLocation = "Inventory"; }; break; }
                case ConsoleKey.D3: { if (IVariables.unlockedMenus[5]) { IVariables.currentLocation = (IVariables.foundControls[1][0] ? "Map" : "Village"); } break; }
                case ConsoleKey.D4: { if (IVariables.unlockedMenus[6]) { IVariables.currentLocation = "LollipopFarm"; }; break; }
                case ConsoleKey.D5: { if (IVariables.unlockedMenus[7]) { IVariables.currentLocation = "Cauldron"; }; break; }
                case ConsoleKey.D6: { if (IVariables.unlockedMenus[2]) { IVariables.currentLocation = "Save"; }; break; }
                case ConsoleKey.D7: { if (IVariables.unlockedMenus[1]) { IVariables.currentLocation = "Config"; }; break; }
            }
        }

        private static string[] defaultMenu()
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
                    "Esc - quit" + 
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
