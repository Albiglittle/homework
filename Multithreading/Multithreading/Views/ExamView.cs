using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multithreading.Models;
using Multithreading.Properties;

namespace Multithreading.Views
{
    internal sealed partial class ExamView : Form, IExamView
    {
        private int currentProgress;
        private int studentsNumber;
        public event EventHandler ExamStarted;

        public ExamView()
        {
            InitializeComponent();

            SizeChanged += OnFormSizeChanges;
            StartButton.Click += OnButtonInitialClick;
        }

        private void Action(Action action, ISynchronizeInvoke control)
        {
            if (control.InvokeRequired) { Invoke(action); }
            else { action(); }
        }

        public void AddStudentToList(Student student)
        {
            Action(
                () => studentsResultsListView.Items.Add(new ListViewItem(new[] { 
                    String.Format("{0}", student.StudentGradebookNumber), student.Name, ""})
                    ), studentsResultsListView);
        }

        public void ShowStudentMarkAndUpdateProgress(Student student)
        {
            Action(() =>
            {
                if (student == null || student.Mark < 2 || student.Mark > 5)
                {
                    throw new ArgumentOutOfRangeException();
                }

                foreach (ListViewItem item in studentsResultsListView.Items)
                {
                    if ((item != null) && (item.SubItems[0].Text == student.StudentGradebookNumber.ToString()))
                    {
                        item.SubItems[2].Text = student.Mark.ToString();
                    }
                }
            }, studentsResultsListView);
            Action(ProgressBarStep, examProgressBar);
        }

        public void FinishExam()
        {
            Action(() => {
                StartButton.Enabled = true;
                StartButton.Text = Resources.StartNextExam;
                
            }, StartButton);
            MessageBox.Show(Resources.ExamFinished);
        }

        private void ResetProgress() 
        { 
            SetProgressBarMaxValue(studentsNumber);
        }

        private void ProgressBarStep()
        {
            progressBarLabel.Text = String.Format("{0} {1}/{2} {3}", 
                Resources.GotGrade,
                ++currentProgress, 
                studentsNumber,
                Resources.Students
                );
            examProgressBar.PerformStep();
        }

        public void SetProgressBarMaxValue(int max)
        {
            currentProgress = 0;
            studentsNumber = max;
            examProgressBar.Value = 0;
            examProgressBar.Maximum = studentsNumber;
            progressBarLabel.Text = String.Format("{0} 0/{1} {2}", Resources.GotGrade, max, Resources.Students);
        }

        private void OnFormSizeChanges(object sender, EventArgs e) 
        {
            Action(AddColumnsListView, studentsResultsListView);
        }

        private void OnButtonInitialClick(object sender, EventArgs e)
        {
            ResetProgress();
            StartButton.Enabled = false;
            StartButton.Text = Resources.StartButtonExamInProgress;
            examProgressBar.Value = 0;
            studentsResultsListView.Items.Clear();
            studentsResultsListView.Refresh();
            if (ExamStarted != null)
            {
                ExamStarted.Invoke(this, EventArgs.Empty);
            }
            
        }

        private void AddColumnsListView()
        {
            var width = studentsResultsListView.Size.Width;
            var numWidth = width / 100 * 25;
            var nameWidth = width / 100 * 45;
            var markWidth = width / 100 * 30;

            if (studentsResultsListView.Columns.Count == 0)
            {
                studentsResultsListView.Columns.Add(Resources.StudentGradebookNumber, numWidth, HorizontalAlignment.Center);
                studentsResultsListView.Columns.Add(Resources.StudentName, nameWidth, HorizontalAlignment.Center);
                studentsResultsListView.Columns.Add(Resources.Mark, markWidth, HorizontalAlignment.Center);
            }
            else
            {
                studentsResultsListView.Columns[0].Width = numWidth;
                studentsResultsListView.Columns[1].Width = nameWidth;
                studentsResultsListView.Columns[2].Width = markWidth;
            }
            studentsResultsListView.Refresh();
        }

        private void ExamView_Load(object sender, EventArgs e)
        {

        }

    }
}
