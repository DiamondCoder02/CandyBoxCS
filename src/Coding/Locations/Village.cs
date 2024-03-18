using CandyBoxCS.src.Ascii;
using CandyBoxCS.src.Coding.Functions;
namespace CandyBoxCS.src.Coding.Locations
{
    internal class Village
    {
        public static string[] Pvillage()
        {
            switch (MenuControl.pressedKeyForControl)
            {
                case ConsoleKey.M: IVariables.currentLocation = "MainMap"; break;
                case ConsoleKey.S: IVariables.currentLocation = "VillageShop"; break;
                // case ConsoleKey.G: IVariables.currentLocation = "MiniGames"; break;
                case ConsoleKey.F: IVariables.currentLocation = "VillageForge"; break;
                // case ConsoleKey.Y: IVariables.currentLocation = "YourHome"; break;
                case ConsoleKey.H: IVariables.currentLocation = "VillageBattleHouse"; break;
            }


            string[] controls = [
                (IVariables.foundControls[1][0] ? "M - Main Map" : "? - ???"),
                "S - The Shop",
                // (IVariables.foundControls[1][1] ? "G - MiniGames" : "G - ???"),
                "F - Forge",
                // "Y - Your Home",
                "H - A house"
            ];
            string controlRightSide = "Village:\n";
            for (int i = 0; i < controls.Length; i++)
            { controlRightSide += (controls[i] + "\n"); }

            string mainContext = AsciiControl.AsciiAnimation("village");
            /*
             * My future idea:
             * When doing the ascii return an array:
             * return string[] = [
             *  "true", // if it was edited
             *  "true", // if markdown should be disabled
             *  "-----------", // This is that one long ass fucking art
             *  [              // ANIMATIONS?
             *      [   "12",
             *          "23", // The position it should start
             *          "___", // animation frames
             *          "__-",
             *          "_-_",
             *          "-__", // this worm #.#
             *      ],
             *      [   "43",
             *          "11", // The position it should start
             *          "|||", // animation frames
             *          "||.",
             *          "|.|",
             *          ".||",
             *      ]
             *  ]
             * ]
             */

            string tipRightSide = "This is the Village, now that you went outside...\nYou lazy >.>\n\n" +
                "Explore your home and explore the world!";

            string[] tableContext = [
                controlRightSide,
                mainContext,
                tipRightSide
            ];
            return tableContext;
        }
    }
}
