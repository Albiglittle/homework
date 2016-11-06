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
            return string.Format("{0}, Отчество: {1}", base.ToString(), patronymic);
        }
    }
}