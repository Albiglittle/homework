using System;
using System.Collections.Generic;
using InGodWeTrust.Helpers;
using InGodWeTrust.Humans;


namespace InGodWeTrust
{
    internal class God : IGod
    {
        private readonly NameHelper nameHelper = new NameHelper();
        private readonly CreationHelper creationHelper = new CreationHelper();
        private List<Human> Humans { get; set; }

        public God()
        {
            Humans = new List<Human>();
        }

        public int this[int i]
        {
            get
            {
                if (i < 0 && i > Humans.Count - 1)
                {
                    return 0;
                }
                var coolParent = Humans[i] as CoolParent;
                return coolParent != null ? coolParent.moneyCount : 0;
            }
        }

        public int GetAllMoney()
        {
            var summ = 0;
            for (var i = 0; i < Humans.Count; i++)
            {
                summ += this[i];
            }
            return summ;
        }

        public Human CreateHuman()
        {
            var gender = creationHelper.GetRandomGender();
            return CreateHuman(gender);
        }
        // абстрактный тип !
        public Human CreateHuman(Gender gender)
        {
            Human human;
            var name = nameHelper.GetRandomName(gender);
            var humanType = creationHelper.GetRandomHumanType();
            switch (humanType)
            {
                case HumanType.Student:
                    human = CreateStudent(name, gender);
                    break;

                case HumanType.Botan:
                    human = CreateBotan(name, gender);
                    break;

                case HumanType.Parent:
                    human = CreateParent(name, gender);
                    break;

                case HumanType.CoolParent:
                    human = CreateCoolParent(name, gender);
                    break;

                default:
                    throw new NotSupportedException();
            }
            Humans.Add(human);
            return human;
        }

        public Human CreatePair(Human human)
        {
            if (human == null)
            {
                return null;
            }

            Human pair = null;

            if (human is Student)
            {
                var student = human as Student;
                var name = nameHelper.GetNameByPatronymic(student.patronymic);
                var botan = student as Botan;

                if (botan != null)
                {
                    var rating = botan.averageRating;
                    pair = CreateCoolParent(name, Gender.Male, rating);
                }
                else
                {
                    pair = CreateParent(name, Gender.Male);
                }
            }
            else if (human is Parent)
            {
                var gender = creationHelper.GetRandomGender();
                var name = nameHelper.GetRandomName(gender);

                var coolParent = human as CoolParent;
                if (coolParent != null)
                {
                    var money = coolParent.moneyCount;
                    pair = CreateBotan(name, gender, money);
                }
                else
                {
                    pair = CreateStudent(name, gender);
                }
            }
            else
            {
                throw new Exception("Can't create pair for Human.");
            }
            Humans.Add(pair);
            return pair;
        }

        private Student CreateStudent(string name, Gender gender)
        {
            var age = creationHelper.GetStudentRandomAge();
            var patronymic = nameHelper.GetRandomPatronymic(gender);

            return new Student(patronymic, name, age, gender);
        }

        private Botan CreateBotan(string name, Gender gender, int? money = null)
        {
            var age = creationHelper.GetStudentRandomAge();
            var patronymic = nameHelper.GetRandomPatronymic(gender);
            var averageRating = money == null
                ? creationHelper.GetRandomAverageRating()
                : creationHelper.GetAvgRatingByMoney(money.Value);

            return new Botan(averageRating, patronymic, name, age, gender);
        }

        private Parent CreateParent(string name, Gender gender)
        {
            var age = creationHelper.GetParentRandomAge();
            var childrenCount = creationHelper.GetRandomChildrenCount();

            return new Parent(childrenCount, name, age, gender);
        }

        private CoolParent CreateCoolParent(string name, Gender gender, double? avgRating = null)
        {
            var age = creationHelper.GetParentRandomAge();
            var childrenCount = creationHelper.GetRandomChildrenCount();
            var money = avgRating == null ? creationHelper.GetRandomMoney() : creationHelper.GetMomeyByRating(avgRating.Value);

            return new CoolParent(money, childrenCount, name, age, gender);
        }
    }
}