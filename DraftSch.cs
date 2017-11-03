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
    public partial class DraftSch : Form
    {
        public DraftSch()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                dataGridDraft.Rows.Add();
                dataGridDraft.Rows[i].Cells["ID"].Value = i + 1;
            }

            //Inital drafting activities 
            dataGridDraft.Rows[0].Cells["actName"].Value = "Draft Shop PL Drawings";
            dataGridDraft.Rows[1].Cells["actName"].Value = "Check Shop PL Drawings";
            dataGridDraft.Rows[2].Cells["actName"].Value = "Draft Shop and Erection Drawings";
            dataGridDraft.Rows[3].Cells["actName"].Value = "Check Shop and Erection Drawings";
            dataGridDraft.Rows[4].Cells["actName"].Value = "RFI001 from Drafting";
            dataGridDraft.Rows[5].Cells["actName"].Value = "RFI002 from Drafting";
            dataGridDraft.Rows[6].Cells["actName"].Value = "Receive Bearing Shop Drawings from Client";
            dataGridDraft.Rows[7].Cells["actName"].Value = "Issue Shop Drawings";
            dataGridDraft.Rows[8].Cells["actName"].Value = "Issue Erection and Erection Procedure Drawings";

            dataGridDraft.Rows[0].Cells["Duration"].Value = "6.4 days";
            dataGridDraft.Rows[1].Cells["Duration"].Value = "4.1 days";
            dataGridDraft.Rows[2].Cells["Duration"].Value = "24.9 days";
            dataGridDraft.Rows[3].Cells["Duration"].Value = "18.6 days";
            dataGridDraft.Rows[4].Cells["Duration"].Value = "7.5 days";
            dataGridDraft.Rows[5].Cells["Duration"].Value = "6.3 days";
            dataGridDraft.Rows[6].Cells["Duration"].Value = "0.0 days";
            dataGridDraft.Rows[7].Cells["Duration"].Value = "6.3 days";
            dataGridDraft.Rows[8].Cells["Duration"].Value = "5.0 days";

            dataGridDraft.Rows[0].Cells["Pre"].Value = "";
            dataGridDraft.Rows[1].Cells["Pre"].Value = "1";
            dataGridDraft.Rows[2].Cells["Pre"].Value = "2";
            dataGridDraft.Rows[3].Cells["Pre"].Value = "3";
            dataGridDraft.Rows[4].Cells["Pre"].Value = "3";
            dataGridDraft.Rows[5].Cells["Pre"].Value = "3";
            dataGridDraft.Rows[6].Cells["Pre"].Value = "";
            dataGridDraft.Rows[7].Cells["Pre"].Value = "4";
            dataGridDraft.Rows[8].Cells["Pre"].Value = "4";

            dataGridDraft.Rows[0].Cells["Lag"].Value = "";
            dataGridDraft.Rows[1].Cells["Lag"].Value = "0";
            dataGridDraft.Rows[2].Cells["Lag"].Value = "0";
            dataGridDraft.Rows[3].Cells["Lag"].Value = "12.5 days";
            dataGridDraft.Rows[4].Cells["Lag"].Value = "2.5 days";
            dataGridDraft.Rows[5].Cells["Lag"].Value = "6.25 days";
            dataGridDraft.Rows[6].Cells["Lag"].Value = "";
            dataGridDraft.Rows[7].Cells["Lag"].Value = "0";
            dataGridDraft.Rows[8].Cells["Lag"].Value = "0";

            dataGridDraft.Rows[0].Cells["Type"].Value = "";
            dataGridDraft.Rows[1].Cells["Type"].Value = "FS";
            dataGridDraft.Rows[2].Cells["Type"].Value = "FS";
            dataGridDraft.Rows[3].Cells["Type"].Value = "SS";
            dataGridDraft.Rows[4].Cells["Type"].Value = "SS";
            dataGridDraft.Rows[5].Cells["Type"].Value = "SS";
            dataGridDraft.Rows[6].Cells["Type"].Value = "";
            dataGridDraft.Rows[7].Cells["Type"].Value = "FS";
            dataGridDraft.Rows[8].Cells["Type"].Value = "FS";

        }

      /*  private DataTable AutoNumberedTable(DataTable SourceTable) {
            DataTable ResultTable = new DataTable();
            DataColumn AutoNumberColumn = new DataColumn();
            AutoNumberColumn.ColumnName = "ID";
            AutoNumberColumn.DataType = typeof(int);
            AutoNumberColumn.AutoIncrement = true;
            AutoNumberColumn.AutoIncrementSeed = 1;
            AutoNumberColumn.AutoIncrementStep = 1;
            ResultTable.Columns.Add(AutoNumberColumn);
            ResultTable.Merge(SourceTable);
            return ResultTable;
        } */

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //Application;
            MSProject.Application app;
            MSProject.Project project;
            app = Globals.ThisAddIn.Application;
            project = app.ActiveProject;

            List<Activity> draftActivityList = new List<Activity>();

            string title = BName4Draft.Text + " " + DraftSum.Text;

            Activity sumActivity = new Activity(title);
            draftActivityList.Add(sumActivity);

            for (int i = 0; i < dataGridDraft.RowCount - 1; i++)
                for (int j = 0; j < dataGridDraft.ColumnCount; j++)
                {
                    if (dataGridDraft.Rows[i].Cells[j].Value == null)
                    {
                        dataGridDraft.Rows[i].Cells[j].Value = "";
                    }
                }

            for (int i = 0; i < dataGridDraft.RowCount - 1; i++)
            {
               
                Activity activity = new Activity(dataGridDraft.Rows[i].Cells["ID"].Value.ToString(), dataGridDraft.Rows[i].Cells["actName"].Value.ToString(), dataGridDraft.Rows[i].Cells["Duration"].Value.ToString(), 
                    dataGridDraft.Rows[i].Cells["Pre"].Value.ToString().Split(',').ToList(), dataGridDraft.Rows[i].Cells["Lag"].Value.ToString().Split(',').ToList(),
                    dataGridDraft.Rows[i].Cells["Type"].Value.ToString().Split(',').ToList());
                draftActivityList.Add(activity);
            }

            SchGen schGen = new SchGen();
            schGen.CommonSch(project, draftActivityList, "Drafting", BDeadline4Draft.Text, 0);
            this.Close();
        }

        
    }
}
