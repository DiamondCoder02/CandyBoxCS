using CandyBoxCS.src.Ascii;
namespace CandyBoxCS.src.Coding.Locations
{
    internal class Village
    {
        public static string[] Pvillage()
        {
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

            string mainContext = "Edited by DiamondCoder - " + MapVillage.Map_Village().ToString();

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
