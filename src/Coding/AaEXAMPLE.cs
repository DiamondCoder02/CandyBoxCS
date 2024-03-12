using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyBoxCS.src.Coding
{
    internal class AaEXAMPLE
    {
        public static string[] Pexample()
        {
            /*
             * The following ConsoleKeys cannot be used:
             * Numbers 0-9  - This is to move at the top menu
             * Esc key      - This to quit the game
            */
            switch (MenuControl.pressedKeyForControl)
            {
                case ConsoleKey.E:
                    IVariables.eatenCandies += IVariables.candies;
                    IVariables.candies = 0;
                    break;
                case ConsoleKey.T:
                    if (IVariables.candies <= 10) { break; }
                    IVariables.candies -= 10;
                    IVariables.thrownCandies += 10;
                    break;
            }


            string[] controls = [
                (IVariables.foundControls[0][0] ? "E - Eat Candy" : "? - ???"),
                (IVariables.foundControls[0][1] ? "T - Throw Candy" : "? - ???"),
                (IVariables.foundControls[0][2] ? "F - Request Feature" : "? - ???")
            ];
            string controlRightSide = "example:\n";
            for (int i = 0; i < controls.Length; i++)
            { controlRightSide += (controls[i] + "\n"); }

            string mainContext = "Example" + "\n";

            string tipRightSide = "";

            string[] tableContext = [
                controlRightSide,
                mainContext,
                tipRightSide
            ];
            return tableContext;
        }
    }
}
