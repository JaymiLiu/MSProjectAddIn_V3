using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GFabAddIn;
using Microsoft.Office.Tools.Ribbon;
using MSProject = Microsoft.Office.Interop.MSProject;
using System.IO;

namespace GFabAddIn
{
    public partial class InputUI : Form
    {
        public InputUI()
        {
            InitializeComponent();

            //ShopCap.Rows.Add();
            //ShopCap.Rows.Add();
            //ShopCap.Rows.Add();
            //ShopCap.Rows.Add();
            //ShopCap.Rows.Add();
           // ShopCap.Rows[0].Cells["GType"].Value = "Type A";
          //  ShopCap.Rows[1].Cells["GType"].Value = "Type B";
          //  ShopCap.Rows[2].Cells["GType"].Value = "Type C";
          //  ShopCap.Rows[3].Cells["GType"].Value = "Type D";
          //  ShopCap.Rows[4].Cells["GType"].Value = "Type E";
            //.Cells["GType"].Value = "Type A";
            //ShopCap.Rows.Add(row);
            //ShopCap.Rows.Add(row);
            //ShopCap.Rows.Add(row);
            //ShopCap.Rows.Add(row);
            //ShopCap.Rows.Add(row);


        }

        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    StructName.Enabled = GFab.Checked;
        //    Deadline.Enabled = GFab.Checked;
        //    GNo.Enabled = GFab.Checked;
        //    GLine.Enabled = GFab.Checked;
        //    CycleTime.Enabled = GFab.Checked;
        //    Startdate.Enabled = GFab.Checked;
        //    radioButton3.Enabled = GFab.Checked;
        //    radioButton4.Enabled = GFab.Checked;
        //    radioButton5.Enabled = GFab.Checked;
        //    radioButton6.Enabled = GFab.Checked;
        //    FabSeq1.Enabled = GFab.Checked;
        //    FabSeq2.Enabled = GFab.Checked;
        //}

        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    GFileBrowse.Enabled = GAllocate.Checked;
        //    GFileName.Enabled = GAllocate.Checked;
        //}

        //private void GFileBrowse_Click(object sender, EventArgs e)
        //{
            
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        //    if (result == DialogResult.OK) // Test result.
        //    {
        //        GFileName.Text = openFileDialog1.FileName;
        //    }
        //}
        private string GNametype()
        {
            string nametype = "0";
            if (radioButton3.Checked)
            {
                nametype = "1";
            }
            else if (radioButton4.Checked)
            {
                nametype = "2";
            }
            return nametype;

        }

        private string FieldspliceManner()
        {
            string fieldSplice = "0";
            if (TwoFS.Checked)
            {
                fieldSplice = "2";
            }
            else if (ThreeFS.Checked)
            {
                fieldSplice = "3";
            }
            return fieldSplice;

        }

        private string GFabSeq1()
        {
            string fabseq = "0";
            if (FabSeq1.Checked)
            {
                // fabrication left to right
                fabseq = "Left to Right";
            }
            else if (FabSeq2.Checked)
            {
                //fabricate right to left
                fabseq = "Right to Left";
            }
            return fabseq;
        }

        private string GFabSeq2()
        {
            string fabseq = "0";
            if (FabSeq3.Checked)
            {
                // fabrication left to right
                fabseq = "Row";
            }
            else if (FabSeq4.Checked)
            {
                //fabricate right to left
                fabseq = "Column";
            }
            return fabseq;

        }



        private void OK_Click(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //Application;
            MSProject.Application app;
            MSProject.Project project;
            app = Globals.ThisAddIn.Application;
            project = app.ActiveProject;

            List<Activity> activityList = new List<Activity>();

            Activity activity1 = new Activity(Pre.Text, PreDuration.Text, PrePre.Text.Split(',').ToList());
            Activity activity2 = new Activity(GA.Text, GAduration.Text, GAPre.Text.Split(',').ToList());
            Activity activity3 = new Activity(FS.Text, FSDuration.Text, FSPre.Text.Split(',').ToList());
            Activity activity4 = new Activity(RTS.Text, RTSDuration.Text, RTSPre.Text.Split(',').ToList());
            Activity activity5 = new Activity(Ship.Text, ShipDuration.Text, ShipPre.Text.Split(',').ToList());
            Activity activity6 = new Activity(RAS.Text, RASDuration.Text, RASPre.Text.Split(',').ToList());

            activityList.Add(activity1);
            activityList.Add(activity2);
            activityList.Add(activity3);
            activityList.Add(activity4);
            activityList.Add(activity5);
            activityList.Add(activity6);


            SchGen schGen = new SchGen();

            string nametype = GNametype();
            string fieldSplice = FieldspliceManner();
            string[] fabseq = { GFabSeq1(), GFabSeq2() };
            if (nametype == "0" || fieldSplice == "0" || fabseq[0] == "0" || fabseq[0] == "0")
            {
                MessageBox.Show("Please specify the way to name girders/fabrication sequence/field splice manner");
                this.Show();
                goto end;
            }
            bridgeParas bridge = new bridgeParas(BName.Text, tBGNo.Text, tBGLine.Text, tBCycle.Text, BDeadline.Text, BStart.Text, nametype, fieldSplice, fabseq);

            schGen.girderDetailSch(project, bridge, activityList);

            this.Close();
           // this.OK_Click(sender,e);

            end:;
        }

        
    }
    
}
