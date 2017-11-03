namespace GFabAddIn
{
    partial class ProcureSch
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
            this.DraftSum = new System.Windows.Forms.Label();
            this.dataGridProcure = new System.Windows.Forms.DataGridView();
            this.BDeadline4Proq = new System.Windows.Forms.DateTimePicker();
            this.BName4Proq = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProcure)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(517, 389);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 130;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DraftSum
            // 
            this.DraftSum.AutoSize = true;
            this.DraftSum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DraftSum.Location = new System.Drawing.Point(10, 18);
            this.DraftSum.Name = "DraftSum";
            this.DraftSum.Size = new System.Drawing.Size(147, 19);
            this.DraftSum.TabIndex = 89;
            this.DraftSum.Text = "Summary Procurement";
            // 
            // dataGridProcure
            // 
            this.dataGridProcure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridProcure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProcure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.actName,
            this.Duration,
            this.Pre,
            this.Lag,
            this.Type});
            this.dataGridProcure.Location = new System.Drawing.Point(14, 97);
            this.dataGridProcure.Name = "dataGridProcure";
            this.dataGridProcure.Size = new System.Drawing.Size(578, 268);
            this.dataGridProcure.TabIndex = 151;
            // 
            // BDeadline4Proq
            // 
            this.BDeadline4Proq.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BDeadline4Proq.Location = new System.Drawing.Point(429, 54);
            this.BDeadline4Proq.Name = "BDeadline4Proq";
            this.BDeadline4Proq.Size = new System.Drawing.Size(104, 20);
            this.BDeadline4Proq.TabIndex = 156;
            // 
            // BName4Proq
            // 
            this.BName4Proq.AcceptsReturn = true;
            this.BName4Proq.AcceptsTab = true;
            this.BName4Proq.AllowDrop = true;
            this.BName4Proq.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BName4Proq.Location = new System.Drawing.Point(131, 54);
            this.BName4Proq.Name = "BName4Proq";
            this.BName4Proq.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.BName4Proq.Size = new System.Drawing.Size(105, 21);
            this.BName4Proq.TabIndex = 155;
            this.BName4Proq.Text = "NCP Stage 2";
            this.BName4Proq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(312, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 14);
            this.label18.TabIndex = 154;
            this.label18.Text = "(MM/DD/YYYY):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(294, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 15);
            this.label17.TabIndex = 153;
            this.label17.Text = "Deadline for procurement:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(58, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 15);
            this.label16.TabIndex = 152;
            this.label16.Text = "Bridge Name:";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // actName
            // 
            this.actName.HeaderText = "Activity Name";
            this.actName.Name = "actName";
            this.actName.Width = 135;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            // 
            // Pre
            // 
            this.Pre.HeaderText = "Predecessor";
            this.Pre.Name = "Pre";
            // 
            // Lag
            // 
            this.Lag.HeaderText = "Lag Time";
            this.Lag.Name = "Lag";
            // 
            // Type
            // 
            this.Type.HeaderText = "Relation Type";
            this.Type.Name = "Type";
            // 
            // ProcureSch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 424);
            this.Controls.Add(this.BDeadline4Proq);
            this.Controls.Add(this.BName4Proq);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dataGridProcure);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DraftSum);
            this.Name = "ProcureSch";
            this.Text = "ProcureSch";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProcure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label DraftSum;
        private System.Windows.Forms.DataGridView dataGridProcure;
        private System.Windows.Forms.DateTimePicker BDeadline4Proq;
        private System.Windows.Forms.TextBox BName4Proq;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn actName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}