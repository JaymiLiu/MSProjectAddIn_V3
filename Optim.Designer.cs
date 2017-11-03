namespace GFabAddIn
{
    partial class Optim
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ProjLevel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ActLevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MSProjStartDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(335, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Level for individual project in MS project:";
            // 
            // ProjLevel
            // 
            this.ProjLevel.Location = new System.Drawing.Point(317, 31);
            this.ProjLevel.Name = "ProjLevel";
            this.ProjLevel.Size = new System.Drawing.Size(78, 20);
            this.ProjLevel.TabIndex = 2;
            this.ProjLevel.Text = "1";
            this.ProjLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Level for detailed activities in MS project:";
            // 
            // ActLevel
            // 
            this.ActLevel.Location = new System.Drawing.Point(317, 57);
            this.ActLevel.Name = "ActLevel";
            this.ActLevel.Size = new System.Drawing.Size(78, 20);
            this.ActLevel.TabIndex = 4;
            this.ActLevel.Text = "3";
            this.ActLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Please specify the start date to optimize the schedule\r\n(The schedule before this" +
    " date will be kept unchanged)";
            // 
            // MSProjStartDate
            // 
            this.MSProjStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.MSProjStartDate.Location = new System.Drawing.Point(286, 105);
            this.MSProjStartDate.Name = "MSProjStartDate";
            this.MSProjStartDate.Size = new System.Drawing.Size(109, 20);
            this.MSProjStartDate.TabIndex = 6;
            // 
            // Optim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 357);
            this.Controls.Add(this.MSProjStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ActLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProjLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Optim";
            this.Text = "Optimization";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProjLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ActLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker MSProjStartDate;
    }
}