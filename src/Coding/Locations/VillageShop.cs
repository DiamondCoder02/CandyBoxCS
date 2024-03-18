using CandyBoxCS.src.Coding.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyBoxCS.src.Coding.Locations
{
    internal class VillageShop
    {
        public static string[] Pvillage_shop()
        {
            switch (MenuControl.pressedKeyForControl)
            {
                case ConsoleKey.V: IVariables.currentLocation = "Village"; break;
                // case ConsoleKey.Q: "Shopping"; break;
            }


            string[] controls = [
                "V - Village",
                "\n\n",
                "Currency: Candy",
                "Q - Buy Lollipop (20)"
            ];
            string controlRightSide = "Village Shop:\n";
            for (int i = 0; i < controls.Length; i++)
            { controlRightSide += (controls[i] + "\n"); }

            string mainContext = AsciiControl.AsciiAnimation("villageShop");
            
            string tipRightSide = "Welcome to the shop. Here you can buy equipment you wish to use for your adventures! \n"+
                "How can I help you? :3";

            string[] tableContext = [
                controlRightSide,
                mainContext,
                tipRightSide
            ];
            return tableContext;
        }
    }
}
