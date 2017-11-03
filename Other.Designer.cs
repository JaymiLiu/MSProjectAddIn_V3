namespace GFabAddIn
{
    partial class Other
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
            this.EngineeringSum = new System.Windows.Forms.Label();
            this.dataGridClient = new System.Windows.Forms.DataGridView();
            this.dataGridEngineer = new System.Windows.Forms.DataGridView();
            this.Millstone = new System.Windows.Forms.Label();
            this.ClientSum = new System.Windows.Forms.Label();
            this.dataGridMilestone = new System.Windows.Forms.DataGridView();
            this.BDeadline4Others = new System.Windows.Forms.DateTimePicker();
            this.BName4Others = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pre2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lag2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actName3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pre3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lag3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEngineer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMilestone)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(557, 562);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 192;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EngineeringSum
            // 
            this.EngineeringSum.AutoSize = true;
            this.EngineeringSum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EngineeringSum.Location = new System.Drawing.Point(19, 416);
            this.EngineeringSum.Name = "EngineeringSum";
            this.EngineeringSum.Size = new System.Drawing.Size(78, 19);
            this.EngineeringSum.TabIndex = 203;
            this.EngineeringSum.Text = "Engineering";
            // 
            // dataGridClient
            // 
            this.dataGridClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID2,
            this.actName2,
            this.Duration2,
            this.Pre2,
            this.Lag2,
            this.Type2});
            this.dataGridClient.Location = new System.Drawing.Point(23, 231);
            this.dataGridClient.Name = "dataGridClient";
            this.dataGridClient.Size = new System.Drawing.Size(609, 160);
            this.dataGridClient.TabIndex = 205;
            // 
            // dataGridEngineer
            // 
            this.dataGridEngineer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridEngineer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEngineer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID3,
            this.actName3,
            this.Duration3,
            this.Pre3,
            this.Lag3,
            this.Type3});
            this.dataGridEngineer.Location = new System.Drawing.Point(23, 438);
            this.dataGridEngineer.Name = "dataGridEngineer";
            this.dataGridEngineer.Size = new System.Drawing.Size(609, 107);
            this.dataGridEngineer.TabIndex = 206;
            // 
            // Millstone
            // 
            this.Millstone.AutoSize = true;
            this.Millstone.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Millstone.Location = new System.Drawing.Point(19, 64);
            this.Millstone.Name = "Millstone";
            this.Millstone.Size = new System.Drawing.Size(74, 19);
            this.Millstone.TabIndex = 151;
            this.Millstone.Text = "Milestones";
            // 
            // ClientSum
            // 
            this.ClientSum.AutoSize = true;
            this.ClientSum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSum.Location = new System.Drawing.Point(19, 209);
            this.ClientSum.Name = "ClientSum";
            this.ClientSum.Size = new System.Drawing.Size(44, 19);
            this.ClientSum.TabIndex = 202;
            this.ClientSum.Text = "Client";
            // 
            // dataGridMilestone
            // 
            this.dataGridMilestone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridMilestone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMilestone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID1,
            this.actName,
            this.Duration,
            this.Pre,
            this.Lag,
            this.Type});
            this.dataGridMilestone.Location = new System.Drawing.Point(23, 86);
            this.dataGridMilestone.Name = "dataGridMilestone";
            this.dataGridMilestone.Size = new System.Drawing.Size(609, 100);
            this.dataGridMilestone.TabIndex = 204;
            // 
            // BDeadline4Others
            // 
            this.BDeadline4Others.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BDeadline4Others.Location = new System.Drawing.Point(460, 24);
            this.BDeadline4Others.Name = "BDeadline4Others";
            this.BDeadline4Others.Size = new System.Drawing.Size(104, 20);
            this.BDeadline4Others.TabIndex = 211;
            // 
            // BName4Others
            // 
            this.BName4Others.AcceptsReturn = true;
            this.BName4Others.AcceptsTab = true;
            this.BName4Others.AllowDrop = true;
            this.BName4Others.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BName4Others.Location = new System.Drawing.Point(162, 23);
            this.BName4Others.Name = "BName4Others";
            this.BName4Others.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.BName4Others.Size = new System.Drawing.Size(105, 21);
            this.BName4Others.TabIndex = 210;
            this.BName4Others.Text = "NCP Stage 2";
            this.BName4Others.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(343, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 14);
            this.label18.TabIndex = 209;
            this.label18.Text = "(MM/DD/YYYY):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(343, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 15);
            this.label17.TabIndex = 208;
            this.label17.Text = "Bridge Deadline:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(89, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 15);
            this.label16.TabIndex = 207;
            this.label16.Text = "Bridge Name:";
            // 
            // ID1
            // 
            this.ID1.HeaderText = "ID";
            this.ID1.Name = "ID1";
            // 
            // actName
            // 
            this.actName.HeaderText = "Activity Name";
            this.actName.Name = "actName";
            this.actName.Width = 113;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.Width = 112;
            // 
            // Pre
            // 
            this.Pre.HeaderText = "Predecessor";
            this.Pre.Name = "Pre";
            this.Pre.Width = 114;
            // 
            // Lag
            // 
            this.Lag.HeaderText = "Lag Time";
            this.Lag.Name = "Lag";
            this.Lag.Width = 113;
            // 
            // Type
            // 
            this.Type.HeaderText = "Relation Type";
            this.Type.Name = "Type";
            this.Type.Width = 114;
            // 
            // ID2
            // 
            this.ID2.HeaderText = "ID";
            this.ID2.Name = "ID2";
            // 
            // actName2
            // 
            this.actName2.HeaderText = "Activity Name";
            this.actName2.Name = "actName2";
            this.actName2.Width = 113;
            // 
            // Duration2
            // 
            this.Duration2.HeaderText = "Duration";
            this.Duration2.Name = "Duration2";
            this.Duration2.Width = 113;
            // 
            // Pre2
            // 
            this.Pre2.HeaderText = "Predecessor";
            this.Pre2.Name = "Pre2";
            this.Pre2.Width = 114;
            // 
            // Lag2
            // 
            this.Lag2.HeaderText = "Lag Time";
            this.Lag2.Name = "Lag2";
            this.Lag2.Width = 113;
            // 
            // Type2
            // 
            this.Type2.HeaderText = "Relation Type";
            this.Type2.Name = "Type2";
            this.Type2.Width = 113;
            // 
            // ID3
            // 
            this.ID3.HeaderText = "ID";
            this.ID3.Name = "ID3";
            // 
            // actName3
            // 
            this.actName3.HeaderText = "Activity Name";
            this.actName3.Name = "actName3";
            this.actName3.Width = 166;
            // 
            // Duration3
            // 
            this.Duration3.HeaderText = "Duration";
            this.Duration3.Name = "Duration3";
            // 
            // Pre3
            // 
            this.Pre3.HeaderText = "Predecessor";
            this.Pre3.Name = "Pre3";
            // 
            // Lag3
            // 
            this.Lag3.HeaderText = "Lag Time";
            this.Lag3.Name = "Lag3";
            // 
            // Type3
            // 
            this.Type3.HeaderText = "Relation Type";
            this.Type3.Name = "Type3";
            // 
            // Other
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 594);
            this.Controls.Add(this.BDeadline4Others);
            this.Controls.Add(this.BName4Others);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dataGridEngineer);
            this.Controls.Add(this.dataGridClient);
            this.Controls.Add(this.dataGridMilestone);
            this.Controls.Add(this.EngineeringSum);
            this.Controls.Add(this.ClientSum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Millstone);
            this.Name = "Other";
            this.Text = "Other";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEngineer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMilestone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label EngineeringSum;
        private System.Windows.Forms.DataGridView dataGridClient;
        private System.Windows.Forms.DataGridView dataGridEngineer;
        private System.Windows.Forms.Label Millstone;
        private System.Windows.Forms.Label ClientSum;
        private System.Windows.Forms.DataGridView dataGridMilestone;
        private System.Windows.Forms.DateTimePicker BDeadline4Others;
        private System.Windows.Forms.TextBox BName4Others;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn actName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pre2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lag2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID3;
        private System.Windows.Forms.DataGridViewTextBoxColumn actName3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pre3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lag3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn actName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
    }
}