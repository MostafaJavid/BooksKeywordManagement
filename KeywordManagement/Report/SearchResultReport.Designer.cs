namespace KeywordManagement.Report
{
    partial class frmSearchResultReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReferenceRedio = new System.Windows.Forms.RadioButton();
            this.SentenceReportRedio = new System.Windows.Forms.RadioButton();
            this.keywordRedio = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.saveReportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cbHierarchically = new System.Windows.Forms.CheckBox();
            this.cbOpenWord = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ReferenceRedio);
            this.panel1.Controls.Add(this.SentenceReportRedio);
            this.panel1.Controls.Add(this.keywordRedio);
            this.panel1.Location = new System.Drawing.Point(1, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 37);
            this.panel1.TabIndex = 1;
            // 
            // ReferenceRedio
            // 
            this.ReferenceRedio.AutoSize = true;
            this.ReferenceRedio.Location = new System.Drawing.Point(62, 10);
            this.ReferenceRedio.Name = "ReferenceRedio";
            this.ReferenceRedio.Size = new System.Drawing.Size(63, 17);
            this.ReferenceRedio.TabIndex = 2;
            this.ReferenceRedio.Text = "ارجاعات";
            this.ReferenceRedio.UseVisualStyleBackColor = true;
            // 
            // SentenceReportRedio
            // 
            this.SentenceReportRedio.AutoSize = true;
            this.SentenceReportRedio.Location = new System.Drawing.Point(139, 10);
            this.SentenceReportRedio.Name = "SentenceReportRedio";
            this.SentenceReportRedio.Size = new System.Drawing.Size(52, 17);
            this.SentenceReportRedio.TabIndex = 1;
            this.SentenceReportRedio.Text = "جملات";
            this.SentenceReportRedio.UseVisualStyleBackColor = true;
            // 
            // keywordRedio
            // 
            this.keywordRedio.AutoSize = true;
            this.keywordRedio.Checked = true;
            this.keywordRedio.Location = new System.Drawing.Point(213, 10);
            this.keywordRedio.Name = "keywordRedio";
            this.keywordRedio.Size = new System.Drawing.Size(52, 17);
            this.keywordRedio.TabIndex = 0;
            this.keywordRedio.TabStop = true;
            this.keywordRedio.Text = "کلمات";
            this.keywordRedio.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(179, 93);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(85, 93);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "انصراف";
            this.btnCancle.UseVisualStyleBackColor = true;
            // 
            // saveReportFileDialog
            // 
            this.saveReportFileDialog.Filter = "Word files|*.docx";
            this.saveReportFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveReportFileDialog_FileOk);
            // 
            // cbHierarchically
            // 
            this.cbHierarchically.AutoSize = true;
            this.cbHierarchically.Checked = true;
            this.cbHierarchically.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHierarchically.Location = new System.Drawing.Point(232, 12);
            this.cbHierarchically.Name = "cbHierarchically";
            this.cbHierarchically.Size = new System.Drawing.Size(115, 17);
            this.cbHierarchically.TabIndex = 4;
            this.cbHierarchically.Text = "نمایش سلسه مراتبی";
            this.cbHierarchically.UseVisualStyleBackColor = true;
            // 
            // cbOpenWord
            // 
            this.cbOpenWord.AutoSize = true;
            this.cbOpenWord.Location = new System.Drawing.Point(127, 12);
            this.cbOpenWord.Name = "cbOpenWord";
            this.cbOpenWord.Size = new System.Drawing.Size(92, 17);
            this.cbOpenWord.TabIndex = 5;
            this.cbOpenWord.Text = "بازکردن Word";
            this.cbOpenWord.UseVisualStyleBackColor = true;
            // 
            // frmSearchResultReport
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(349, 135);
            this.Controls.Add(this.cbOpenWord);
            this.Controls.Add(this.cbHierarchically);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Name = "frmSearchResultReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش نتایج جستجو";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton ReferenceRedio;
        private System.Windows.Forms.RadioButton SentenceReportRedio;
        private System.Windows.Forms.RadioButton keywordRedio;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.SaveFileDialog saveReportFileDialog;
        private System.Windows.Forms.CheckBox cbHierarchically;
        private System.Windows.Forms.CheckBox cbOpenWord;
    }
}