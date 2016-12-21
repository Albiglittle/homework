using System.Threading;
using Multithreading.Helpers;
using System;

namespace Multithreading.Models
{
    internal sealed class Student
    {
        private static readonly Random Random = new Random();
        public string Name { get; internal set; }
        public int Mark { get; private set; }
        private readonly DeanOffice deanOffice;
        public readonly int StudentGradebookNumber;

        public Student(DeanOffice deanOffice)
        {
            this.deanOffice = deanOffice;
            Name = RandomGenerator.GetStudentName();
            StudentGradebookNumber = Random.Next(1000, 9999);
        }

        public void Initialize()
        {
            deanOffice.ExamStartedEvent.WaitOne();
            ExamStarted();

        }
        public void PassExam(int mark) {
            Mark = mark;
        }

        private void ExamStarted()
        {
            GoToUniver();
            deanOffice.PassExam(this);
        }

        private void GoToUniver()
        {
            Thread.Sleep(RandomGenerator.GetRandomTime(10));
        }
    }
}