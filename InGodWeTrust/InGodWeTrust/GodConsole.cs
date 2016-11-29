using System;
using InGodWeTrust.Handlers;
using InGodWeTrust.Humans;

namespace InGodWeTrust
{
    internal sealed class GodConsole
    {
        private readonly IGod god;
        private const string Path = @"TotalMoney.txt";
        private readonly PrintHelper printHelper;

        public GodConsole()
        {
            god = new God();
            printHelper = new PrintHelper();
        }

        public void Run()
        {
            if (!CheckDate())
            {
                Console.WriteLine("извините, сегодня воскресение. сотворить людей не получится!");
                return;
            }

            Console.WriteLine("Здравствуйте. Вы используете консоль бога.\nСколько людей вы хотите сотворить?");

            int humansCount;
            while (!int.TryParse(Console.ReadLine(), out humansCount) || humansCount < 1)
            {
                Console.WriteLine("Вы ввели некорректное число. Попробуйте еще раз");
            }

            printHelper.PrintColourInfo();

            for (var i = 0; i < humansCount; i++)
            {
                Human human;
                switch (i)
                {
                    case 0:
                        human = god.CreateHuman(Gender.Male);
                        break;
                    case 1:
                        human = god.CreateHuman(Gender.Female);
                        break;
                    default:
                        human = god.CreateHuman();
                        break;
                }

                printHelper.PrintHuman(human);

                var pair = god.CreatePair(human);
                printHelper.PrintPair(pair);
            }

            PrintTotalMoney();
        }

        private static bool CheckDate()
        {
            var date = DateTime.Now;
            return date.DayOfWeek != DayOfWeek.Sunday;
        }

        private void PrintTotalMoney()
        {
            var god = this.god as God;
            if (god == null) return;

            var money = god.GetAllMoney();
            System.IO.File.WriteAllText(Path, money.ToString());
        }
    }
}