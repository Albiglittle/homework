using System;
using InGodWeTrust.Humans;

namespace InGodWeTrust.Handlers
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
            Console.Write("Обычные родители");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Студенты");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Ботаны");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Крутые предки\n");

            Console.Write(string.Empty);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Сумма всех денег крутых предков выведены в файл TotalMoney.txt");
            Console.WriteLine("(рядом с исполняемым файлом)");

            Console.WriteLine(string.Empty);
        }
    }
}