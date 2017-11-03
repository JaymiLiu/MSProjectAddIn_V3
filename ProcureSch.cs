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
    public partial class ProcureSch : Form
    {
        public ProcureSch()
        {
            InitializeComponent();
            for (int i = 0; i < 11; i++)
            {
                dataGridProcure.Rows.Add();
                dataGridProcure.Rows[i].Cells["ID"].Value = i + 1;
            }

            //Inital procurement activities 
            dataGridProcure.Rows[0].Cells["actName"].Value = "Preliminary Web Plate Order";
            dataGridProcure.Rows[1].Cells["actName"].Value = "Preliminary Flange Plate Order";
            dataGridProcure.Rows[2].Cells["actName"].Value = "Finalize Web Plate Order";
            dataGridProcure.Rows[3].Cells["actName"].Value = "Finalize Flange Plate Order";
            dataGridProcure.Rows[4].Cells["actName"].Value = "Preliminary Structural Material Order";
            dataGridProcure.Rows[5].Cells["actName"].Value = "\"Roll Week\" Flange Plate Order";
            dataGridProcure.Rows[6].Cells["actName"].Value = "\"Roll Week\" Web Plate Order";
            dataGridProcure.Rows[7].Cells["actName"].Value = "Fill Flange Plate Order and Ship";
            dataGridProcure.Rows[8].Cells["actName"].Value = "Fill Web Plate Order and Ship";
            dataGridProcure.Rows[9].Cells["actName"].Value = "Fill Structural Material Order and Ship";
            dataGridProcure.Rows[10].Cells["actName"].Value = "Fill Stiffener and Splice Plate Order and Ship";

            dataGridProcure.Rows[0].Cells["Duration"].Value = "30.1 days";
            dataGridProcure.Rows[1].Cells["Duration"].Value = "28.8 days";
            dataGridProcure.Rows[2].Cells["Duration"].Value = "28.0 days";
            dataGridProcure.Rows[3].Cells["Duration"].Value = "33.8 days";
            dataGridProcure.Rows[4].Cells["Duration"].Value = "12.5 days";
            dataGridProcure.Rows[5].Cells["Duration"].Value = "4.3 days";
            dataGridProcure.Rows[6].Cells["Duration"].Value = "5.0 days";
            dataGridProcure.Rows[7].Cells["Duration"].Value = "15.1 days";
            dataGridProcure.Rows[8].Cells["Duration"].Value = "10.4 days";
            dataGridProcure.Rows[9].Cells["Duration"].Value = "34.0 days";
            dataGridProcure.Rows[10].Cells["Duration"].Value = "10.9 days";

            dataGridProcure.Rows[0].Cells["Pre"].Value = "";
            dataGridProcure.Rows[1].Cells["Pre"].Value = "";
            dataGridProcure.Rows[2].Cells["Pre"].Value = "1";
            dataGridProcure.Rows[3].Cells["Pre"].Value = "2";
            dataGridProcure.Rows[4].Cells["Pre"].Value = "";
            dataGridProcure.Rows[5].Cells["Pre"].Value = "4";
            dataGridProcure.Rows[6].Cells["Pre"].Value = "3";
            dataGridProcure.Rows[7].Cells["Pre"].Value = "6";
            dataGridProcure.Rows[8].Cells["Pre"].Value = "7";
            dataGridProcure.Rows[9].Cells["Pre"].Value = "5";
            dataGridProcure.Rows[10].Cells["Pre"].Value = "7";

            dataGridProcure.Rows[0].Cells["Lag"].Value = "";
            dataGridProcure.Rows[1].Cells["Lag"].Value = "";
            dataGridProcure.Rows[2].Cells["Lag"].Value = "0";
            dataGridProcure.Rows[3].Cells["Lag"].Value = "0";
            dataGridProcure.Rows[4].Cells["Lag"].Value = "";
            dataGridProcure.Rows[5].Cells["Lag"].Value = "0";
            dataGridProcure.Rows[6].Cells["Lag"].Value = "0";
            dataGridProcure.Rows[7].Cells["Lag"].Value = "0";
            dataGridProcure.Rows[8].Cells["Lag"].Value = "0";
            dataGridProcure.Rows[9].Cells["Lag"].Value = "0";
            dataGridProcure.Rows[10].Cells["Lag"].Value = "0";

            dataGridProcure.Rows[0].Cells["Type"].Value = "";
            dataGridProcure.Rows[1].Cells["Type"].Value = "";
            dataGridProcure.Rows[2].Cells["Type"].Value = "FS";
            dataGridProcure.Rows[3].Cells["Type"].Value = "FS";
            dataGridProcure.Rows[4].Cells["Type"].Value = "";
            dataGridProcure.Rows[5].Cells["Type"].Value = "FS";
            dataGridProcure.Rows[6].Cells["Type"].Value = "FS";
            dataGridProcure.Rows[7].Cells["Type"].Value = "FS";
            dataGridProcure.Rows[8].Cells["Type"].Value = "FS";
            dataGridProcure.Rows[9].Cells["Type"].Value = "FS";
            dataGridProcure.Rows[10].Cells["Type"].Value = "FS";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //Application;
            MSProject.Application app;
            MSProject.Project project;
            app = Globals.ThisAddIn.Application;
            project = app.ActiveProject;

            List<Activity> ProcureActivityList = new List<Activity>();

            string title = BName4Proq.Text + " " + DraftSum.Text;

            Activity sumActivity = new Activity(title);
            ProcureActivityList.Add(sumActivity);

            for (int i = 0; i < dataGridProcure.RowCount - 1; i++)
                for (int j = 0; j < dataGridProcure.ColumnCount; j++)
                {
                    if (dataGridProcure.Rows[i].Cells[j].Value == null)
                    {
                        dataGridProcure.Rows[i].Cells[j].Value = "";
                    }
                }

            for (int i = 0; i < dataGridProcure.RowCount - 1; i++)
            {

                Activity activity = new Activity(dataGridProcure.Rows[i].Cells["ID"].Value.ToString(), dataGridProcure.Rows[i].Cells["actName"].Value.ToString(), dataGridProcure.Rows[i].Cells["Duration"].Value.ToString(),
                    dataGridProcure.Rows[i].Cells["Pre"].Value.ToString().Split(',').ToList(), dataGridProcure.Rows[i].Cells["Lag"].Value.ToString().Split(',').ToList(),
                    dataGridProcure.Rows[i].Cells["Type"].Value.ToString().Split(',').ToList());
                ProcureActivityList.Add(activity);
            }

            SchGen schGen = new SchGen();
            schGen.CommonSch(project, ProcureActivityList, "Procurement", BDeadline4Proq.Text, 0);
            this.Close();
        }

        
    }
}
