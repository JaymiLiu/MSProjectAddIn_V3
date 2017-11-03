namespace GFabAddIn
{
    partial class GFabSchGeneration : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public GFabSchGeneration()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GFabSch = this.Factory.CreateRibbonTab();
            this.rGroupGFab = this.Factory.CreateRibbonGroup();
            this.BtnGFab = this.Factory.CreateRibbonButton();
            this.ShopSch = this.Factory.CreateRibbonToggleButton();
            this.tBtnScheduleOptimization = this.Factory.CreateRibbonToggleButton();
            this.rGroupSch = this.Factory.CreateRibbonGroup();
            this.DraftSch = this.Factory.CreateRibbonButton();
            this.ProcureSch = this.Factory.CreateRibbonButton();
            this.Other = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.OptiSch = this.Factory.CreateRibbonToggleButton();
            this.GFabSch.SuspendLayout();
            this.rGroupGFab.SuspendLayout();
            this.rGroupSch.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GFabSch
            // 
            this.GFabSch.Groups.Add(this.rGroupGFab);
            this.GFabSch.Groups.Add(this.rGroupSch);
            this.GFabSch.Groups.Add(this.group1);
            this.GFabSch.Label = "Bridge Sch. Generation";
            this.GFabSch.Name = "GFabSch";
            // 
            // rGroupGFab
            // 
            this.rGroupGFab.Items.Add(this.BtnGFab);
            this.rGroupGFab.Items.Add(this.ShopSch);
            this.rGroupGFab.Items.Add(this.tBtnScheduleOptimization);
            this.rGroupGFab.Label = "GFabSch";
            this.rGroupGFab.Name = "rGroupGFab";
            // 
            // BtnGFab
            // 
            this.BtnGFab.Label = "GFab Sch Generation";
            this.BtnGFab.Name = "BtnGFab";
            this.BtnGFab.OfficeImageId = "AdpDiagramColumnNames";
            this.BtnGFab.ShowImage = true;
            this.BtnGFab.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnGFab_Click);
            // 
            // ShopSch
            // 
            this.ShopSch.Label = "Schedule in Shop View";
            this.ShopSch.Name = "ShopSch";
            this.ShopSch.OfficeImageId = "AdpDiagramColumnNames";
            this.ShopSch.ShowImage = true;
            this.ShopSch.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShopSch_Click);
            // 
            // tBtnScheduleOptimization
            // 
            this.tBtnScheduleOptimization.Label = "";
            this.tBtnScheduleOptimization.Name = "tBtnScheduleOptimization";
            // 
            // rGroupSch
            // 
            this.rGroupSch.Items.Add(this.DraftSch);
            this.rGroupSch.Items.Add(this.ProcureSch);
            this.rGroupSch.Items.Add(this.Other);
            this.rGroupSch.Label = "Schedule";
            this.rGroupSch.Name = "rGroupSch";
            // 
            // DraftSch
            // 
            this.DraftSch.Label = "Drafting Schedule";
            this.DraftSch.Name = "DraftSch";
            this.DraftSch.OfficeImageId = "AdpDiagramColumnNames";
            this.DraftSch.ShowImage = true;
            this.DraftSch.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DraftSch_Click);
            // 
            // ProcureSch
            // 
            this.ProcureSch.Label = "Procurement Schedule";
            this.ProcureSch.Name = "ProcureSch";
            this.ProcureSch.OfficeImageId = "AdpDiagramColumnNames";
            this.ProcureSch.ShowImage = true;
            this.ProcureSch.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ProcureSch_Click);
            // 
            // Other
            // 
            this.Other.Label = "Others (Millstone, Client, Engineering)";
            this.Other.Name = "Other";
            this.Other.OfficeImageId = "AdpDiagramColumnNames";
            this.Other.ShowImage = true;
            this.Other.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Other_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.OptiSch);
            this.group1.Label = "Optimization";
            this.group1.Name = "group1";
            // 
            // OptiSch
            // 
            this.OptiSch.Label = "Optimize Schedule";
            this.OptiSch.Name = "OptiSch";
            this.OptiSch.OfficeImageId = "AdpDiagramColumnNames";
            this.OptiSch.ShowImage = true;
            this.OptiSch.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OptiSch_Click);
            // 
            // GFabSchGeneration
            // 
            this.Name = "GFabSchGeneration";
            this.RibbonType = "Microsoft.Project.Project";
            this.Tabs.Add(this.GFabSch);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.GFabSchGeneration_Load);
            this.GFabSch.ResumeLayout(false);
            this.GFabSch.PerformLayout();
            this.rGroupGFab.ResumeLayout(false);
            this.rGroupGFab.PerformLayout();
            this.rGroupSch.ResumeLayout(false);
            this.rGroupSch.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonTab GFabSch;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup rGroupGFab;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton tBtnScheduleOptimization;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton ShopSch;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup rGroupSch;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DraftSch;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnGFab;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ProcureSch;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Other;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton OptiSch;
    }

    partial class ThisRibbonCollection
    {
        internal GFabSchGeneration GFabSchGeneration
        {
            get { return this.GetRibbon<GFabSchGeneration>(); }
        }
    }
}
