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
    public partial class Other : Form
    {
        public Other()
        {
            InitializeComponent();
            dataGridMilestone.Rows.Add();
            dataGridMilestone.Rows[0].Cells["ID1"].Value = 1;
            dataGridEngineer.Rows.Add();
            dataGridEngineer.Rows[0].Cells["ID3"].Value = 1;
            for (int i = 0; i < 5; i++)
            {
                dataGridClient.Rows.Add();
                dataGridClient.Rows[i].Cells["ID2"].Value = i + 1;
            }
            
            //Initial Milestone activities 
            dataGridMilestone.Rows[0].Cells["actName"].Value = "Sign Contract";
            dataGridMilestone.Rows[0].Cells["Duration"].Value = "0.0 day";
            dataGridMilestone.Rows[0].Cells["Pre"].Value = "";
            dataGridMilestone.Rows[0].Cells["Lag"].Value = "";
            dataGridMilestone.Rows[0].Cells["Type"].Value = "";

            //Initial Client activities
            dataGridClient.Rows[0].Cells["actName2"].Value = "Customer Review and Approval of Plate Shop Drawings";
            dataGridClient.Rows[1].Cells["actName2"].Value = "Customer Review of Shop and Erection Drawings";
            dataGridClient.Rows[2].Cells["actName2"].Value = "Customer Review of Erection Procedure";
            dataGridClient.Rows[3].Cells["actName2"].Value = "Pre-Fabrication Meeting (with Client)";
            dataGridClient.Rows[4].Cells["actName2"].Value = "Client Approved Fabrication Start Date";

            dataGridClient.Rows[0].Cells["Duration2"].Value = "2.5 days";
            dataGridClient.Rows[1].Cells["Duration2"].Value = "8.3 days";
            dataGridClient.Rows[2].Cells["Duration2"].Value = "7.5 days";
            dataGridClient.Rows[3].Cells["Duration2"].Value = "1.3 days";
            dataGridClient.Rows[4].Cells["Duration2"].Value = "0.0 days";

            dataGridClient.Rows[0].Cells["Pre2"].Value = "";
            dataGridClient.Rows[1].Cells["Pre2"].Value = "";
            dataGridClient.Rows[2].Cells["Pre2"].Value = "";
            dataGridClient.Rows[3].Cells["Pre2"].Value = "2";
            dataGridClient.Rows[4].Cells["Pre2"].Value = "4";

            dataGridClient.Rows[0].Cells["Lag2"].Value = "";
            dataGridClient.Rows[1].Cells["Lag2"].Value = "";
            dataGridClient.Rows[2].Cells["Lag2"].Value = "";
            dataGridClient.Rows[3].Cells["Lag2"].Value = "0";
            dataGridClient.Rows[4].Cells["Lag2"].Value = "12.5 days";

            dataGridClient.Rows[0].Cells["Type2"].Value = "";
            dataGridClient.Rows[1].Cells["Type2"].Value = "";
            dataGridClient.Rows[2].Cells["Type2"].Value = "";
            dataGridClient.Rows[3].Cells["Type2"].Value = "FS";
            dataGridClient.Rows[4].Cells["Type2"].Value = "FS";

            //Initial Engineering activities 
            dataGridEngineer.Rows[0].Cells["actName3"].Value = "Design Connections";
            dataGridEngineer.Rows[0].Cells["Duration3"].Value = "25.0 day";
            dataGridEngineer.Rows[0].Cells["Pre3"].Value = "";
            dataGridEngineer.Rows[0].Cells["Lag3"].Value = "";
            dataGridEngineer.Rows[0].Cells["Type3"].Value = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //Application;
            MSProject.Application app;
            MSProject.Project project;
            app = Globals.ThisAddIn.Application;
            project = app.ActiveProject;

            List<Activity> MillstoneActivityList = new List<Activity>();
            List<Activity> ClientActivityList = new List<Activity>();
            List<Activity> EngineerActivityList = new List<Activity>();

            Activity BActivity = new Activity(BName4Others.Text);
            Activity sumActivity1 = new Activity(Millstone.Text);
            // Add bridge name for others
            MillstoneActivityList.Add(BActivity);
            MillstoneActivityList.Add(sumActivity1);
            for (int i = 0; i < dataGridMilestone.RowCount - 1; i++)
                for (int j = 0; j < dataGridMilestone.ColumnCount; j++)
                {
                    if (dataGridMilestone.Rows[i].Cells[j].Value == null)
                    {
                        dataGridMilestone.Rows[i].Cells[j].Value = "";
                    }
                }

            for (int i = 0; i < dataGridMilestone.RowCount - 1; i++)
            {

                Activity activity = new Activity(dataGridMilestone.Rows[i].Cells["ID1"].Value.ToString(), dataGridMilestone.Rows[i].Cells["actName"].Value.ToString(), dataGridMilestone.Rows[i].Cells["Duration"].Value.ToString(),
                    dataGridMilestone.Rows[i].Cells["Pre"].Value.ToString().Split(',').ToList(), dataGridMilestone.Rows[i].Cells["Lag"].Value.ToString().Split(',').ToList(),
                    dataGridMilestone.Rows[i].Cells["Type"].Value.ToString().Split(',').ToList());
                MillstoneActivityList.Add(activity);
            }

            Activity sumActivity2 = new Activity(ClientSum.Text);
            ClientActivityList.Add(sumActivity2);
            for (int i = 0; i < dataGridClient.RowCount - 1; i++)
                for (int j = 0; j < dataGridClient.ColumnCount; j++)
                {
                    if (dataGridClient.Rows[i].Cells[j].Value == null)
                    {
                        dataGridClient.Rows[i].Cells[j].Value = "";
                    }
                }

            for (int i = 0; i < dataGridClient.RowCount - 1; i++)
            {
               
                Activity activity = new Activity(dataGridClient.Rows[i].Cells["ID2"].Value.ToString(), dataGridClient.Rows[i].Cells["actName2"].Value.ToString(), dataGridClient.Rows[i].Cells["Duration2"].Value.ToString(), 
                    dataGridClient.Rows[i].Cells["Pre2"].Value.ToString().Split(',').ToList(), dataGridClient.Rows[i].Cells["Lag2"].Value.ToString().Split(',').ToList(),
                    dataGridClient.Rows[i].Cells["Type2"].Value.ToString().Split(',').ToList());
                ClientActivityList.Add(activity);
            }

            Activity sumActivity3 = new Activity(EngineeringSum.Text);
            EngineerActivityList.Add(sumActivity3);

            for (int i = 0; i < dataGridEngineer.RowCount - 1; i++)
                for (int j = 0; j < dataGridEngineer.ColumnCount; j++)
                {
                    if (dataGridEngineer.Rows[i].Cells[j].Value == null)
                    {
                        dataGridEngineer.Rows[i].Cells[j].Value = "";
                    }
                }

            for (int i = 0; i < dataGridEngineer.RowCount - 1; i++)
            {

                Activity activity = new Activity(dataGridEngineer.Rows[i].Cells["ID3"].Value.ToString(), dataGridEngineer.Rows[i].Cells["actName3"].Value.ToString(), dataGridEngineer.Rows[i].Cells["Duration3"].Value.ToString(),
                    dataGridEngineer.Rows[i].Cells["Pre3"].Value.ToString().Split(',').ToList(), dataGridEngineer.Rows[i].Cells["Lag3"].Value.ToString().Split(',').ToList(),
                    dataGridEngineer.Rows[i].Cells["Type3"].Value.ToString().Split(',').ToList());
                EngineerActivityList.Add(activity);
            }

            SchGen schGen = new SchGen();
            schGen.CommonSch(project, MillstoneActivityList, "Milestones", BDeadline4Others.Text, 0);
            schGen.CommonSch(project, ClientActivityList, "Client", "0", 1);
            schGen.CommonSch(project, EngineerActivityList, "Engineering", "0", 1);
            this.Close();
        }
    }
}
