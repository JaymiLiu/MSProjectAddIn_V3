using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSProject = Microsoft.Office.Interop.MSProject;

namespace GFabAddIn
{
    public partial class Optim : Form
    {
        public Optim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //Application;
            MSProject.Application app;
            MSProject.Project project;
            app = Globals.ThisAddIn.Application;
            project = app.ActiveProject;            

            OptimSch optimSch = new OptimSch();

            
            int projLevel = int.Parse(this.ProjLevel.Text);
            int girderLevel = int.Parse(this.gLevel.Text);
            int actLevel = int.Parse(this.ActLevel.Text);

            //###################################
            // Initialize the resource later by actual data, now by station
            int nbRsrc = 4;
            List<int> RsrcLimit = new List<int> {1, 1, 1, 1};
            //##########################################

            if (Convert.ToDateTime(MSProjStartDate.Text).AddDays(1) < project.ProjectStart)
            {
                MessageBox.Show("Please specify a date after the project start date: " + project.ProjectStart.ToString());
                this.Show();
            }
            else {
                OptimSch.MSprojectInfo projInfo = new OptimSch.MSprojectInfo(MSProjStartDate.Text, projLevel, girderLevel, actLevel, nbRsrc, RsrcLimit);
                optimSch.OptimizationSch(project, projInfo);
            }
        }
        
    }
}
