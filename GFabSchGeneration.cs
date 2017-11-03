using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using MSProject = Microsoft.Office.Interop.MSProject;
using Microsoft.VisualBasic;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace GFabAddIn
{
    public partial class GFabSchGeneration
    {
        private const int WHITE = 0xFFFFFF;
        private const int LIGHT_BLUE = 0xF0D9C6;

        MSProject.Application app;
        MSProject.Project project;

        private void GFabSchGeneration_Load(object sender, RibbonUIEventArgs e)
        {
            app = Globals.ThisAddIn.Application;
        }


        private void ShopSch_Click(object sender, RibbonControlEventArgs e)
        {
            project = app.ActiveProject;
            //project.Application.GroupApply("Text1");
            if (ShopSch.Label == "Schedule in Shop View")
            {
                project.Application.GroupBy();
                ShopSch.Label = "Schedule in Girder View";
            }
            else if (ShopSch.Label == "Schedule in Girder View")
            {
                project.Application.GroupClear();
                ShopSch.Label = "Schedule in Shop View";
            }
            
            //project.Application.CustomFieldRename(MSProject.PjCustomField.pjCustomTaskText1, "Station", Type.Missing);
        }
        

        private void DraftSch_Click(object sender, RibbonControlEventArgs e)
        {
            project = app.ActiveProject;
            if (project.Tasks.Count > 0)
                project = app.Projects.Add();

            Form DraftFrm = new DraftSch();
            DraftFrm.StartPosition = FormStartPosition.CenterScreen;
            DraftFrm.ShowDialog();
        }

        private void BtnGFab_Click(object sender, RibbonControlEventArgs e)
        {
            project = app.ActiveProject;
            //if (project.Tasks.Count > 0)
              //  project = app.Projects.Add();
            
            Form GFabFrm = new InputUI();
            GFabFrm.StartPosition = FormStartPosition.CenterScreen;
            GFabFrm.ShowDialog();
        }

        private void ProcureSch_Click(object sender, RibbonControlEventArgs e)
        {
            project = app.ActiveProject;
            if (project.Tasks.Count > 0)
                project = app.Projects.Add();

            Form ProcureFrm = new ProcureSch();
            ProcureFrm.StartPosition = FormStartPosition.CenterScreen;
            ProcureFrm.ShowDialog();
        }

        private void Other_Click(object sender, RibbonControlEventArgs e)
        {
            project = app.ActiveProject;
            if (project.Tasks.Count > 0)
                project = app.Projects.Add();

            Form OtherFrm = new Other();
            OtherFrm.StartPosition = FormStartPosition.CenterScreen;
            OtherFrm.ShowDialog();
        }

        private void OptiSch_Click(object sender, RibbonControlEventArgs e)
        {
            project = app.ActiveProject;
            Form OptimFrm = new Optim();
            OptimFrm.StartPosition = FormStartPosition.CenterScreen;
            OptimFrm.ShowDialog();

        }
    }
}
