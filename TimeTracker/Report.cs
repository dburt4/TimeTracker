using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TimeTracker
{
    class Report
    {
        public double percentProductive { get; }
        public int totalTime { get; }
        public int totalProductiveTime { get; }
        public Day day { get; }
        public int avgFocusTime { get; }

        public Report(Day day)
        {
            this.day = day;
            List<Activity> activites = day.GetAllActivities();
            int totalProductive = 0;
            foreach (Activity activity in activites)
            {
                totalTime += activity.timeSpent;
                if (activity.isProductive)
                {
                    totalProductiveTime += activity.timeSpent;
                    totalProductive++;
                }

            }
            if (totalTime != 0)
                percentProductive = (100.0 * totalProductiveTime) / totalTime;
            else
                percentProductive = 0.0;
            if(totalProductive != 0)
                avgFocusTime = totalProductiveTime / totalProductive;

            Debug.WriteLine("percent: " + percentProductive + ", total: " + totalTime + ", productive time: " + totalProductiveTime);
        }

        public void printAllActivities()
        {
            day.PrintAllActivities();
        }
        
    }
}
