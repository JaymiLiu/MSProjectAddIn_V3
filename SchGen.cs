using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Tools.Ribbon;
using MSProject = Microsoft.Office.Interop.MSProject;
using ILOG.CP;
using ILOG.Concert;
using System.Reflection;
using System.Windows.Forms;
//using ILOG.Concert.Cppimpl;

namespace GFabAddIn
{
    public class Activity
    {
        public string AID;
        public string Aname;
        public string Aduration;
        public List<string> Apred;
        public List<string> Lag;
        public List<string> preType;

        public Activity(string name)
        {
            Aname = name;
        }

        public Activity(string name, string duration, List<string> pred)
        {
            Aname = name;
            Aduration = duration;
            Apred = pred;
        }

        public Activity(string ID, string name, string duration, List<string> pred, List<string> lag, List<string> type)
        {
            AID = ID;
            Aname = name;
            Aduration = duration;
            Apred = pred;
            Lag = lag;
            preType = type;
        }
    }


    public class girderParas
    {
        public List<Activity> activities;
        public string GName;
        public string GNum;
        public string GCycle;
        public string shop;
        public string GSeq;
        
        public string RTS;
        public string RAS;
        public string SchedStart;
        public string ProjName;
        public string ProjNum;

        public girderParas(string name, string seq, string rts, string ras, string cycle)
        {
            GName = name;
            GSeq = seq;
            RTS = rts;
            RAS = ras;
            GCycle = cycle;
            
        }
    }


    public class bridgeParas
    {
        public string BName;
        public string BDuration;
        public string shop;
        public string RAS;
        public string BGLine;
        public string SchedStart;
        public string GNameType;
        public string[] GFabSeq;
        public string ProjName;
        public string ProjNum;
        public string girderQty;
        public string BDeadline;
        public string BCycle;
        public string BFieldsplice;

        public bridgeParas(string name, string duration, string ras, string qty, string deadline)
        {
            BName = name;
            BDuration = duration;
            girderQty = qty;
            RAS = ras;
            BDeadline = deadline;

        }

        public bridgeParas(string name, string qty, string gline, string cycle, string deadline, string start, string nametype, string fieldsplice, string[] fabSeq)
        {
            BName = name;
            girderQty = qty;
            BGLine = gline;
            BCycle = cycle;
            BDeadline = deadline;
            SchedStart = start;
            GNameType = nametype;
            BFieldsplice = fieldsplice;
            GFabSeq = fabSeq;

        }
    }

    public class strucParas
    {
        public List<girderParas> girders;
        public string fileName;
        public string strucName;
        public string strucDeadline;
        public string strucGNo;
        public string strucGLine;
        public string strucCycle;
    }

    public class shop
    {
        public string name;
        public List<string> capacity;

        public shop(string sname, List<string> scapacity)
        {
            name = sname;
            capacity = scapacity;

        }
    }

   

    public class SchGen {

