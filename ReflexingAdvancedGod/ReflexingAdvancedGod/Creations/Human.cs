using ReflexingAdvancedGod.Enums;
using ReflexingAdvancedGod.Helpers;
using ReflexingAdvancedGod.Properties;
using System;

namespace ReflexingAdvancedGod.Creations
{
    internal abstract class Human: IHasName
    {
        internal string RandomChildName() { return NamesHelper.GetRandomName(Gender.Female); }
        internal static readonly string PatronymicPropertyName = Resources.PatronymicPropertyName;

        internal string Patronymic { get; set; }
        internal abstract Gender Gender { get; }

        private string name;

        public string Name { get { return name; } }
        public string Representation
        {
            get
            {
                return GetType().Name + "(" + Name + (String.IsNullOrEmpty(Patronymic) ? "" : " " + Patronymic) + ")";
            }
        }

        internal Human(string name)
        {
            this.name = name;
        }
    }
}
