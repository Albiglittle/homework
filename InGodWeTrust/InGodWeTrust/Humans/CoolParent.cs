using System;

namespace InGodWeTrust.Humans
{
    internal class CoolParent : Parent
    {
        public int moneyCount { get; private set; }

        public CoolParent(int moneyCount, int childrenCount, string name, int age, Gender gender)
            : base(childrenCount, name, age, gender)
        {
            this.moneyCount = moneyCount > 0 ? moneyCount : 0;
            printColour = ConsoleColor.Cyan;
        }

        public override string ToString()
        {
            return base.ToString() + Properties.Resources.PreMoneyAmount;
        }
    }
}