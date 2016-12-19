using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InGodWeTrust.Helpers
{
    class NameHelper
    {
        private readonly List<string> manNames = new List<string> { 
            Properties.Resources.NameArtyom, 
            Properties.Resources.NameVladimir, 
            Properties.Resources.NameAlex,
            Properties.Resources.NameConstantin,
            Properties.Resources.NameIvan,
            Properties.Resources.NameSemyon
        };
        private readonly List<string> womanNames = new List<string> {
            Properties.Resources.NameVictoria,
            Properties.Resources.NameSvetlana,
            Properties.Resources.NameTatiana,
            Properties.Resources.NameValentina,
            Properties.Resources.NameEkaterina,
            Properties.Resources.NameLubov
        };
        private const int PatronymicEndLength = 4;
        private string ManPatronymicEnd = Properties.Resources.ManPatronymicEndRes;
        private string WomanPatronymicEnd = Properties.Resources.WomanPatronymicEndRes;

        private readonly Random random = new Random();

        public string GetRandomName(Gender gender)
        {
            var nameList = gender == Gender.Male ? manNames : womanNames;
            var nameIndex = random.Next(0, manNames.Count - 1);
            return nameList[nameIndex];
        }

        public string GetNameByPatronymic(string patronymic)
        {
            return patronymic != null ? patronymic.Substring(0, patronymic.Length - PatronymicEndLength) : string.Empty;
        }

        public string GetRandomPatronymic(Gender gender)
        {
            var name = GetRandomName(Gender.Male);
            return gender == Gender.Male ? (name + ManPatronymicEnd) : (name + WomanPatronymicEnd);
        }
    }
}
