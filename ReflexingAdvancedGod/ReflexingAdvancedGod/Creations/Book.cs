using System;

namespace ReflexingAdvancedGod.Creations
{
    internal sealed class Book : IHasName
    {
        private string name;
        public string Name { get { return name; } }

        public string Representation { get { return String.Format("Book({0})", Name); } }

        internal Book(string name)
        {
            this.name = name;
        }
    }
}
