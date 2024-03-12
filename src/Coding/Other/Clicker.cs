namespace CandyBoxCS.src.Coding.Other
{
    internal class Clicker
    {
        private static int requestCost = 30;
        public static string[] Pclicker()
        {
            if (IVariables.candies >= 0) { IVariables.foundControls[0][0] = true; };
            if (IVariables.candies >= 10) { IVariables.foundControls[0][1] = true; };
            if (IVariables.candies >= 30) { IVariables.foundControls[0][2] = true; };

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
                case ConsoleKey.F:
                    if (IVariables.candies >= 30 && !IVariables.unlockedMenus[0]) { IVariables.candies -= 30; requestCost = 5; IVariables.unlockedMenus[0] = true; break; }
                    if (IVariables.candies >= 5 && !IVariables.unlockedMenus[1] && IVariables.unlockedMenus[0]) { IVariables.candies -= 5; requestCost = 5; IVariables.unlockedMenus[1] = true; break; }
                    if (IVariables.candies >= 5 && !IVariables.unlockedMenus[2] && IVariables.unlockedMenus[1]) { IVariables.candies -= 5; requestCost = 5; IVariables.unlockedMenus[2] = true; break; }
                    if (IVariables.candies >= 5 && !IVariables.unlockedMenus[3] && IVariables.unlockedMenus[2]) { IVariables.candies -= 5; requestCost = 10; IVariables.unlockedMenus[3] = true; break; }
                    if (IVariables.candies >= 10 && !IVariables.unlockedMenus[5] && IVariables.unlockedMenus[3]) { IVariables.candies -= 10; requestCost = 0; IVariables.unlockedMenus[5] = true; break; }
                    break;
            }


            string[] controls = [
                (IVariables.foundControls[0][0] ? "E - Eat Candy" : "? - ???"),
                (IVariables.foundControls[0][1] ? "T - Throw Candy" : "? - ???"),
                (IVariables.foundControls[0][2] ? "F - Request Feature" : "? - ???")
            ];
            string controlString = "Clicker:\n";
            for (int i = 0; i < controls.Length; i++)
            { controlString += (controls[i] + "\n"); }

            string mainContext = "To eat candy, press E" + "\n" +
                (IVariables.eatenCandies > 0 ? "You have eaten " + IVariables.eatenCandies + " candies!" : "") + "\n\n" +
                (IVariables.foundControls[0][1] ? "To throw candy, press T" : "") + "\n" +
                (IVariables.thrownCandies > 0 ? "You have thrown " + IVariables.thrownCandies + " candies. You monster!" : "") + "\n\n" +
                (requestCost > 1 ? IVariables.foundControls[0][2] ? "To request a new feature, press F ( cost: " + requestCost + " candies )" : "" : "Map is now unlocked. Have fun exploring the world!");

            string tipRightSide = "Welcome to CandyBox!";

            string[] tableContext = [
                controlString,
                mainContext,
                tipRightSide
            ];
            return tableContext;
        }
    }
}
