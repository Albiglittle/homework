using System;
using System.Collections.Generic;

namespace InGodWeTrust.Handlers
{
    internal sealed class CreationHelper
    {
        private readonly List<string> manNames = new List<string> { "Артём", "Владимир", "Александр", "Константин", "Иван", "Семен" };
        private readonly List<string> womanNames = new List<string> { "Вика", "Светлана", "Татьяна", "Валентина", "Екатерина", "Любовь" };
        private const int PatronymicEndLength = 4;
        private const string ManPatronymicEnd = "ович";
        private const string WomanPatronymicEnd = "овна";

        private readonly Random random = new Random();

        public string GetRandomName(Gender gender)
        {
            var nameList = gender == Gender.Male ? manNames : womanNames;
            var nameIndex = random.Next(0, manNames.Count - 1);
            return nameList[nameIndex];
        }

        public string GetNameByPatronymic(string patronymic)
        {
            return patronymic != null ? patronymic.Substring(0, patronymic.Length - PatronymicEndLength) : string.Empty;
        }

        public int GetStudentRandomAge()
        {
            const int minAge = 16;
            const int maxAge = 24;
            return random.Next(minAge, maxAge);
        }

        public int GetParentRandomAge()
        {
            const int minAge = 25;
            const int maxAge = 60;
            return random.Next(minAge, maxAge);
        }

        public Gender GetRandomGender()
        {
            return (Gender)random.Next(0, 2);
        }

        public string GetRandomPatronymic(Gender gender)
        {
            var name = GetRandomName(Gender.Male);
            return gender == Gender.Male ? (name + ManPatronymicEnd) : (name + WomanPatronymicEnd);
        }

        public int GetRandomMoney()
        {
            const int minMoney = 20000;
            const int maxMoney = 100000;
            return random.Next(minMoney, maxMoney);
        }

        public int GetRandomChildrenCount()
        {
            const int minCount = 1;
            const int maxCount = 5;
            return random.Next(minCount, maxCount);
        }

        public double GetRandomAverageRating()
        {
            const double startRating = 4.0;
            var modifier = random.NextDouble();
            return modifier + startRating;
        }

        public HumanType GetRandomHumanType()
        {
            var humanTypesCount = Enum.GetNames(typeof(HumanType)).Length;
            var rnd = random.Next(1, humanTypesCount);
            return (HumanType) rnd;
        }

        public int GetMomeyByRating(double rating)
        {
            const int baseMod = 10;
            return (int) Math.Pow(baseMod, rating);
        }

        public double GetAvgRatingByMoney(int money)
        {
            return Math.Log10(money);
        }
    }
}