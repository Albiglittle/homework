using System;
using System.Collections.Generic;

namespace InGodWeTrust.Helpers
{
    internal sealed class CreationHelper
    {
        private readonly Random random = new Random();

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

        public HumanType GetRandomHumanType()
        {
            var humanTypesCount = Enum.GetNames(typeof(HumanType)).Length;
            var rnd = random.Next(1, humanTypesCount);
            return (HumanType) rnd;
        }

        public double GetRandomAverageRating()
        {
            const double startRating = 4.0;
            var modifier = random.NextDouble();
            return modifier + startRating;
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