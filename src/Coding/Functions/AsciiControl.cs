using CandyBoxCS.src.Ascii;
using Spectre.Console;

namespace CandyBoxCS.src.Coding.Functions
{
    internal class AsciiControl
    {
        public static string AsciiAnimation(string location)
        {
            string[]? asciiPicture;
            string imageAscii = "";

            switch (location)
            {
                case "village": asciiPicture = MapVillage.Map_Village(); break;
                case "villageShop": asciiPicture = MapVillage.House_Shop(); break;
                default: asciiPicture = null; break;
            }

            if (asciiPicture == null) { return "Error NULL"; };

            if (asciiPicture[0] == "true") { imageAscii += "Edited by DiamondCoder - "; };
            if (asciiPicture[1] == "true") { imageAscii += Markup.Escape(asciiPicture[2]); }
            else { imageAscii += asciiPicture[2]; }

            


            
            return imageAscii;
        }
    }
}
