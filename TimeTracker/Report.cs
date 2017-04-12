using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Day day { get; }

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
            if (totalTime != 0)
                percentProductive = (100.0 * totalProductiveTime) / totalTime;
            else
                percentProductive = 0.0;

            Debug.WriteLine("percent: " + percentProductive + ", total: " + totalTime + ", productive time: " + totalProductiveTime);
        }

        public void printAllActivities()
        {
            day.PrintAllActivities();
        }
        
    }
}
