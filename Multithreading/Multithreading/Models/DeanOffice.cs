using System;
using System.Threading;
using Multithreading.Helpers;

namespace Multithreading.Models
{
    internal sealed class DeanOffice
    {
        private readonly object locker = new object();
        public event EventHandler StudentComeEventHandler;
        public event EventHandler StudentPassExamEventHandler;

        public DeanOffice()
        {
            ExamStartedEvent = new ManualResetEvent(false);
        }

        public ManualResetEvent ExamStartedEvent { get; internal set; }
        public void StartExam()
        {
            ExamStartedEvent.Set();
        }

        public void PassExam(Student student)
        {
            lock (locker)
            {
                if (StudentComeEventHandler != null)
                {
                    StudentComeEventHandler.Invoke(student, EventArgs.Empty);
                }
                Thread.Sleep(RandomGenerator.GetRandomTime(3));
                var mark = RandomGenerator.GetStudentMark();
                student.PassExam(mark);
                if (StudentPassExamEventHandler != null)
                {
                    StudentPassExamEventHandler.Invoke(student, EventArgs.Empty);
                }
            }
        }
    }
}