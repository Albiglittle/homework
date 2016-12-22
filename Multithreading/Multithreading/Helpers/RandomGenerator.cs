using Multithreading.Properties;
using System;

namespace Multithreading.Helpers
{
    internal static class RandomGenerator
    {
        private const int MaxStudentMark = 5;
        private const int MinStudentMark = 2;
        private const int MaxStudentsNumber = 1;
        private const int MinStudentsNumber = 1;
        private const int MinTime = 2;
        private static readonly Random Random = new Random();

        private static readonly string[][] Names = {
            new[]{ 
                Resources.MenNameAndrey,
                Resources.MenNameVenya,
                Resources.MenNameVasia,
                Resources.MenNameGrisha, 
                Resources.MenNameTolia,
                Resources.MenNameKostia
            },
            new[]{ 
                Resources.WomanNameMiroslava,
                Resources.WomanNameSveta,
                Resources.WomanNameKatia,
                Resources.WomanNameValia,
                Resources.WomanNameLuba
            }};
        private static readonly string[] Surnames = 
        { 
            Resources.SurnameMolchanov,
            Resources.SurnameTretiakov,
            Resources.SurnameMetiolkin,
            Resources.SurnameGrusdev,
            Resources.SurnameMilonov
        };

        public static int GetStudentMark() {
            return Random.Next(MinStudentMark, MaxStudentMark);
        }

        public static int GetNumberOfStudents() {
            return Random.Next(MinStudentsNumber, MaxStudentsNumber);
        }

        public static TimeSpan GetRandomTime(int maxSeconds)
        {
            return TimeSpan.FromSeconds(new Random().Next(MinTime, maxSeconds));
        }

        public static string GetStudentName()
        {
            var gender = Random.Next(1);
            var ending = (gender == 1) ? "a" : "";
            var name = Names[gender][Random.Next(Names[gender].Length - 1)];
            var surname = Surnames[Random.Next(Surnames.Length - 1)] + ending;
            return String.Format("{0} {1}", name, surname);
        }
    }
}