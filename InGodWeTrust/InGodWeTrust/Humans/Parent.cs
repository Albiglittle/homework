using System;

namespace InGodWeTrust.Humans
{
    internal class Parent : Human
    {
        public int childrenCount { get; private set; }

        public Parent(int childrenCount, string name, int age, Gender gender)
            : base(name, age, gender)
        {
            this.childrenCount = childrenCount > 0 ? childrenCount : 0;
            printColour = ConsoleColor.Yellow;
        }

        public override string ToString()
        {
            return  base.ToString() + Properties.Resources.PreKidsAmount + childrenCount;
        }
    }
}