using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyBoxCS.src.Coding.Other
{
    internal class Save
    {
        public static string[] Psave()
        {
            string[] controls = [
                // (IVariables.foundControls[0][0] ? "E - Eat Candy" : "? - ???"),
            ];
            string controlRightSide = "example:\n";
            for (int i = 0; i < controls.Length; i++)
            { controlRightSide += (controls[i] + "\n"); }

            string mainContext = "Save is not implemented, Check Back later" + "\n";

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
