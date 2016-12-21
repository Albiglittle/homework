using System;
using Multithreading.Models;

namespace Multithreading.Views
{
    internal interface IExamView
    {
        event EventHandler ExamStarted;
        void AddStudentToList(Student student);
        void ShowStudentMarkAndUpdateProgress(Student student);
        void FinishExam();
        void SetProgressBarMaxValue(int max);
    }
}