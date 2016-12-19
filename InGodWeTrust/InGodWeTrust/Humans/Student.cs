using System;

namespace InGodWeTrust.Humans
{
    internal class Student : Human
    {
        public string patronymic { get; private set; }

        public Student(string patronymic, string name, int age, Gender gender)
            : base(name, age, gender)
        {
            this.patronymic = patronymic;
            printColour = ConsoleColor.Green;
        }

        public override string ToString()
        {
            return base.ToString() + Properties.Resources.PrePatronimic + patronymic;
        }
    }
}