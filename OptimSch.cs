using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using MSProject = Microsoft.Office.Interop.MSProject;
using ILOG.CP;
using ILOG.Concert;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GFabAddIn
{
    class OptimSch
    {
        public class MSprojectLayout
        {
            public int projectID;
            public string girderName;
            public int activityStartID; //ms project line ID;
            public int activityEndID; //ms project line ID;

            public MSprojectLayout(int pID, string gName, int startID, int endID)
            {
                projectID = pID;
                girderName = gName;
                activityStartID = startID;
                activityEndID = endID;
            }
        }
        public class MSprojectInfo
        {
            public string startDate;
            public int nbProj;
            public int projLevel;
            public int girderLevel;
            public int actLevel;
            public int nbRsrc;
            public List<int> RsrcLimit;
            public List<MSprojectLayout> msprojectLayout;
            

            public MSprojectInfo(string date, int ProjLevel, int girderL, int ActLevel, int NbRsrc, List<int> Rsrclimit)
            {
                startDate = date;
                projLevel = ProjLevel;
                girderLevel = girderL;
                actLevel = ActLevel;
                nbRsrc = NbRsrc;
                RsrcLimit = Rsrclimit;
            }
        }
        public class ProjectList {
            public string projName;
            public string Deadline;
            public int MSprojectLineID;

            public ProjectList(string name, string time, int lineID) {
                projName = name;
                Deadline = time;
                MSprojectLineID = lineID;
            }
        }


        public class GirderList
        {
            public string projName;
            public string girderName;
            public int MSprojectLineID;           

            public GirderList(string name, string gname, int lineID)
            {
                projName = name;
                girderName = gname;
                MSprojectLineID = lineID;
            }
        }
        public class finishedTask
        {
            public int MSProjectLineID;
            public string schedStartTime;

            public finishedTask(int ID, string time)
            {
                MSProjectLineID = ID;
                schedStartTime = time;
            }
        }
        public class ongoingTask
        {
            public int projectID;
            public string taskName;
            public int MSprojectLineID;
            public string schedStartTime;
            public int duration;
            public List<int> RsrcList;

            public ongoingTask(int projID, string name, int lineID, int dur, string startTime, List<int> tempRsrc)
            {
                projectID = projID;
                taskName = name;
                MSprojectLineID = lineID;
                duration = dur;
                schedStartTime = startTime;
                RsrcList = tempRsrc;
            }
        }

        public class ActivityList
        {
            public int projID;
            public string girderName;
            public string girderLine;
            public string activityName;
            public int MSprojectLineID;
            public int duration;
            public int startTime;
            public int deadline;
            //public int nbRsrc;
            public List<int> RsrcList;
            
            public ActivityList(int pID, string gName, string aName, int lineID, int aDuration, int dtime, List<int> rsrcList)
            {
                projID = pID;
                girderName = gName;
                
                activityName = aName;
                MSprojectLineID = lineID;
                duration = aDuration;
                deadline = dtime;
                RsrcList = rsrcList;
            }
        }

        public class ordering {
            //record the precedessor for scheduling
            public int pre;
            public string preGiderName;
            public string preGirderLine;
            public int preProID;
            public int preFlag; // indicate if the pre activity is the first activity in one girder fabrication
            public int succ;
            public string succGiderName;
            public string succGirderLine;
            public int succProID;
            public int succFlag;// indicate if the pre activity is the first activity in one girder fabrication
            public string type; // relationship type
            public int lag;

            public ordering(int preID, int succID, int succPID, string succGName, string succGLine, string rType, int lagT) {
                pre = preID;
                succProID = succPID;
                succGiderName = succGName;
                succGirderLine = succGLine;
                succ = succID;
                type = rType;
                lag = lagT;
            }
            
        }

        private static int GetNumberOfWorkingDays(DateTime start, DateTime stop)
        {
            int days = 0;
            while (start <= stop)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++days;
                }
                start = start.AddDays(1);
            }
            return days;
        }
        private static int GetNumberOfNonWorkingDays(DateTime start, DateTime stop)
        {
            int days = 0;
            while (start <= stop)
            {
                if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
                {
                    ++days;
                }
                start = start.AddDays(1);
            }
            return days;
        }

        private static DateTime GetEndDaysIncludingNonWorkingDays(DateTime start, int minutes)
        {
            int days = (int) Math.Ceiling((double) minutes/480);
            
            DateTime stop = start.AddDays(days);
            DateTime test = stop;
            int index = 0;
            int extraDays = 0;
            while (index++ <= days)
            {
                start = start.AddDays(index);
                if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
                {
                    // if including non-working days, adding one day (480 min)
                    extraDays++;
                }
            }
            stop = stop.AddDays(extraDays);
            return stop;
        }

        private List<ProjectList> ReadProjectName(MSProject.Project project)
        {
            // New the project list
            List<ProjectList> projectList = new List<ProjectList>();
            ProjectList tempProject;
            string name, time;
            int lineID;
            foreach (MSProject.Task t in project.Tasks)
            {
                //project is the most out summary task
                if ((t != null) && (t.OutlineLevel == 1))
                {
                    name = t.Name;
                    lineID = t.ID;
                    if (t.Deadline != null)
                        time = t.Deadline.ToString("yyyyMMdd");
                    else
                        time = "0";
                    
                    tempProject = new ProjectList(name, time, lineID);
                    projectList.Add(tempProject);
                }
            }
            return projectList;
        }
        private List<GirderList> ReadGirderName(MSProject.Project project)
        {
            // New the project list
            List<GirderList> girderList = new List<GirderList>();
            GirderList tempGirder;
            string name, time;
            int lineID;
            foreach (MSProject.Task t in project.Tasks)
            {
                //project is the second most out summary task
                if ((t != null) && (t.OutlineLevel == 2))
                {
                    name = t.Name;
                    lineID = t.ID;
                    if (t.Deadline != null)
                        time = t.Deadline.ToString("yyyyMMdd");
                    else
                        time = "0";

                    tempGirder = new GirderList(name, time, lineID);
                    girderList.Add(tempGirder);
                }
            }
            return girderList;
        }

        public void addFactorsTOordering(MSProject.Project project, List<ordering> orders, List<MSprojectLayout> msprojectLayout)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                MSProject.Task t = project.Tasks[orders[i].pre];
                orders[i].preGirderLine = t.Text3;
                for (int j = 0; j < msprojectLayout.Count; j++)
                {
                    if (orders[i].pre >= msprojectLayout[j].activityStartID && orders[i].pre <= msprojectLayout[j].activityEndID)
                    {
                        if (orders[i].pre == msprojectLayout[j].activityStartID)
                            orders[i].preFlag = 1;
                        else
                            orders[i].preFlag = 0;
                        orders[i].preProID = msprojectLayout[j].projectID;
                        orders[i].preGiderName = msprojectLayout[j].girderName;
                    }
                    
                }
            }
            for (int i = 0; i < orders.Count; i++)
            {
                for (int j = 0; j < msprojectLayout.Count; j++)
                {
                    if (orders[i].succ == msprojectLayout[j].activityStartID)
                    {
                        orders[i].succFlag = 1;
                        break;
                    }
                        
                    else
                        orders[i].succFlag = 0;
                }
            }
        }

        public int GetDeadline(MSProject.Task t, MSProject.Project project)
        {
            int deadline; 
            // if the deadline is not set to a project, deadline is set to the maxvalue of int.
            if (t.Deadline.ToString() == "NA")
                deadline = int.MaxValue;
            else
            {
                // for each working day = 8*60 = 480, in minutes
                deadline = 480 * GetNumberOfWorkingDays(project.ProjectStart, Convert.ToDateTime(t.Deadline));
            }
            return deadline;
        }

        private void ConstructMsProjectLayout(MSProject.Task t, int count, ref int startID, ref int lastPID, int projID, ref string girderName, List<MSprojectLayout> msprojectLayout)
        {
            if (count == 1)
            {
                startID = t.ID + 1;
                girderName = t.Name;
                lastPID = projID;
            }
            else
            {
                if (lastPID == projID)
                {
                    MSprojectLayout temp = new MSprojectLayout(projID, girderName, startID, t.ID - 1);
                    msprojectLayout.Add(temp);
                }
                else
                {
                    MSprojectLayout temp = new MSprojectLayout(projID - 1, girderName, startID, t.ID - 2);
                    msprojectLayout.Add(temp);
                    lastPID = projID;
                }

                girderName = t.Name;
                startID = t.ID + 1;
            }
        }

        private int[] GetRsrcRequirement(MSProject.Task t, int nbRsrc)
        {
            //initial the list with n of 0
            int[] tempRsrc = Enumerable.Repeat(0, nbRsrc).ToArray();
            //construct resource list
            switch (t.Text1)
            {
                case "1. Preparation":
                    tempRsrc[0] = 1;
                    break;
                case "2. Girder Assembly":
                    tempRsrc[1] = 1;
                    break;
                case "3. Field Splice":
                    tempRsrc[2] = 1;
                    break;
                case "5. Shipping":
                    tempRsrc[3] = 1;
                    break;
            }
            return tempRsrc;
        }

        private void ConstructOTaskList(MSProject.Task t, string startDate, List<ongoingTask> oTask, List<int> Rsrc, int projID)
        {
            DateTime Now = Convert.ToDateTime(startDate);
            int days = GetNumberOfNonWorkingDays(t.Start, Now);
            DateTime temp = t.Start.AddDays(days);
            int remainingDur = t.Duration - (int)(Now - temp).TotalMinutes / 3;
            ongoingTask tempOTask = new ongoingTask(projID, t.Name, t.ID, remainingDur, t.Start.ToString(), Rsrc);
            oTask.Add(tempOTask);
        }
        private void ConstructOrderingList(MSProject.Task t, int projID, string girderName, List<ordering> orders)
        {
            string type;
            int pre, lag;
            for (int i = 0; i < t.Predecessors.Split(',').Length; i++)
            {
                if (t.Predecessors.Split(',')[i].Contains("SS"))
                    type = "SS";
                else if (t.Predecessors.Split(',')[i].Contains("SF"))
                    type = "SF";
                else if (t.Predecessors.Split(',')[i].Contains("FF"))
                    type = "FF";
                else
                    type = "FS";

                if (t.Predecessors.Split(',')[i].Contains("+"))
                {
                    pre = Convert.ToInt32(Regex.Replace(t.Predecessors.Split(',')[i].Split('+')[0], "[^.0-9]", ""));
                    lag = Convert.ToInt32(Regex.Replace(t.Predecessors.Split(',')[i].Split('+')[1], "[^.0-9]", "")) * 24 * 60;

                }

                else
                {
                    pre = Convert.ToInt32(Regex.Replace(t.Predecessors.Split(',')[i], "[^.0-9]", ""));
                    lag = 0;
                }

                ordering tempOrder = new ordering(pre, t.ID, projID, girderName, t.Text3, type, lag);
                orders.Add(tempOrder);
            }
        }


        private void ReadActName(MSProject.Project project, List<finishedTask> endTaskList, List<ongoingTask> oTask, List<ActivityList> actList, List<ordering> orders, MSprojectInfo projInfo)
        {
            // New the project list
            ActivityList tempAct;
            string name, girderName = "G";
            int lineID = 0, duration, projID = 0, deadline = 0;
            List<int> Rsrc = new List<int>();
            List<MSprojectLayout> msprojectLayout = new List<MSprojectLayout>();
            int startID = 1, count = 0, lastPID = 1;
            foreach (MSProject.Task t in project.Tasks)
            {                               
                //int endID = 1;
                if ((t != null) && (t.OutlineLevel == projInfo.projLevel))
                {
                    //record the project ID and deadline at the project level
                    projID += 1;
                    deadline = GetDeadline(t, project);
                }
                // Read girder info
                else if ((t != null) && (t.OutlineLevel == projInfo.girderLevel))
                {
                    //The first girder in the MS project file
                    //count the total number of girders in the MS project file
                    count++;
                    ConstructMsProjectLayout(t, count, ref startID, ref lastPID, projID, ref girderName, msprojectLayout);                                      
                }
                //Read activity
                else if ((t != null) && (t.OutlineLevel == projInfo.actLevel))
                {
                    // construct activity list
                    name = t.Name;
                    lineID = t.ID;
                    // 8 hours per day, 8*60
                    duration = t.Duration;
                    Rsrc = GetRsrcRequirement(t, projInfo.nbRsrc).ToList();                    

                    if (t.Finish > Convert.ToDateTime(projInfo.startDate) && t.Start < Convert.ToDateTime(projInfo.startDate))
                    {
                        ConstructOTaskList(t, projInfo.startDate, oTask, Rsrc, projID);
                    }
                    else if (t.Start > Convert.ToDateTime(projInfo.startDate))
                    {
                        //construction unstarted tasks list
                        tempAct = new ActivityList(projID, girderName, name, lineID, duration, deadline, Rsrc);
                        actList.Add(tempAct);
                    }
                    else if (t.Finish < Convert.ToDateTime(projInfo.startDate))
                    {
                        //construction finished task list
                        finishedTask tempFTask = new finishedTask(lineID, t.Start.ToString());
                        endTaskList.Add(tempFTask);
                    }

                    //construct ordering list
                    if (t.Predecessors != "")
                    {
                        ConstructOrderingList(t, projID, girderName, orders);
                    }
                }
            }
            MSprojectLayout tempLayout = new MSprojectLayout(projID, girderName, startID, lineID);
            msprojectLayout.Add(tempLayout);
            projInfo.msprojectLayout = msprojectLayout;
            addFactorsTOordering(project, orders, projInfo.msprojectLayout);
            projInfo.nbProj = projID;
        }
        private void OptimizationEngine(MSProject.Project project, List<ongoingTask> oTask, List<ActivityList> activityList, List<ordering> orders, MSprojectInfo projInfo)
        {
            CP cp = new CP();

            // Define the iteration limits
            int failLimit = 30000;

            List<IIntExpr> ends = new List<IIntExpr>();
            List<IIntervalVar> allTasks = new List<IIntervalVar>();

            // ongoing tasks number
            int nbOTasks = oTask.Count();
            // Togo tasks number
            int nbTasks = activityList.Count();
            IIntervalVar[] tasks = new IIntervalVar[nbTasks + nbOTasks];
            //List<IIntervalVar>[] modes = new List<IIntervalVar>[nbTasks];
            string name;

            //Resource limit
            // Initial resource type = 4
            int nbResources = projInfo.nbRsrc;
            //int nbModes = 1;
            int[] capacities = new int[nbResources];
            ICumulFunctionExpr[] RsrcUsages = new ICumulFunctionExpr[nbResources];

            // declare tasks variables 
            for (int i = 0; i < nbOTasks + nbTasks; i++)
            {
                tasks[i] = cp.IntervalVar();
                //modes[i] = new List<IIntervalVar>();
            }

            for (int j = 0; j < nbResources; j++)
            {
                // Assume all resource limit is 1, modify after defining resource limit
                capacities[j] = 1; // int.Parse(shopList[j].capacity[0]);
                RsrcUsages[j] = cp.CumulFunctionExpr();
            }

            // Initial ongoing tasks
            for (int i = 0; i < nbOTasks; i++)
            {
                name = oTask[i].MSprojectLineID.ToString();
                int d = oTask[i].duration;

                IIntervalVar task = tasks[i];
                task.Name = name;
                task.SizeMax = d;
                task.SizeMin = d;
                ends.Add(cp.EndOf(task));

                for (int j = 0; j < nbResources; j++)
                {
                    RsrcUsages[j].Add(cp.Pulse(0, d, oTask[i].RsrcList[j]));
                }
            }

            //define tasks and number of modes
            for (int i = 0; i < nbTasks; i++)
            {
                name = activityList[i].MSprojectLineID.ToString();
                int d = activityList[i].duration;

                IIntervalVar task = tasks[i + nbOTasks];
                task.Name = name;
                task.SizeMax = d;
                task.SizeMin = d;
                ends.Add(cp.EndOf(task));

                for (int j = 0; j < nbResources; j++)
                {
                    RsrcUsages[j].Add(cp.Pulse(task, activityList[i].RsrcList[j]));
                }
            }

           

            // Set precedence relationship
            for (int i = 0; i < orders.Count; i++)
            {
                IIntervalVar preTask = tasks[0], succTask = tasks[0];
                string preGLine = "G", succGLine = "G";
                int prePID = 0, succPID = 0, preFlag = 0, succFlag = 0;
                int count = 0;
                for (int j = 0; j < nbTasks + nbOTasks; j++)
                {
                    
                    if (tasks[j].Name == orders[i].pre.ToString())
                    {
                        preTask = tasks[j];                        
                        count += 1;
                    }
                    else if (tasks[j].Name == orders[i].succ.ToString()) {
                        succTask = tasks[j];                        
                        count += 1;
                    }
                    if (count == 2)
                    {
                        count = 0;
                        preGLine = orders[i].preGirderLine;
                        prePID = orders[i].preProID;
                        preFlag = orders[i].preFlag;
                        succGLine = orders[i].succGirderLine;
                        succPID = orders[i].succProID;
                        succFlag = orders[i].succFlag;
                        switch (orders[i].type)
                        {
                            case "FS":
                                    cp.Add(cp.EndBeforeStart(preTask, succTask, orders[i].lag));
                                break;
                            case "SS":
                                if (preFlag == 1 && succFlag == 1 && preGLine == succGLine && prePID == succPID)
                                    cp.Add(cp.EndAtStart(preTask, succTask));
                                else
                                    cp.Add(cp.StartBeforeStart(preTask, succTask, orders[i].lag));
                                break;
                            case "FF":
                                cp.Add(cp.EndBeforeEnd(preTask, succTask, orders[i].lag));
                                break;
                            case "SF":
                                cp.Add(cp.StartBeforeEnd(preTask, succTask, orders[i].lag));
                                break;
                        }
                        break;
                    }
                       
                }
                
                
            }

            // Set the resource constraint
            for (int j = 0; j < nbResources; j++)
            {
                cp.Add(cp.Le(RsrcUsages[j], capacities[j]));
            }

            //Hard constraint on deadline
            //for (int i = 0; i < nbTasks; i++)
            //{
            //    cp.Add(cp.Le(ends[i], activityList[i].deadline));
            //}

            INumExpr delay = cp.Constant(0);

            //// Minimize the total delay
            for (int j = 0; j < projInfo.nbProj; j++)
            {
                IIntExpr endProj = ends[0];
                int deadline = 0;
                for (int i = 0; i < nbTasks ; i++)
                {
                    if (activityList[i].projID == j + 1)
                    {
                        endProj = cp.Max(endProj, ends[i + nbOTasks]);
                        deadline = activityList[i].deadline;
                    }
                   
                }
                delay = cp.Sum(delay, cp.Abs(cp.Diff(endProj, deadline)));
            }
            

            IObjective objective = cp.Minimize(delay);
            //IObjective objective = cp.Minimize(cp.Max(ends.ToArray()));
            cp.Add(objective);

            cp.SetParameter(CP.IntParam.FailLimit, failLimit);
            if (cp.Solve())
            {
                //MessageBox.Show("optimization solved!");
                //Console.WriteLine("Solution with objective " + cp.ObjValue + ":");
                //for (int i = nbOTasks; i < nbTasks + nbOTasks; i++)
                //{
                //    // sp.girders[i].SchedStart = cp.GetStart(tasks[i]).ToString();
                //    //  string test = cp.GetDomain(tasks[i]);

                //    activityList[i].startTime = cp.GetStart(tasks[i]);

                //}

                for (int i = 0; i < nbTasks; i++)
                {
                    // sp.girders[i].SchedStart = cp.GetStart(tasks[i]).ToString();
                    //  string test = cp.GetDomain(tasks[i]);

                    activityList[i].startTime = cp.GetStart(tasks[i + nbOTasks]);

                }
                //System.IO.File.WriteAllText(@"C:\Users\Public\Resource.txt", RsrcUsages.ToArray().ToString());
            }
            else
            {
                MessageBox.Show("No solution found.");
            }
        }

        private void WriteTodoTask(MSProject.Project project, List<ActivityList> activityList, MSprojectInfo projInfo) {
            int startLine = 1;
            for (int i = 0; i < activityList.Count; i++)
            {
                for (int j = startLine; j <= project.Tasks.Count; j++)
                {
                    MSProject.Task t = project.Tasks[j];
                    if (t.ID == activityList[i].MSprojectLineID)
                    {
                        string start = GetEndDaysIncludingNonWorkingDays(Convert.ToDateTime(projInfo.startDate), activityList[i].startTime).ToString();
                        t.Start = start;
                        startLine = t.ID;
                        break;
                    }
                }
            }
        }

        private void WriteEndedTask(MSProject.Project project, List<finishedTask> endTaskList, MSprojectInfo projInfo)
        {
            int startLine = 1;
            for (int i = 0; i < endTaskList.Count; i++)
            {
                for (int j = startLine; j <= project.Tasks.Count; j++)
                {
                    MSProject.Task t = project.Tasks[j];
                    if (t.ID == endTaskList[i].MSProjectLineID)
                    {
                        t.Start = endTaskList[i].schedStartTime;
                        startLine = t.ID;
                        break;
                    }
                }
            }
        }

        private void WriteOngoingTask(MSProject.Project project, List<ongoingTask> oTask, MSprojectInfo projInfo)
        {
            int startLine = 1;
            for (int i = 0; i < oTask.Count; i++)
            {
                for (int j = startLine; j <= project.Tasks.Count; j++)
                {
                    MSProject.Task t = project.Tasks[j];
                    if (t.ID == oTask[i].MSprojectLineID)
                    {
                        t.Start = oTask[i].schedStartTime;
                        startLine = t.ID;
                        break;
                    }
                }
            }
        }
        private void WriteOptiResult(MSProject.Project project, List<finishedTask> endTaskList, List<ongoingTask> oTask, List<ActivityList> activityList, MSprojectInfo projInfo) {
            //DateTime today = DateTime.Now;
            WriteTodoTask(project, activityList, projInfo);
            //WriteEndedTask(project, endTaskList, projInfo);
            //WriteOngoingTask(project, oTask, projInfo);
        }

        public void OptimizationSch(MSProject.Project project, MSprojectInfo projInfo)
        {

            List<ordering> orders = new List<ordering>();
            List<ActivityList> activityList = new List<ActivityList>();
            List<ongoingTask> oTask = new List<ongoingTask>();
            List<finishedTask> endTaskList = new List<finishedTask>();
            ReadActName(project, endTaskList, oTask, activityList, orders, projInfo);
            OptimizationEngine(project, oTask, activityList, orders, projInfo);
            WriteOptiResult(project, endTaskList, oTask, activityList, projInfo);
        }
    }

}
