using System;

namespace InGodWeTrust.Humans
{
    internal class Botan : Student
    {
        private const float minRate = 3;

        public double averageRating { get; private set; }

        public Botan(double averageRating, string patronymic, string name, int age, Gender gender)
            : base(patronymic, name, age, gender)
        {
            this.averageRating = averageRating > minRate ? averageRating : minRate;
            printColour = ConsoleColor.Red;
        }

        public override string ToString()
        {
            return base.ToString() + Properties.Resources.PreAverageRating + string.Format("{0:F}", averageRating);
        }
    }
}