using System;
using InGodWeTrust.Humans;

namespace InGodWeTrust.Helpers
{
    internal sealed class PrintHelper
    {
        public void PrintHuman(Human human)
        {
            if (human == null)
            {
                return;
            }

            Console.ForegroundColor = human.printColour;
            Console.Write(human.ToString());

            var coolParent = human as CoolParent;
            if (coolParent != null)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(coolParent.moneyCount.ToString("C"));
            }
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintPair(Human pair)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            PrintHuman(pair);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void PrintColourInfo()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Properties.Resources.Parents);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Properties.Resources.Students);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(Properties.Resources.CoolParents);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Properties.Resources.Botans + "\n");

            Console.Write(string.Empty);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Properties.Resources.TotalMoneyFile);

            Console.WriteLine(string.Empty);
        }
    }
}