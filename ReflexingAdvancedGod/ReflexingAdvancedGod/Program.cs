using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflexingAdvancedGod.Properties;
using ReflexingAdvancedGod.Helpers;
using ReflexingAdvancedGod.Exceptions;

namespace ReflexingAdvancedGod
{
    internal sealed class Program
    {
        private static string InitialGreeting = Resources.InitialGreeting;
        private static string CheckEqualGender = Resources.CheckEqualGender;
        private static string CheckDate = Resources.CheckDateMessage;
        private static string PromptAction = Resources.SuggestAction;
        private static string NotLiked = Resources.NotLikeEachOther;

        private static ConsoleKey[] ExitKeys = { ConsoleKey.F10, ConsoleKey.Q };
        private static ConsoleKey ContinueKey = ConsoleKey.Enter;
        

        internal static void Main(string[] args)
        {
            var day = DateTime.Now.DayOfWeek;
            if (day == DayOfWeek.Sunday)
            {
                PrintHelper.Write(PrintType.Info, CheckDate);
                return;
            }

            PrintHelper.Write(PrintType.Info, InitialGreeting);

            IGod god = new God();

            while (true)
            {
                if (!PromptUser()) { break; }
                try
                {
                    var first = god.CreateHuman();
                    var second = god.CreateHuman();
                    PrintHelper.Write(PrintType.Parent, first.Representation);
                    PrintHelper.Write(PrintType.Parent, second.Representation);

                    var child = god.Couple(first, second);

                    if (child != null)
                    {
                        PrintHelper.Write(PrintType.Child, child.Representation);
                    }
                    else
                    {
                        PrintHelper.Write(PrintType.Exception, NotLiked);
                    }
                }
                catch (EqualGenderException exception)
                {
                    PrintHelper.Write(PrintType.Exception, CheckEqualGender);
                }
                Console.WriteLine();
                
            }
        }

        private static bool PromptUser()
        {
            PrintHelper.Write(PrintType.Info, PromptAction);
            var key = Console.ReadKey(true).Key;
            while (key != ConsoleKey.F10 && key != ConsoleKey.Q && key != ConsoleKey.Enter)
            {
                key = Console.ReadKey(true).Key;
            }
            return key == ConsoleKey.Enter;
        }
    }
}