        public void SchOptimization(List<bridgeParas> bridges , List<shop> shopList)
        {
            //MessageBox.Show("optimization start");

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            
            CP cp = new CP();
            int failLimit = 30000;
            
            //MatlInvent = cp.CumulFunctionExpr();
            List<IIntExpr> ends = new List<IIntExpr>();
            List<IIntervalVar> allTasks = new List<IIntervalVar>();

            int nbTasks = bridges.Count();
            IIntervalVar[] tasks = new IIntervalVar[nbTasks];
            List<IIntervalVar>[] modes = new List<IIntervalVar>[nbTasks];
            string name;
            // fixed duration for fabricating one girder
            //int duration = 6;

            //Resource limit
            int nbResources = shopList.Count;
            int nbModes = nbResources;
            int[] capacities = new int[nbResources];
            ICumulFunctionExpr[] RsrcUsages = new ICumulFunctionExpr[nbResources];

            for (int i = 0; i < nbTasks; i++)
            {
                tasks[i] = cp.IntervalVar();
                modes[i] = new List<IIntervalVar>();
            }

            for (int j = 0; j < nbResources; j++)
            {
                capacities[j] = int.Parse(shopList[j].capacity[0]);
                RsrcUsages[j] = cp.CumulFunctionExpr();
            }

            for (int i = 0; i < nbTasks; i++)
            {
                tasks[i] = cp.IntervalVar();
                modes[i] = new List<IIntervalVar>();
            }


            //define tasks and number of modes
            for (int i = 0; i < nbTasks; ++i)
            {
                name = bridges[i].BName;
                IIntervalVar task = cp.IntervalVar(name);
                tasks[i] = task;
                for (int k = 0; k < nbModes; k++)
                {
                    IIntervalVar alt = cp.IntervalVar();
                    alt.SetOptional();
                    modes[i].Add(alt);
                }
                cp.Add(cp.Alternative(task, modes[i].ToArray()));
                ends.Add(cp.EndOf(task));
            }

            // define detailed information of modes
            for (int i = 0; i < nbTasks; i++)
            {
                IIntervalVar task = tasks[i];
                List<IIntervalVar> imodes = modes[i];
                for (int k = 0; k < imodes.Count; k++)
                {
                    int taskId = i;
                    int modeId = k;
                    int d = int.Parse(bridges[i].BDuration);
                    //set duration for each mode
                    imodes[k].SizeMax = d;
                    imodes[k].SizeMin = d;
                    for (int j = 0; j < nbResources; j++)
                    {
                        //define required resource for each mode
                        if (j == k)
                        {
                            RsrcUsages[j].Add(cp.Pulse(imodes[k], 1));
                        }
                    }
                }
            }

            for (int j = 0; j < nbResources; j++)
            {
                cp.Add(cp.Le(RsrcUsages[j], capacities[j]));
            }

            INumExpr delay = cp.Constant(0);

            for (int i = 0; i < nbTasks; i++)
            {
                delay = cp.Sum(delay, cp.Abs(cp.Diff(double.Parse(bridges[i].BDeadline), ends[i])));
            }

            IObjective objective = cp.Minimize(delay);
            cp.Add(objective);

            cp.SetParameter(CP.IntParam.FailLimit, failLimit);
            if (cp.Solve())
            {
                //MessageBox.Show("optimization solved!");
                //Console.WriteLine("Solution with objective " + cp.ObjValue + ":");
               
                for (int i = 0; i < nbTasks; i++)
                {
                   // sp.girders[i].SchedStart = cp.GetStart(tasks[i]).ToString();
                  //  string test = cp.GetDomain(tasks[i]);
                    
                    for (int k = 0; k < modes[i].Count; k++)
                    {
                        
                        if (cp.IsPresent(modes[i][k]))
                        {
                            // Record the selected shop and start time
                            bridges[i].SchedStart = cp.GetStart(modes[i][k]).ToString();
                            bridges[i].shop = shopList[k].name;
                        }

                    }
                }
            }

           // return bridges;
        }

        
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EmbedAssembly.ILOG.CP.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }

