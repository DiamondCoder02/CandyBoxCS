using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyBoxCS.src.Coding.Other
{
    internal class Config
    {
        public static string[] Pconfig()
        {
            switch (MenuControl.pressedKeyForControl)
            {
                case ConsoleKey.D:
                    if (IVariables.debugMode) { IVariables.debugMode = false; }
                    else { IVariables.debugMode = true; }
                    break;
            }

            string[] controls = [
                "D - Debug On|Off",
            ];
            string controlRightSide = "Config:\n";
            for (int i = 0; i < controls.Length; i++)
            { controlRightSide += (controls[i] + "\n"); }

            string currentSettings = "Temporary this will only show debug info, till I make a proper one\n\n" +
                "Debug:" + IVariables.debugMode + "\n" +
                "Language:" + IVariables.language + "\n\n" +
                "Candies:" + IVariables.candies + " - Multip: " + IVariables.candyMultip + "\n" +
                "eatenCandies:" + IVariables.eatenCandies + " - thrownCandies: " + IVariables.thrownCandies + "\n" +
                "Lollipop:" + IVariables.lollipops + " - Multip: " + IVariables.loliMultip + "\n" +
                "chocolate:" + IVariables.chocolate + "\n" +
                "painsAuChocolat:" + IVariables.painsAuChocolat;

            string helper = "This is the config \n" +
                "You can change: \n- Language\n- Debug mode";

            string[] tableContext = [
                controlRightSide,
                currentSettings,
                helper
            ];

            return tableContext;
        }
    }
}
