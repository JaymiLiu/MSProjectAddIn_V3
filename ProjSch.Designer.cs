namespace GFabAddIn
{
    partial class ProjSch
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
            this.ShopCap = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.SSB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RASPre = new System.Windows.Forms.TextBox();
            this.ShipPre = new System.Windows.Forms.TextBox();
            this.RTSPre = new System.Windows.Forms.TextBox();
            this.FSPre = new System.Windows.Forms.TextBox();
            this.GAPre = new System.Windows.Forms.TextBox();
            this.PrePre = new System.Windows.Forms.TextBox();
            this.RASDuration = new System.Windows.Forms.TextBox();
            this.RTSDuration = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ShipDuration = new System.Windows.Forms.TextBox();
            this.RAS = new System.Windows.Forms.Label();
            this.Ship = new System.Windows.Forms.Label();
            this.RTS = new System.Windows.Forms.Label();
            this.FSDuration = new System.Windows.Forms.TextBox();
            this.FS = new System.Windows.Forms.Label();
            this.GAduration = new System.Windows.Forms.TextBox();
            this.PreDuration = new System.Windows.Forms.TextBox();
            this.GA = new System.Windows.Forms.Label();
            this.Pre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SRLagTime = new System.Windows.Forms.TextBox();
            this.RSLagTime = new System.Windows.Forms.TextBox();
            this.FRLagTime = new System.Windows.Forms.TextBox();
            this.GFLagTime = new System.Windows.Forms.TextBox();
            this.PGLagTime = new System.Windows.Forms.TextBox();
            this.PreLagTime = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ShopCap)).BeginInit();
            this.SuspendLayout();
            // 
            // ShopCap
            // 
            this.ShopCap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ShopCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShopCap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SSB,
            this.SSE,
            this.SSV,
            this.SSW,
            this.SSS});
            this.ShopCap.Location = new System.Drawing.Point(34, 298);
            this.ShopCap.Name = "ShopCap";
            this.ShopCap.Size = new System.Drawing.Size(508, 151);
            this.ShopCap.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 19);
            this.label4.TabIndex = 67;
            this.label4.Text = "Step 3: Specify No. of production line";
            // 
            // SSB
            // 
            this.SSB.HeaderText = "SSB";
            this.SSB.Name = "SSB";
            // 
            // SSE
            // 
            this.SSE.HeaderText = "SSE";
            this.SSE.Name = "SSE";
            // 
            // SSV
            // 
            this.SSV.HeaderText = "SSV";
            this.SSV.Name = "SSV";
            // 
            // SSW
            // 
            this.SSW.HeaderText = "SSW";
            this.SSW.Name = "SSW";
            // 
            // SSS
            // 
            this.SSS.HeaderText = "SSS";
            this.SSS.Name = "SSS";
            // 
            // RASPre
            // 
            this.RASPre.AcceptsReturn = true;
            this.RASPre.AcceptsTab = true;
            this.RASPre.AllowDrop = true;
            this.RASPre.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RASPre.Location = new System.Drawing.Point(258, 218);
            this.RASPre.Name = "RASPre";
            this.RASPre.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.RASPre.Size = new System.Drawing.Size(57, 23);
            this.RASPre.TabIndex = 94;
            this.RASPre.Text = "5";
            this.RASPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ShipPre
            // 
            this.ShipPre.AcceptsReturn = true;
            this.ShipPre.AcceptsTab = true;
            this.ShipPre.AllowDrop = true;
            this.ShipPre.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShipPre.Location = new System.Drawing.Point(258, 186);
            this.ShipPre.Name = "ShipPre";
            this.ShipPre.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ShipPre.Size = new System.Drawing.Size(57, 23);
            this.ShipPre.TabIndex = 93;
            this.ShipPre.Text = "4";
            this.ShipPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RTSPre
            // 
            this.RTSPre.AcceptsReturn = true;
            this.RTSPre.AcceptsTab = true;
            this.RTSPre.AllowDrop = true;
            this.RTSPre.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTSPre.Location = new System.Drawing.Point(258, 158);
            this.RTSPre.Name = "RTSPre";
            this.RTSPre.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.RTSPre.Size = new System.Drawing.Size(57, 23);
            this.RTSPre.TabIndex = 92;
            this.RTSPre.Text = "3";
            this.RTSPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FSPre
            // 
            this.FSPre.AcceptsReturn = true;
            this.FSPre.AcceptsTab = true;
            this.FSPre.AllowDrop = true;
            this.FSPre.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FSPre.Location = new System.Drawing.Point(258, 129);
            this.FSPre.Name = "FSPre";
            this.FSPre.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.FSPre.Size = new System.Drawing.Size(57, 23);
            this.FSPre.TabIndex = 91;
            this.FSPre.Text = "2";
            this.FSPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GAPre
            // 
            this.GAPre.AcceptsReturn = true;
            this.GAPre.AcceptsTab = true;
            this.GAPre.AllowDrop = true;
            this.GAPre.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GAPre.Location = new System.Drawing.Point(258, 100);
            this.GAPre.Name = "GAPre";
            this.GAPre.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.GAPre.Size = new System.Drawing.Size(57, 23);
            this.GAPre.TabIndex = 90;
            this.GAPre.Text = "1";
            this.GAPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PrePre
            // 
            this.PrePre.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrePre.Location = new System.Drawing.Point(258, 71);
            this.PrePre.Name = "PrePre";
            this.PrePre.ReadOnly = true;
            this.PrePre.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.PrePre.Size = new System.Drawing.Size(57, 23);
            this.PrePre.TabIndex = 89;
            this.PrePre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RASDuration
            // 
            this.RASDuration.AcceptsReturn = true;
            this.RASDuration.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RASDuration.Location = new System.Drawing.Point(174, 217);
            this.RASDuration.Name = "RASDuration";
            this.RASDuration.ReadOnly = true;
            this.RASDuration.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.RASDuration.Size = new System.Drawing.Size(57, 23);
            this.RASDuration.TabIndex = 88;
            this.RASDuration.Text = "0 day";
            this.RASDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RTSDuration
            // 
            this.RTSDuration.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTSDuration.Location = new System.Drawing.Point(174, 158);
            this.RTSDuration.Name = "RTSDuration";
            this.RTSDuration.ReadOnly = true;
            this.RTSDuration.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.RTSDuration.Size = new System.Drawing.Size(57, 23);
            this.RTSDuration.TabIndex = 87;
            this.RTSDuration.Text = "0 day";
            this.RTSDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(338, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 16);
            this.label13.TabIndex = 86;
            this.label13.Text = "Lag Time";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(255, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 16);
            this.label12.TabIndex = 85;
            this.label12.Text = "Predecessor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(174, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 16);
            this.label11.TabIndex = 84;
            this.label11.Text = "Duration";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(58, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 16);
            this.label10.TabIndex = 83;
            this.label10.Text = "Activity Name";
            // 
            // ShipDuration
            // 
            this.ShipDuration.AcceptsReturn = true;
            this.ShipDuration.AcceptsTab = true;
            this.ShipDuration.AllowDrop = true;
            this.ShipDuration.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShipDuration.Location = new System.Drawing.Point(174, 188);
            this.ShipDuration.Name = "ShipDuration";
            this.ShipDuration.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ShipDuration.Size = new System.Drawing.Size(57, 23);
            this.ShipDuration.TabIndex = 82;
            this.ShipDuration.Text = "3 days";
            this.ShipDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RAS
            // 
            this.RAS.AutoSize = true;
            this.RAS.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RAS.Location = new System.Drawing.Point(52, 221);
            this.RAS.Name = "RAS";
            this.RAS.Size = new System.Drawing.Size(49, 16);
            this.RAS.TabIndex = 77;
            this.RAS.Text = "6. RAS";
            // 
            // Ship
            // 
            this.Ship.AutoSize = true;
            this.Ship.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ship.Location = new System.Drawing.Point(52, 189);
            this.Ship.Name = "Ship";
            this.Ship.Size = new System.Drawing.Size(72, 16);
            this.Ship.TabIndex = 76;
            this.Ship.Text = "5. Shipping";
            // 
            // RTS
            // 
            this.RTS.AutoSize = true;
            this.RTS.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTS.Location = new System.Drawing.Point(52, 161);
            this.RTS.Name = "RTS";
            this.RTS.Size = new System.Drawing.Size(48, 16);
            this.RTS.TabIndex = 75;
            this.RTS.Text = "4. RTS";
            // 
            // FSDuration
            // 
            this.FSDuration.AcceptsReturn = true;
            this.FSDuration.AcceptsTab = true;
            this.FSDuration.AllowDrop = true;
            this.FSDuration.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FSDuration.Location = new System.Drawing.Point(174, 129);
            this.FSDuration.Name = "FSDuration";
            this.FSDuration.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.FSDuration.Size = new System.Drawing.Size(57, 23);
            this.FSDuration.TabIndex = 74;
            this.FSDuration.Text = "4 days";
            this.FSDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FS
            // 
            this.FS.AutoSize = true;
            this.FS.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FS.Location = new System.Drawing.Point(52, 132);
            this.FS.Name = "FS";
            this.FS.Size = new System.Drawing.Size(88, 16);
            this.FS.TabIndex = 73;
            this.FS.Text = "3. Field Splice";
            // 
            // GAduration
            // 
            this.GAduration.AcceptsReturn = true;
            this.GAduration.AcceptsTab = true;
            this.GAduration.AllowDrop = true;
            this.GAduration.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GAduration.Location = new System.Drawing.Point(174, 100);
            this.GAduration.Name = "GAduration";
            this.GAduration.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.GAduration.Size = new System.Drawing.Size(57, 23);
            this.GAduration.TabIndex = 72;
            this.GAduration.Text = "3 days";
            this.GAduration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PreDuration
            // 
            this.PreDuration.AcceptsReturn = true;
            this.PreDuration.AcceptsTab = true;
            this.PreDuration.AllowDrop = true;
            this.PreDuration.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreDuration.Location = new System.Drawing.Point(174, 71);
            this.PreDuration.Name = "PreDuration";
            this.PreDuration.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.PreDuration.Size = new System.Drawing.Size(57, 23);
            this.PreDuration.TabIndex = 71;
            this.PreDuration.Text = "3 days";
            this.PreDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GA
            // 
            this.GA.AutoSize = true;
            this.GA.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GA.Location = new System.Drawing.Point(52, 103);
            this.GA.Name = "GA";
            this.GA.Size = new System.Drawing.Size(117, 16);
            this.GA.TabIndex = 70;
            this.GA.Text = "2. Girder Assembly";
            // 
            // Pre
            // 
            this.Pre.AutoSize = true;
            this.Pre.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pre.Location = new System.Drawing.Point(52, 77);
            this.Pre.Name = "Pre";
            this.Pre.Size = new System.Drawing.Size(87, 16);
            this.Pre.TabIndex = 69;
            this.Pre.Text = "1. Preparation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 19);
            this.label2.TabIndex = 68;
            this.label2.Text = "Step 1: Modify the template";
            // 
            // OK
            // 
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(504, 455);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 97;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // SRLagTime
            // 
            this.SRLagTime.AcceptsReturn = true;
            this.SRLagTime.AcceptsTab = true;
            this.SRLagTime.AllowDrop = true;
            this.SRLagTime.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SRLagTime.Location = new System.Drawing.Point(341, 218);
            this.SRLagTime.Name = "SRLagTime";
            this.SRLagTime.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SRLagTime.Size = new System.Drawing.Size(57, 23);
            this.SRLagTime.TabIndex = 96;
            this.SRLagTime.Text = "0 day";
            this.SRLagTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RSLagTime
            // 
            this.RSLagTime.AcceptsReturn = true;
            this.RSLagTime.AcceptsTab = true;
            this.RSLagTime.AllowDrop = true;
            this.RSLagTime.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RSLagTime.Location = new System.Drawing.Point(341, 186);
            this.RSLagTime.Name = "RSLagTime";
            this.RSLagTime.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.RSLagTime.Size = new System.Drawing.Size(57, 23);
            this.RSLagTime.TabIndex = 81;
            this.RSLagTime.Text = "0 day";
            this.RSLagTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FRLagTime
            // 
            this.FRLagTime.AcceptsReturn = true;
            this.FRLagTime.AcceptsTab = true;
            this.FRLagTime.AllowDrop = true;
            this.FRLagTime.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FRLagTime.Location = new System.Drawing.Point(341, 158);
            this.FRLagTime.Name = "FRLagTime";
            this.FRLagTime.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.FRLagTime.Size = new System.Drawing.Size(57, 23);
            this.FRLagTime.TabIndex = 80;
            this.FRLagTime.Text = "1 day";
            this.FRLagTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GFLagTime
            // 
            this.GFLagTime.AcceptsReturn = true;
            this.GFLagTime.AcceptsTab = true;
            this.GFLagTime.AllowDrop = true;
            this.GFLagTime.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GFLagTime.Location = new System.Drawing.Point(341, 129);
            this.GFLagTime.Name = "GFLagTime";
            this.GFLagTime.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.GFLagTime.Size = new System.Drawing.Size(57, 23);
            this.GFLagTime.TabIndex = 79;
            this.GFLagTime.Text = "2 days";
            this.GFLagTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PGLagTime
            // 
            this.PGLagTime.AcceptsReturn = true;
            this.PGLagTime.AcceptsTab = true;
            this.PGLagTime.AllowDrop = true;
            this.PGLagTime.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PGLagTime.Location = new System.Drawing.Point(341, 100);
            this.PGLagTime.Name = "PGLagTime";
            this.PGLagTime.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.PGLagTime.Size = new System.Drawing.Size(57, 23);
            this.PGLagTime.TabIndex = 78;
            this.PGLagTime.Text = "1 day";
            this.PGLagTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PreLagTime
            // 
            this.PreLagTime.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreLagTime.Location = new System.Drawing.Point(341, 71);
            this.PreLagTime.Name = "PreLagTime";
            this.PreLagTime.ReadOnly = true;
            this.PreLagTime.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.PreLagTime.Size = new System.Drawing.Size(57, 23);
            this.PreLagTime.TabIndex = 95;
            this.PreLagTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProjSch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 490);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.SRLagTime);
            this.Controls.Add(this.PreLagTime);
            this.Controls.Add(this.RASPre);
            this.Controls.Add(this.ShipPre);
            this.Controls.Add(this.RTSPre);
            this.Controls.Add(this.FSPre);
            this.Controls.Add(this.GAPre);
            this.Controls.Add(this.PrePre);
            this.Controls.Add(this.RASDuration);
            this.Controls.Add(this.RTSDuration);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ShipDuration);
            this.Controls.Add(this.RSLagTime);
            this.Controls.Add(this.FRLagTime);
            this.Controls.Add(this.GFLagTime);
            this.Controls.Add(this.PGLagTime);
            this.Controls.Add(this.RAS);
            this.Controls.Add(this.Ship);
            this.Controls.Add(this.RTS);
            this.Controls.Add(this.FSDuration);
            this.Controls.Add(this.FS);
            this.Controls.Add(this.GAduration);
            this.Controls.Add(this.PreDuration);
            this.Controls.Add(this.GA);
            this.Controls.Add(this.Pre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ShopCap);
            this.Name = "ProjSch";
            this.Text = "Generate Project Level Schedule";
            ((System.ComponentModel.ISupportInitialize)(this.ShopCap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ShopCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSB;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSW;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RASPre;
        private System.Windows.Forms.TextBox ShipPre;
        private System.Windows.Forms.TextBox RTSPre;
        private System.Windows.Forms.TextBox FSPre;
        private System.Windows.Forms.TextBox GAPre;
        private System.Windows.Forms.TextBox PrePre;
        private System.Windows.Forms.TextBox RASDuration;
        private System.Windows.Forms.TextBox RTSDuration;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ShipDuration;
        private System.Windows.Forms.Label RAS;
        private System.Windows.Forms.Label Ship;
        private System.Windows.Forms.Label RTS;
        private System.Windows.Forms.TextBox FSDuration;
        private System.Windows.Forms.Label FS;
        private System.Windows.Forms.TextBox GAduration;
        private System.Windows.Forms.TextBox PreDuration;
        private System.Windows.Forms.Label GA;
        private System.Windows.Forms.Label Pre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.TextBox SRLagTime;
        private System.Windows.Forms.TextBox RSLagTime;
        private System.Windows.Forms.TextBox FRLagTime;
        private System.Windows.Forms.TextBox GFLagTime;
        private System.Windows.Forms.TextBox PGLagTime;
        private System.Windows.Forms.TextBox PreLagTime;
    }
}