            //using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EmbedAssembly.ILOG.Concert.dll"))
            //{
            //    byte[] assemblyData = new byte[stream.Length];
            //    stream.Read(assemblyData, 0, assemblyData.Length);
            //    return Assembly.Load(assemblyData);
            //}
            
        }

        private void TemplateGen(MSProject.Project project, strucParas sp, int iTaskIndex)
        {
            MSProject.Task subTask = null;

            for (int i = 0; i < sp.girders[0].activities.Count; i++)
            {
                subTask = project.Tasks.Add(sp.girders[0].activities[i].Aname, iTaskIndex++);

                if (i == 0)
                {
                    //indent for the first subactivity
                    subTask.OutlineIndent();
                    if (iTaskIndex > sp.girders[0].activities.Count + 3)
                    {
                        // add link between girders
                        int preIntraIndex = iTaskIndex - 1 - sp.girders[0].activities.Count - 1;
                        if (preIntraIndex > 0)
                            subTask.LinkPredecessors(project.Tasks[preIntraIndex], MSProject.PjTaskLinkType.pjFinishToStart, sp.strucCycle);
                    }
                }
                    
                subTask.Duration = sp.girders[0].activities[i].Aduration;
                // set RTS and RAS as milestone
                if (sp.girders[0].activities[i].Aduration == "0")
                    subTask.Milestone = true;

                subTask.FixedDuration = true;
                subTask.Manual = false;
                
                if (sp.girders[0].activities[i].Apred[0] != "")
                {
                    for (int index = 0; index < sp.girders[0].activities[i].Apred.Count; index++)
                    {
                        int preIndex = iTaskIndex - 1 + int.Parse(sp.girders[0].activities[i].Apred[index]) - i - 1;
                        subTask.LinkPredecessors(project.Tasks[preIndex], MSProject.PjTaskLinkType.pjFinishToStart);
                    }
                }
            }

            
        }


        public void bridgesToShops(MSProject.Project project, string fileName,  List<shop> shopList)
        {
            //MessageBox.Show("bridgesToshops In");
            int iTaskIndex = 1;
            MSProject.Task task = null;
            //List<Activity> activityList = new List<Activity>();
            //activityList = sp.girders[0].activities;
            DateTime today = DateTime.Now;
            

            string[] filelines = File.ReadAllLines(fileName);

            string[] title = filelines[0].Split(',');

            int rowCount = filelines.Length;
            int colCount = title.Length;

            // Get the column index of "Task name", "duration", "Predecessors" and "Lag" in the template
            int BNameIndex = 0;
            int BDurationIndex = 0;
            int BRASIndex = 0;
            int BGQtyRTSIndex = 0;
            

            for (int ColumnNo = 0; ColumnNo < colCount; ColumnNo++)
            {
                string temp = title[ColumnNo].ToLower();
                switch (temp)
                {
                    case "bridge name":
                        BNameIndex = ColumnNo;
                        break;
                    case "duration in weeks":
                        BDurationIndex = ColumnNo;
                        break;
                    case "ras":
                        BRASIndex = ColumnNo;
                        break;
                    case "qty girders":
                        BGQtyRTSIndex = ColumnNo;
                        break;
                }
            }

            // Get the list of taskname, duration, predecessor, lag
            List<bridgeParas> bridges = new List<bridgeParas>();
            
            // Stop watch
            //var sw = System.Diagnostics.Stopwatch.StartNew();

            // Not include the title in the csv file, to parse the CSV file to get the bridge information
            for (int row = 1; row < rowCount; row++)
            {
                string[] splitLines = filelines[row].Split(',');
                DateTime RAS = Convert.ToDateTime(splitLines[BRASIndex]);
                //deadline in weeks
                int deadline = (int)((RAS - today).TotalDays/7 + int.Parse(splitLines[BGQtyRTSIndex])/3 - 1);
                bridgeParas bridge = new bridgeParas(splitLines[BNameIndex], splitLines[BDurationIndex], 
                    splitLines[BRASIndex], splitLines[BGQtyRTSIndex], deadline.ToString());
                bridges.Add(bridge);              
                
            }

            //girders.Sort((p, q) => p.GSeq.CompareTo(q.GSeq));
            //sp.girders = girders;
            //sp.girders[0].activities = activityList;
            SchOptimization(bridges, shopList);

            //bool firstGFlag = true;
            for (int row = 0; row < bridges.Count(); row++)
            {
                //firstGFlag = true;
                string start = today.AddDays(double.Parse(bridges[row].SchedStart) * 7).ToString();
                task = project.Tasks.Add(bridges[row].BName, iTaskIndex++);
                // task.Manual = false;
                
                task.Start = start;
                task.Duration = (bridges[row].BDuration + "w");
                task.Text1 = bridges[row].shop;
                task.Text2 = bridges[row].girderQty;
                task.Date1 = bridges[row].RAS;
            }
           // sw.Stop();
            //var elapsedMs = sw.ElapsedMilliseconds;

            // Rename Text1, Date1, Date2
            project.Application.CustomFieldRename(MSProject.PjCustomField.pjCustomTaskText1, "shop", Type.Missing);
            project.Application.CustomFieldRename(MSProject.PjCustomField.pjCustomTaskText2, "Qty girder", Type.Missing);
            project.Application.CustomFieldRename(MSProject.PjCustomField.pjCustomTaskDate1, "RAS", Type.Missing);
        }

        private int ActNotFieldSplice(MSProject.Project project,List<Activity> activityList, int iTaskIndex, int i, List<string> girdernames, string cycletime, bridgeParas bridge)
        {
            MSProject.Task subTask = null;
            subTask = project.Tasks.Add(activityList[i].Aname + '-' + girdernames[0], iTaskIndex++);
            subTask.Text1 = activityList[i].Aname;

            int startIndex = nameIndexbySeq(bridge)[0];
            int signIndex = nameIndexbySeq(bridge)[1];
            
            string[] alpha = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            //// add link between preparation for girders 
            if (i == 0) //indicating the first activity "preparation"
            {
                //indent for the first subactivity
                subTask.OutlineIndent();
                subTask.ConstraintType = "As Late As Possible";

            }
            subTask.Duration = activityList[i].Aduration;
            // set RTS and RAS as milestone
            if (activityList[i].Aduration == "0")
                subTask.Milestone = true;

            subTask.FixedDuration = true;
            subTask.Manual = false;

            if (activityList[i].Apred[0] != "")
            {
                for (int index = 0; index < activityList[i].Apred.Count; index++)
                {
                    int preIndex = iTaskIndex - 1 + int.Parse(activityList[i].Apred[index]) - i - 1;
                    subTask.LinkPredecessors(project.Tasks[preIndex], MSProject.PjTaskLinkType.pjFinishToStart);
                }
            }

            return iTaskIndex;
        }

        private int ActFieldSplice(MSProject.Project project, List<Activity> activityList, int iTaskIndex, int i, List<string> girdernames)
        {
            MSProject.Task subTask = null;
            string name = "-";
            int length = girdernames.Count;
            for (int j = length - 1; j >= 0; j--)
            {
                name += girdernames[j];
                //eliminate the "&" at the end
                if (j - 1 >= 0)
                    name += " & ";
            }
            subTask = project.Tasks.Add(activityList[i].Aname + name, iTaskIndex++);
            subTask.Text1 = activityList[i].Aname;

            if (i == 0)
            {
                //indent for the first subactivity
                subTask.OutlineIndent();
            }

            subTask.Duration = activityList[i].Aduration;
            // set RTS and RAS as milestone
            if (activityList[i].Aduration == "0")
                subTask.Milestone = true;

            subTask.FixedDuration = true;
            subTask.Manual = false;

            if (activityList[i].Apred[0] != "")
            {
                for (int index = 0; index < activityList[i].Apred.Count; index++)
                {
                    int preIndex = iTaskIndex - 1 + int.Parse(activityList[i].Apred[index]) - i - 1;
                    subTask.LinkPredecessors(project.Tasks[preIndex], MSProject.PjTaskLinkType.pjFinishToStart);
                }
            }
            return iTaskIndex;
        }
        private int[] nameIndexbySeq(bridgeParas bridge)
        {
            string[] alpha = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int GColumn = int.Parse(bridge.girderQty) / int.Parse(bridge.BGLine);
            int[] Index = { 0, 0 };
            // To assign the start point and direction for naming girders
            
            if (bridge.GFabSeq[0] == "Left to Right")
            {
                Index[0] = 1;
                Index[1] = 1;
            }
            else if (bridge.GFabSeq[0] == "Right to Left")
            {
                Index[0] = GColumn;
                Index[1] = -1;
            }
            return Index;
        }
        private int[] nameGirderbySeq(bridgeParas bridge)
        {
            List<string> girdernames = new List<string>();
            //{signRow, signCol}
            int[] signs = {0, 0};

            if (bridge.GFabSeq[1] == "Row")
            {
                signs[0] = 1;
            }
            else if (bridge.GFabSeq[1] == "Column")
                signs[1] = 1;

            return signs;
        }

        private void GTemplateGen(MSProject.Project project, bridgeParas bridge, List<Activity> activityList, int iTaskIndex)
        {
            MSProject.Task task = null;
            // To distinguish the first girder or other girders, for outlineoutdent/outlineindent
            int Index = 1;
            string[] alpha = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int GColumn = int.Parse(bridge.girderQty) / int.Parse(bridge.BGLine);

            // To assign the start point and direction for naming girders
            int startIndex = nameIndexbySeq(bridge)[0];
            int signIndex = nameIndexbySeq(bridge)[1];

            int signRow = nameGirderbySeq(bridge)[0];
            int signCol = nameGirderbySeq(bridge)[1];

            int indexOut = 0, indexIn = 0;

            if (signRow == 1)
            {
                indexOut = int.Parse(bridge.BGLine);
                indexIn = GColumn;
            }
            else if (signCol == 1)
            {
                indexOut = GColumn;
                indexIn = int.Parse(bridge.BGLine);
            }


            for (int iTaskNameIndex = 1; iTaskNameIndex <= indexOut; iTaskNameIndex++)
            {
                // To get the girder name
                for (int iTaskNameIndex_1 = 1; iTaskNameIndex_1 <= indexIn; iTaskNameIndex_1++)
                {
                   //List to store current girder name (the first element) and its predecessors
                   List<string> girdernames = new List<string>();
                    int rowIndex = 0, colIndex = 0;
                    if (signRow == 1)
                    {
                        rowIndex = iTaskNameIndex;
                        colIndex = iTaskNameIndex_1;
                    }
                    else if (signCol == 1)
                    {
                        rowIndex = iTaskNameIndex_1;
                        colIndex = iTaskNameIndex;
                    }

                    if (bridge.GNameType == "1")
                    {
                        girdernames.Add("G" + alpha[rowIndex - 1] + (startIndex + signIndex * (colIndex - 1)).ToString());
                        // index to count predecessor
                        int Precount = 1;
                        while (colIndex > int.Parse(bridge.BFieldsplice) - 1 &&  int.Parse(bridge.BFieldsplice) - Precount > 0 )
                        {
                            girdernames.Add("G" + alpha[rowIndex - 1] + (startIndex + signIndex * (colIndex - 1 - Precount)).ToString());
                            Precount++;
                        }
                    }
                    else if (bridge.GNameType == "2")
                    {
                        girdernames.Add("G" + (rowIndex).ToString() + alpha[startIndex + signIndex * (colIndex - 1) - 1]);
                        int Precount = 1;
                        while (colIndex > int.Parse(bridge.BFieldsplice) -1 && int.Parse(bridge.BFieldsplice) - Precount > 0)
                        {
                            girdernames.Add("G" + (rowIndex).ToString() + alpha[startIndex + signIndex * (colIndex - 1 - Precount) - 1]);
                            Precount++;
                        }
                    }

                    task = project.Tasks.Add(girdernames[0] + " Fabrication", iTaskIndex++);
                    Index++;
                    // Outdent for inserting a summary task
                    if (Index == 2)
                        task.OutlineIndent();
                    else
                        task.OutlineOutdent();

                    for (int i = 0; i < activityList.Count; i++)
                    {
                        //if (!activityList[i].Aname.Contains ("Field Splice"))
                        if (activityList[i].Aname != "3. Field Splice")
                        {
                            iTaskIndex = ActNotFieldSplice(project, activityList, iTaskIndex, i, girdernames, bridge.BCycle, bridge);
                        }
                        else if (girdernames.Count == int.Parse(bridge.BFieldsplice))
                        {
                            iTaskIndex = ActFieldSplice(project, activityList, iTaskIndex, i, girdernames);
                        }
                        
                    }

                }
            }
        }

        private void addLinks(MSProject.Project project, bridgeParas bridge, int startLine)
        {
            // int taskNo = project.Tasks.Count;
            int GNoLine = int.Parse(bridge.girderQty) / int.Parse(bridge.BGLine);
            // int i = 0;
            string[] alpha = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int startIndex = nameIndexbySeq(bridge)[0];
            int signIndex = nameIndexbySeq(bridge)[1];
            string lastGName = "G";

            if (bridge.GNameType == "1")
                lastGName = "G" + alpha[Convert.ToInt32(bridge.BGLine) - 1] + GNoLine.ToString();
            else if (bridge.GNameType == "2")
                lastGName = "G" + bridge.BGLine + alpha[Convert.ToInt32(GNoLine) - 1];

            // add link between field splice and RTS
            for (int i = startLine; i <= project.Tasks.Count; i++)
            {
                MSProject.Task subTask = project.Tasks[i];
            //foreach (MSProject.Task subTask in project.Tasks)
            //{
                switch (bridge.BFieldsplice)
                {

                    //add links between girder assembly and field splice for the first two or first three girders
                    case "2":
                        if (subTask.Name.Contains("Girder Assembly") && (subTask.Name.EndsWith(startIndex.ToString()) || subTask.Name.EndsWith(alpha[startIndex - 1])))
                        {
                            string GName = subTask.Name.Split('-')[1];
                            for (int j = startLine; j <= project.Tasks.Count; j++)
                            {
                                MSProject.Task subTask1 = project.Tasks[j];
                                if (subTask1.Name.Contains("Field Splice") && subTask1.Name.Contains(GName) && subTask1.ID != subTask.ID + 1)
                                    subTask1.LinkPredecessors(project.Tasks[subTask.ID], MSProject.PjTaskLinkType.pjFinishToStart);
                            }
                        }
                        break;
                    case "3":
                        if (subTask.Name.Contains("Girder Assembly") && ((subTask.Name.EndsWith(startIndex.ToString()) || subTask.Name.EndsWith(alpha[startIndex - 1])) 
                            || (subTask.Name.EndsWith((startIndex + signIndex).ToString()) || subTask.Name.EndsWith(alpha[startIndex + signIndex - 1]))))
                        {
                            string GName = subTask.Name.Split('-')[1];
                            for (int j = startLine; j <= project.Tasks.Count; j++)
                            {
                                MSProject.Task subTask1 = project.Tasks[j];
                                if (subTask1.Name.Contains("Field Splice") && subTask1.Name.Contains(GName) && subTask1.ID != subTask.ID + 1)
                                    subTask1.LinkPredecessors(project.Tasks[subTask.ID], MSProject.PjTaskLinkType.pjFinishToStart);
                            }
                        }
                        break;
                }

                if (subTask.Name.Contains("Field Splice"))
                {
                    string[] GNames = subTask.Name.Split('&');
                    string GName = GNames[GNames.Count() - 1].Trim();
                    for (int j = startLine; j <= project.Tasks.Count; j++)
                    {
                        MSProject.Task subTask1 = project.Tasks[j];
                        if (subTask1.Name.Contains("Field Splice") && subTask1.Name.Contains(GName) && subTask1.ID > subTask.ID)
                            subTask1.LinkPredecessors(project.Tasks[subTask.ID], MSProject.PjTaskLinkType.pjFinishToStart);
                    }
                }

                if (subTask.Name.Contains("RTS"))
                {
                    string GName = subTask.Name.Split('-')[1];
                    for (int j = startLine; j <= project.Tasks.Count; j++)
                    {
                        MSProject.Task subTask1 = project.Tasks[j];
                        if (subTask1.Name.Contains("Field Splice") && subTask1.Name.Contains(GName) && subTask1.ID != subTask.ID + 1)
                            subTask.LinkPredecessors(project.Tasks[subTask1.ID], MSProject.PjTaskLinkType.pjFinishToStart);
                    }
                }

                if (subTask.Name.Contains("Shipping"))
                {

                    for (int j = startLine; j <= project.Tasks.Count; j++)
                    {
                        MSProject.Task subTask1 = project.Tasks[j];
                        if (subTask1.Name.Contains("Field Splice"))
                        {
                            string GName = subTask1.Name.Split('-')[1];
                            if (GName.Contains(lastGName))
                                subTask.LinkPredecessors(project.Tasks[subTask1.ID], MSProject.PjTaskLinkType.pjFinishToStart);
                        }
                        
                    }
                }

                if (subTask.Name.Contains("Preparation"))
                {
                    for (int j = startLine; j <= project.Tasks.Count; j++)
                    {
                        MSProject.Task subTask1 = project.Tasks[j];
                        if (subTask1.Name.Contains("Preparation") && subTask1.ID > subTask.ID)
                        {
                            subTask1.LinkPredecessors(project.Tasks[subTask.ID], MSProject.PjTaskLinkType.pjStartToStart, bridge.BCycle);
                            break;
                        }
                    }
                }

                if (subTask.Name.Contains("Girder Assembly"))
                {
                    for (int j = startLine; j <= project.Tasks.Count; j++)
                    {
                        MSProject.Task subTask1 = project.Tasks[j];
                        if (subTask1.Name.Contains("Girder Assembly") && subTask1.ID > subTask.ID)
                        {
                            // 1 days for pressing web and flange together
                            double cycle = double.Parse(bridge.BCycle); // + 1;
                            subTask1.LinkPredecessors(project.Tasks[subTask.ID], MSProject.PjTaskLinkType.pjStartToStart, cycle.ToString());

                            break;
                        }
                            
                    }
                }
            }
        }

        public void girderDetailSch(MSProject.Project project, bridgeParas bridge, List<Activity> activityList)
        {
            int iTaskIndex = project.Tasks.Count + 1;
            int startLine = iTaskIndex;           
            if (project.Tasks.Count == 0)
                project.ProjectStart = bridge.SchedStart;
            else if ((int)(project.ProjectStart - Convert.ToDateTime(bridge.SchedStart)).TotalMinutes > 0)
                project.ProjectStart = bridge.SchedStart;
            project.Application.CustomFieldRename(MSProject.PjCustomField.pjCustomTaskText1, "Station", Type.Missing);

            MSProject.Task task = null;
            //project.ProjectStart = "01/01/2016 8:00AM";
            task = project.Tasks.Add(bridge.BName, iTaskIndex++);
            task.Deadline = bridge.BDeadline;
            while (task.OutlineLevel > 1)
                task.OutlineOutdent();
            GTemplateGen(project, bridge, activityList, iTaskIndex);
            addLinks(project, bridge, startLine);

        }

        public void CommonSch(MSProject.Project project, List<Activity> ActivityList, string Schtype, string Deadline, int flag) // flag: the indent/outdent for others
        {
            MSProject.Task task = null;
            project.Application.CustomFieldRename(MSProject.PjCustomField.pjCustomTaskText1, "Station", Type.Missing);
            //project.DefaultStartTime = "2016/01/01";
            //project.ProjectStart = "01/01/2016 8:00AM";
            for (int iTaskIndex = 1; iTaskIndex <= ActivityList.Count; iTaskIndex++)
            {
                if (iTaskIndex == 1)
                {
                    // add the draft summary task
                    task = project.Tasks.Add(ActivityList[iTaskIndex - 1].Aname);
                    if (Deadline != "0")
                        task.Deadline = Deadline;
                    if (flag == 1)
                        task.OutlineOutdent();

                }
                else if (iTaskIndex == 2 && Schtype == "Milestones") {
                    task = project.Tasks.Add(ActivityList[iTaskIndex - 1].Aname);
                    //task.OutlineIndent();
                }
                else
                {
                    task = project.Tasks.Add(ActivityList[iTaskIndex - 1].Aname);
                    int currentID = Convert.ToInt32(ActivityList[iTaskIndex - 1].AID);
                    task.Duration = ActivityList[iTaskIndex - 1].Aduration;
                    task.Text1 = Schtype;
                    for (int i = 0; i < ActivityList[iTaskIndex - 1].Apred.Count; i++)
                    {
                        if (ActivityList[iTaskIndex - 1].Apred[i] != "")
                        {
                            int pre = task.ID - currentID + Convert.ToInt32(ActivityList[iTaskIndex - 1].Apred[i]);
                            if (ActivityList[iTaskIndex - 1].Lag.Count > 0)
                            {
                                switch (ActivityList[iTaskIndex - 1].preType[i].ToUpper())
                                {
                                    case "SS":
                                        task.LinkPredecessors(project.Tasks[pre], MSProject.PjTaskLinkType.pjStartToStart, ActivityList[iTaskIndex - 1].Lag[i]);
                                        break;
                                    case "FS":
                                        task.LinkPredecessors(project.Tasks[pre], MSProject.PjTaskLinkType.pjFinishToStart, ActivityList[iTaskIndex - 1].Lag[i]);
                                        break;
                                    case "SF":
                                        task.LinkPredecessors(project.Tasks[pre], MSProject.PjTaskLinkType.pjStartToFinish, ActivityList[iTaskIndex - 1].Lag[i]);
                                        break;
                                    case "FF":
                                        task.LinkPredecessors(project.Tasks[pre], MSProject.PjTaskLinkType.pjFinishToFinish, ActivityList[iTaskIndex - 1].Lag[i]);
                                        break;
                                    default:
                                        task.LinkPredecessors(project.Tasks[pre], MSProject.PjTaskLinkType.pjFinishToStart);
                                        break;
                                }
                            }
                            else
                            {
                                switch (ActivityList[iTaskIndex - 1].preType[i].ToUpper())
                                {
                                    case "SS":
                                        task.LinkPredecessors(project.Tasks[pre], MSProject.PjTaskLinkType.pjStartToStart);
                                        break;
                                    case "FS":
                                        task.LinkPredecessors(project.Tasks[pre], MSProject.PjTaskLinkType.pjFinishToStart);
                                        break;
                                    case "SF":
                                        task.LinkPredecessors(project.Tasks[pre], MSProject.PjTaskLinkType.pjStartToFinish);
                                        break;
                                    case "FF":
                                        task.LinkPredecessors(project.Tasks[pre], MSProject.PjTaskLinkType.pjFinishToFinish);
                                        break;
                                }
                            }
                        }

                    }
                    if (ActivityList[iTaskIndex - 1].Aduration == "0")
                        task.Milestone = true;

                    task.FixedDuration = true;
                    task.Manual = false;
                }
                if (iTaskIndex == 2)
                    task.OutlineIndent();
                if (iTaskIndex == 3 && Schtype == "Milestones")
                    task.OutlineIndent();
            }
        }
    }

    
}
