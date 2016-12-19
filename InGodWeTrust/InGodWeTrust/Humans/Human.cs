using System;

namespace InGodWeTrust.Humans
{
    internal abstract class Human
    {
        public string name { get; private set; }
        public int age { get; private set; }
        public Gender gender { get; private set; }

        public ConsoleColor printColour { get; internal set; }

        protected Human(string name, int age, Gender gender)
        {
            this.name = string.IsNullOrWhiteSpace(name) ? string.Empty : name;
            this.age = age > 0 ? age : 0;
            this.gender = gender;
        }

        public override string ToString()
        {
            return
                Properties.Resources.PreName + name + 
                Properties.Resources.PreAge + age + 
                Properties.Resources.PreSex + 
                (gender == Gender.Male ? Properties.Resources.Male : Properties.Resources.Female);
        }
    }
}