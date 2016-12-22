using System.Drawing;
using System.Windows.Forms;
using Multithreading.Views;
using Multithreading.Properties;

namespace Multithreading.Views
{
    sealed partial class ExamView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.examProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressBarLabel = new System.Windows.Forms.Label();
            this.studentsResultsListView = new System.Windows.Forms.ListView();
            this.gradebookHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.markHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(103, 348);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(120, 33);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = global::Multithreading.Properties.Resources.StartButtonStartExam;
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // examProgressBar
            // 
            this.examProgressBar.Location = new System.Drawing.Point(3, 295);
            this.examProgressBar.Name = "examProgressBar";
            this.examProgressBar.Size = new System.Drawing.Size(319, 32);
            this.examProgressBar.Step = 1;
            this.examProgressBar.TabIndex = 3;
            // 
            // progressBarLabel
            // 
            this.progressBarLabel.BackColor = System.Drawing.Color.White;
            this.progressBarLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.progressBarLabel.Location = new System.Drawing.Point(68, 330);
            this.progressBarLabel.Name = "progressBarLabel";
            this.progressBarLabel.Size = new System.Drawing.Size(193, 15);
            this.progressBarLabel.TabIndex = 4;
            this.progressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressBarLabel.UseMnemonic = false;
            // 
            // studentsResultsListView
            // 
            this.studentsResultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gradebookHeader,
            this.nameHeader,
            this.markHeader});
            this.studentsResultsListView.Location = new System.Drawing.Point(3, 1);
            this.studentsResultsListView.Name = "studentsResultsListView";
            this.studentsResultsListView.Size = new System.Drawing.Size(319, 288);
            this.studentsResultsListView.TabIndex = 1;
            this.studentsResultsListView.UseCompatibleStateImageBehavior = false;
            this.studentsResultsListView.View = System.Windows.Forms.View.Details;
            // 
            // gradebookHeader
            // 
            this.gradebookHeader.Text = global::Multithreading.Properties.Resources.StudentGradebookNumber;
            this.gradebookHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gradebookHeader.Width = 67;
            // 
            // nameHeader
            // 
            this.nameHeader.Text = global::Multithreading.Properties.Resources.StudentName;
            this.nameHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameHeader.Width = 181;
            // 
            // markHeader
            // 
            this.markHeader.Text = global::Multithreading.Properties.Resources.Mark;
            this.markHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.markHeader.Width = 66;
            // 
            // ExamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 390);
            this.Controls.Add(this.progressBarLabel);
            this.Controls.Add(this.examProgressBar);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.studentsResultsListView);
            this.MaximizeBox = false;
            this.Name = "ExamView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Экзамен по многопоточию";
            this.Load += new System.EventHandler(this.ExamView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView studentsResultsListView;
        private Button StartButton;
        private ProgressBar examProgressBar;
        private Label progressBarLabel;
        private ColumnHeader gradebookHeader;
        private ColumnHeader nameHeader;
        private ColumnHeader markHeader;
    }
}