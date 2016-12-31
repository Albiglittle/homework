using MissionImpossible.Views.Controls;

namespace MissionImpossible.Views
{
    partial class SearchView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.searchFormBtnSearch = new System.Windows.Forms.Button();
            this.searchFormBtnClear = new System.Windows.Forms.Button();
            this.searchMovieFormEerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.searchViewYear = new CustomTextBox();
            this.searchViewCountry = new CustomTextBox();
            this.searchViewActor = new CustomTextBox();
            this.searchViewDirector = new CustomTextBox();
            this.searchViewName = new CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.searchMovieFormEerrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Режиссер";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Актер";
            // 
            // searchFormBtnSearch
            // 
            this.searchFormBtnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchFormBtnSearch.AutoSize = true;
            this.searchFormBtnSearch.Location = new System.Drawing.Point(13, 215);
            this.searchFormBtnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.searchFormBtnSearch.Name = "searchFormBtnSearch";
            this.searchFormBtnSearch.Size = new System.Drawing.Size(211, 29);
            this.searchFormBtnSearch.TabIndex = 17;
            this.searchFormBtnSearch.Text = "Найти";
            this.searchFormBtnSearch.UseVisualStyleBackColor = true;
            this.searchFormBtnSearch.Click += new System.EventHandler(this.searchFormBtnSearch_Click);
            // 
            // searchFormBtnClear
            // 
            this.searchFormBtnClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchFormBtnClear.AutoSize = true;
            this.searchFormBtnClear.Location = new System.Drawing.Point(13, 248);
            this.searchFormBtnClear.Margin = new System.Windows.Forms.Padding(2);
            this.searchFormBtnClear.Name = "searchFormBtnClear";
            this.searchFormBtnClear.Size = new System.Drawing.Size(211, 31);
            this.searchFormBtnClear.TabIndex = 19;
            this.searchFormBtnClear.Text = "Очистить";
            this.searchFormBtnClear.UseVisualStyleBackColor = true;
            this.searchFormBtnClear.Click += new System.EventHandler(this.searchFormBtnClear_Click);
            // 
            // searchMovieFormEerrorProvider
            // 
            this.searchMovieFormEerrorProvider.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Страна";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Год";
            // 
            // searchViewYear
            // 
            this.searchViewYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchViewYear.Location = new System.Drawing.Point(13, 141);
            this.searchViewYear.Margin = new System.Windows.Forms.Padding(2);
            this.searchViewYear.Name = "searchViewYear";
            this.searchViewYear.Size = new System.Drawing.Size(210, 20);
            this.searchViewYear.TabIndex = 13;
            // 
            // searchViewCountry
            // 
            this.searchViewCountry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchViewCountry.Location = new System.Drawing.Point(13, 101);
            this.searchViewCountry.Margin = new System.Windows.Forms.Padding(2);
            this.searchViewCountry.Name = "searchViewCountry";
            this.searchViewCountry.Size = new System.Drawing.Size(210, 20);
            this.searchViewCountry.TabIndex = 11;
            // 
            // searchViewActor
            // 
            this.searchViewActor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchViewActor.Location = new System.Drawing.Point(13, 178);
            this.searchViewActor.Margin = new System.Windows.Forms.Padding(2);
            this.searchViewActor.Name = "searchViewActor";
            this.searchViewActor.Size = new System.Drawing.Size(210, 20);
            this.searchViewActor.TabIndex = 15;
            // 
            // searchViewDirector
            // 
            this.searchViewDirector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchViewDirector.Location = new System.Drawing.Point(14, 64);
            this.searchViewDirector.Margin = new System.Windows.Forms.Padding(2);
            this.searchViewDirector.Name = "searchViewDirector";
            this.searchViewDirector.Size = new System.Drawing.Size(210, 20);
            this.searchViewDirector.TabIndex = 8;
            // 
            // searchViewName
            // 
            this.searchViewName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchViewName.Location = new System.Drawing.Point(14, 25);
            this.searchViewName.Margin = new System.Windows.Forms.Padding(2);
            this.searchViewName.Name = "searchViewName";
            this.searchViewName.Size = new System.Drawing.Size(210, 20);
            this.searchViewName.TabIndex = 1;
            // 
            // SearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 309);
            this.Controls.Add(this.searchViewYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.searchViewCountry);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.searchViewActor);
            this.Controls.Add(this.searchViewDirector);
            this.Controls.Add(this.searchFormBtnClear);
            this.Controls.Add(this.searchFormBtnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchViewName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 348);
            this.Name = "SearchView";
            this.Text = "Поиск";
            ((System.ComponentModel.ISupportInitialize)(this.searchMovieFormEerrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CustomTextBox searchViewName;
        private CustomTextBox searchViewYear;
        private CustomTextBox searchViewCountry;
        private CustomTextBox searchViewDirector;
        private CustomTextBox searchViewActor;
        private System.Windows.Forms.Button searchFormBtnSearch;
        private System.Windows.Forms.Button searchFormBtnClear;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ErrorProvider searchMovieFormEerrorProvider;
    }
}