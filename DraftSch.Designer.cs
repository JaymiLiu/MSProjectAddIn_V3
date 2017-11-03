namespace GFabAddIn
{
    partial class DraftSch
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
            this.DraftSum = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridDraft = new System.Windows.Forms.DataGridView();
            this.BDeadline4Draft = new System.Windows.Forms.DateTimePicker();
            this.BName4Draft = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDraft)).BeginInit();
            this.SuspendLayout();
            // 
            // DraftSum
            // 
            this.DraftSum.AutoSize = true;
            this.DraftSum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DraftSum.Location = new System.Drawing.Point(12, 24);
            this.DraftSum.Name = "DraftSum";
            this.DraftSum.Size = new System.Drawing.Size(118, 19);
            this.DraftSum.TabIndex = 28;
            this.DraftSum.Text = "Summary Drafting";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(542, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 78;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridDraft
            // 
            this.dataGridDraft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridDraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDraft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.actName,
            this.Duration,
            this.Pre,
            this.Lag,
            this.Type});
            this.dataGridDraft.Location = new System.Drawing.Point(16, 95);
            this.dataGridDraft.Name = "dataGridDraft";
            this.dataGridDraft.Size = new System.Drawing.Size(601, 286);
            this.dataGridDraft.TabIndex = 89;
            // 
            // BDeadline4Draft
            // 
            this.BDeadline4Draft.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BDeadline4Draft.Location = new System.Drawing.Point(417, 52);
            this.BDeadline4Draft.Name = "BDeadline4Draft";
            this.BDeadline4Draft.Size = new System.Drawing.Size(104, 20);
            this.BDeadline4Draft.TabIndex = 94;
            // 
            // BName4Draft
            // 
            this.BName4Draft.AcceptsReturn = true;
            this.BName4Draft.AcceptsTab = true;
            this.BName4Draft.AllowDrop = true;
            this.BName4Draft.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BName4Draft.Location = new System.Drawing.Point(119, 52);
            this.BName4Draft.Name = "BName4Draft";
            this.BName4Draft.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.BName4Draft.Size = new System.Drawing.Size(105, 21);
            this.BName4Draft.TabIndex = 93;
            this.BName4Draft.Text = "NCP Stage 2";
            this.BName4Draft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(300, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 14);
            this.label18.TabIndex = 92;
            this.label18.Text = "(MM/DD/YYYY):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(300, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 15);
            this.label17.TabIndex = 91;
            this.label17.Text = "Deadline for drafting:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(46, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 15);
            this.label16.TabIndex = 90;
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
            this.actName.Width = 129;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.Width = 129;
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
            // DraftSch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 424);
            this.Controls.Add(this.BDeadline4Draft);
            this.Controls.Add(this.BName4Draft);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dataGridDraft);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DraftSum);
            this.Name = "DraftSch";
            this.Text = "DraftSch";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDraft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label DraftSum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridDraft;
        private System.Windows.Forms.DateTimePicker BDeadline4Draft;
        private System.Windows.Forms.TextBox BName4Draft;
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