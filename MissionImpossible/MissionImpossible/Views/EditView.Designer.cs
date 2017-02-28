using MissionImpossible.Views.Controls;

namespace MissionImpossible.Views
{
    partial class EditView
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.editFormActorsListView = new System.Windows.Forms.ListView();
            this.editMovieOkBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.editMovieFormHelpProvider = new System.Windows.Forms.HelpProvider();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.editFormCountry = new MissionImpossible.Views.Controls.CustomTextBox();
            this.editFormYear = new MissionImpossible.Views.Controls.CustomTextBox();
            this.editFormDirector = new MissionImpossible.Views.Controls.CustomTextBox();
            this.editFormName = new MissionImpossible.Views.Controls.CustomTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Режиссер";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название";
            // 
            // editFormActorsListView
            // 
            this.editFormActorsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editFormActorsListView.Location = new System.Drawing.Point(37, 193);
            this.editFormActorsListView.Margin = new System.Windows.Forms.Padding(2);
            this.editFormActorsListView.Name = "editFormActorsListView";
            this.editFormActorsListView.Size = new System.Drawing.Size(210, 69);
            this.editFormActorsListView.TabIndex = 27;
            this.editFormActorsListView.UseCompatibleStateImageBehavior = false;
            // 
            // editMovieOkBtn
            // 
            this.editMovieOkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editMovieOkBtn.Location = new System.Drawing.Point(37, 371);
            this.editMovieOkBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editMovieOkBtn.Name = "editMovieOkBtn";
            this.editMovieOkBtn.Size = new System.Drawing.Size(104, 30);
            this.editMovieOkBtn.TabIndex = 30;
            this.editMovieOkBtn.Text = "Сохранить";
            this.editMovieOkBtn.UseVisualStyleBackColor = true;
            this.editMovieOkBtn.Click += new System.EventHandler(this.editMovieOkBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Год";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Страна";
            // 
            // editFormCountry
            // 
            this.editFormCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editFormCountry.Location = new System.Drawing.Point(37, 156);
            this.editFormCountry.Margin = new System.Windows.Forms.Padding(2);
            this.editFormCountry.Name = "editFormCountry";
            this.editFormCountry.Size = new System.Drawing.Size(210, 20);
            this.editFormCountry.TabIndex = 25;
            // 
            // editFormYear
            // 
            this.editFormYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editFormYear.Location = new System.Drawing.Point(38, 116);
            this.editFormYear.Margin = new System.Windows.Forms.Padding(2);
            this.editFormYear.Name = "editFormYear";
            this.editFormYear.Size = new System.Drawing.Size(210, 20);
            this.editFormYear.TabIndex = 24;
            // 
            // editFormDirector
            // 
            this.editFormDirector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editFormDirector.Location = new System.Drawing.Point(38, 77);
            this.editFormDirector.Margin = new System.Windows.Forms.Padding(2);
            this.editFormDirector.Name = "editFormDirector";
            this.editFormDirector.Size = new System.Drawing.Size(210, 20);
            this.editFormDirector.TabIndex = 13;
            // 
            // editFormName
            // 
            this.editFormName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editFormName.Location = new System.Drawing.Point(38, 40);
            this.editFormName.Margin = new System.Windows.Forms.Padding(2);
            this.editFormName.Name = "editFormName";
            this.editFormName.Size = new System.Drawing.Size(210, 20);
            this.editFormName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Актеры";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(145, 371);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 30);
            this.button1.TabIndex = 31;
            this.button1.Text = "Не сохранять";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnCloseButtonPressed);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "Выбрать файл";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnUploadPosterFileClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Выберите новый постер:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(37, 281);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 20);
            this.textBox1.TabIndex = 34;
            // 
            // EditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(281, 425);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.editFormCountry);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.editFormYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.editFormActorsListView);
            this.Controls.Add(this.editMovieOkBtn);
            this.Controls.Add(this.editFormDirector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editFormName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактировать фильм";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView editFormActorsListView;
        private System.Windows.Forms.Button editMovieOkBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.HelpProvider editMovieFormHelpProvider;
        private CustomTextBox editFormName;
        private CustomTextBox editFormDirector;
        private CustomTextBox editFormYear;
        private CustomTextBox editFormCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
    }
}
