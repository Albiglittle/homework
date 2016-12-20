using System;
using ReflexingAdvancedGod.Properties;
using ReflexingAdvancedGod.Enums;

namespace ReflexingAdvancedGod
{
    internal class NamesHelper
    {
        private static string[] maleNames = { 
            Properties.Resources.NameArtyom, 
            Properties.Resources.NameVladimir, 
            Properties.Resources.NameAlex,
            Properties.Resources.NameConstantin,
            Properties.Resources.NameIvan,
            Properties.Resources.NameSemyon };
        private static string[] femaleNames = 
        { 
            Properties.Resources.NameVictoria,
            Properties.Resources.NameSvetlana,
            Properties.Resources.NameTatiana,
            Properties.Resources.NameValentina,
            Properties.Resources.NameEkaterina,
            Properties.Resources.NameLubov
        };

        private static string malePatronymicSuffix = Resources.ManPatronymicEndRes;
        private static string femalePatronymicSuffix = Resources.WomanPatronymicEndRes;

        private static Random rnd = new Random();

        internal static string GetRandomName(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male: 
                    return maleNames[rnd.Next(maleNames.Length)];
                case Gender.Female: 
                    return femaleNames[rnd.Next(femaleNames.Length)];
                default: 
                    throw new ArgumentException("gender");
            }
        }

        internal static string GetGenderNameSuffix(Gender gender)
        {
            return gender == Gender.Male ? malePatronymicSuffix : femalePatronymicSuffix;
        }

        internal static string GeneratePatronimyc(string parentName, Gender childGender)
        {
            return parentName + GetGenderNameSuffix(childGender);
        }
    }
}