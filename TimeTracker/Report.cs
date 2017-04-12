using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class Report
    {
        public double percentProductive { get; }
        public int totalTime { get; }
        public int totalProductiveTime { get; }
        private Day day;

        public Report(Day day)
        {
            this.day = day;
            List<Activity> activites = day.GetAllActivities();
            foreach (Activity activity in activites)
            {
                totalTime += activity.timeSpent;
                if (activity.isProductive)
                    totalProductiveTime += activity.timeSpent;

            }
            percentProductive = totalProductiveTime / totalTime;
        }
        
    }
}
