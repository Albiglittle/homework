using System;
using System.Collections.Generic;
using System.Threading;
using Multithreading.Helpers;
using Multithreading.Models;
using Multithreading.Views;

namespace Multithreading.Controllers
{
    internal sealed class ExamController
    {
        private readonly IExamView view;
        private readonly int studentsNumber;
        private readonly object locker = new object();
        private readonly List<Student> studentsList = new List<Student>();
        private int passedExamAmount;
        private readonly DeanOffice deanOffice = new DeanOffice();

        public ExamController(IExamView view)
        {
            this.view = view;
            view.ExamStarted += OnExamStarted;
            studentsNumber = RandomGenerator.GetNumberOfStudents();
            view.SetProgressBarMaxValue(studentsNumber);

            deanOffice.StudentComeEventHandler += OnStudentCome;
            deanOffice.StudentPassExamEventHandler += OnStudentPassedExam;

            for (var i = 1; i <= studentsNumber; i++)
            {
                studentsList.Add(new Student(deanOffice));
            }
        }

        private void OnStudentCome(object sender, EventArgs e)
        {
            view.AddStudentToList((Student)sender);
        }

        private void OnStudentPassedExam(object sender, EventArgs e)
        {
            view.ShowStudentMarkAndUpdateProgress((Student)sender);
            lock (locker)
            {
                passedExamAmount = passedExamAmount + 1;
                if (passedExamAmount == studentsNumber)
                {
                    view.FinishExam();
                }
            }
        }

        private void OnExamStarted(object sender, EventArgs e)
        {
            passedExamAmount = 0;

            foreach (var student in studentsList)
            {
                (new Thread(student.Initialize) {IsBackground = true}).Start();
            }
            deanOffice.StartExam();
        }
    }
}