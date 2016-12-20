using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflexingAdvancedGod.Helpers
{
    internal enum PrintType { Info, Parent, Child, Exception }
    internal class PrintHelper
    {
        internal static void Write(PrintType printType, string resultString)
        {
            ConsoleColor innateConsoleColor = Console.BackgroundColor;
            switch (printType)
            {
                case PrintType.Exception: 
                    Console.BackgroundColor = ConsoleColor.DarkRed; 
                    break;
                case PrintType.Child: 
                    Console.BackgroundColor = ConsoleColor.DarkGreen; 
                    break;
                default: break;
            }
            Console.WriteLine(resultString);
            Console.BackgroundColor = innateConsoleColor;
        }
    }
}
