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
        public class MSprojectInfo
        {
            public string startDate;
            public int nbProj;
            public int projLevel;
            public int actLevel;
            public int nbRsrc;
            public List<int> RsrcLimit;
            

            public MSprojectInfo(string date, int ProjLevel, int ActLevel, int NbRsrc, List<int> Rsrclimit)
            {
                startDate = date;
                projLevel = ProjLevel;
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
        private class ongoingTask
        {
            int schedStartTime;
            int duration;
            List<int> RsrcList;
        }

        public class ActivityList
        {
            public int projID;
            public string girderName;
            public string activityName;
            public int MSprojectLineID;
            public int duration;
            public int startTime;
            public int deadline;
            //public int nbRsrc;
            public List<int> RsrcList;

            public ActivityList(int pID, string gName, string aName, int lineID)
            {
                projID = pID;
                girderName = gName;
                activityName = aName;
                MSprojectLineID = lineID;
               
            }
            public ActivityList(int pID, string aName, int lineID, int aDuration, int dtime, List<int> rsrcList)
            {
                projID = pID;
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
            public int succ;
            public string type; // relationship type
            public int lag;

            public ordering(int pred, int succe, string rType, int lagT) {
                pre = pred;
                succ = succe;
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

        private void ReadActName(MSProject.Project project, List<ActivityList> actList, List<ordering> orders, MSprojectInfo projInfo)
        {
            // New the project list
            ActivityList tempAct;
            string name;
            int lineID, duration;
            
            ordering tempOrder;
            int pre, lag;
            int succ;
            string type;
            int projID = 0;
            
            int deadline = 0;
            List<int> Rsrc = new List<int>();
            foreach (MSProject.Task t in project.Tasks)
            {
                if ((t != null) && (t.OutlineLevel == projInfo.projLevel))
                {
                    projID += 1;
                    // if the deadline is not set to a project, deadline is set to the maxvalue of int.
                    if (t.Deadline.ToString() == "NA")
                        deadline = int.MaxValue;
                    else
                    {
                        // for each working day = 8*60 = 480
                        deadline = 480 * GetNumberOfWorkingDays(project.ProjectStart, Convert.ToDateTime(t.Deadline));
                    }
                }
                    
                //project is the second most out summary task
                else if ((t != null) && (t.OutlineLevel == projInfo.actLevel))
                {
                    // construct activity list
                    name = t.Name;
                    lineID = t.ID;
                    // 8 hours per day, 8*60
                    duration = t.Duration;
                    
                    succ = t.ID;
                    int[] tempRsrc = Enumerable.Repeat(0, projInfo.nbRsrc).ToArray();
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
                    Rsrc = tempRsrc.ToList();

                    tempAct = new ActivityList(projID, name, lineID, duration, deadline, tempRsrc.ToList());
                    actList.Add(tempAct);

                    //construct ordering list
                    if (t.Predecessors != "") {
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
                                lag = Convert.ToInt32(Regex.Replace(t.Predecessors.Split(',')[i].Split('+')[1], "[^.0-9]", ""));

                            }

                            else
                            {
                                pre = Convert.ToInt32(Regex.Replace(t.Predecessors.Split(',')[i], "[^.0-9]", ""));
                                lag = 0;
                            }
                            tempOrder = new ordering(pre, succ, type, lag);
                            orders.Add(tempOrder);
                        }
                    }
                }
            }
            projInfo.nbProj = projID;
        }
        private void OptimizationEngine(MSProject.Project project, List<ActivityList> activityList, List<ordering> orders, MSprojectInfo projInfo)
        {
            CP cp = new CP();

            // Define the iteration limits
            int failLimit = 30000;

            List<IIntExpr> ends = new List<IIntExpr>();
            List<IIntervalVar> allTasks = new List<IIntervalVar>();

            int nbTasks = activityList.Count();
            IIntervalVar[] tasks = new IIntervalVar[nbTasks];
            //List<IIntervalVar>[] modes = new List<IIntervalVar>[nbTasks];
            string name;

            //Resource limit
            // Initial resource type = 4
            int nbResources = projInfo.nbRsrc;
            //int nbModes = 1;
            int[] capacities = new int[nbResources];
            ICumulFunctionExpr[] RsrcUsages = new ICumulFunctionExpr[nbResources];

            //Initial 
            for (int i = 0; i < nbTasks; i++)
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

            //define tasks and number of modes
            for (int i = 0; i < nbTasks; ++i)
            {
                name = activityList[i].MSprojectLineID.ToString();
                IIntervalVar task = tasks[i];
                int d = activityList[i].duration;
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
                for (int j = 0; j < nbTasks; j++)
                {
                    int count = 0;
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
                        break;
                }
                switch (orders[i].type)
                {
                    case "FS":
                        cp.Add(cp.EndBeforeStart(preTask, succTask, orders[i].lag));
                        break;
                    case "SS":
                        cp.Add(cp.StartBeforeStart(preTask, succTask, orders[i].lag));
                        break;
                    case "FF":
                        cp.Add(cp.EndBeforeEnd(preTask, succTask, orders[i].lag));
                        break;
                    case "SF":
                        cp.Add(cp.StartBeforeEnd(preTask, succTask, orders[i].lag));
                        break;
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
                for (int i = 0; i < nbTasks; i++)
                {
                    if (activityList[i].projID == j + 1)
                    {
                        endProj = cp.Max(endProj, ends[i]);
                    }
                    delay = cp.Sum(delay, cp.Abs(cp.Diff(endProj, activityList[i].deadline)));
                }
            }
            

            IObjective objective = cp.Minimize(delay);
            //IObjective objective = cp.Minimize(cp.Max(ends.ToArray()));
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

                    activityList[i].startTime = cp.GetStart(tasks[i]);

                }
                //System.IO.File.WriteAllText(@"C:\Users\Public\Resource.txt", RsrcUsages.ToArray().ToString());
            }
            else
            {
                MessageBox.Show("No solution found.");
            }
        }

        private void WriteOptiResult(MSProject.Project project, List<ActivityList> activityList) {
            //DateTime today = DateTime.Now;
            int startLine = 1;
            for (int i = 0; i < activityList.Count; i++)
            {
                for (int j = startLine; j <= project.Tasks.Count; j++)
                {
                    MSProject.Task t = project.Tasks[j];
                    if (t.ID == activityList[i].MSprojectLineID)
                    {
                        string start = GetEndDaysIncludingNonWorkingDays(project.ProjectStart, activityList[i].startTime).ToString();
                        t.Start = start;
                        startLine = t.ID;
                        break;
                    }
                }
            }
        }
        public void OptimizationSch(MSProject.Project project, MSprojectInfo projInfo)
        {

            List<ordering> orders = new List<ordering>();
            List<ActivityList> activityList = new List<ActivityList>();
            ReadActName(project, activityList, orders, projInfo);
            OptimizationEngine(project, activityList, orders, projInfo);
            WriteOptiResult(project, activityList);
            //Read Resource requirements from MS project

           
            int test = activityList.Count;

        }
    }

}
