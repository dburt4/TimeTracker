using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class Day
    {
        private List<Activity> activities;

        public Day()
        {
            activities = new List<Activity>();
        }

        public void AddActivity(Activity activity)
        {
            activities.Add(activity);
        }

        public void PrintAllActivities()
        {
            Debug.WriteLine("-------- ALL ACTIVITIES: -----------");
            foreach(Activity activity in activities)
            {
                Debug.WriteLine("Activity: " + activity.activityName + " time spend: " + activity.timeSpent + ", which is productive?" + activity.isProductive);
            }
        }

        public List<Activity> GetAllActivities()
        {
            return activities;
        }
    }
}
