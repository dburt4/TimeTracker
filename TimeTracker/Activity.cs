using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class Activity
    {
        public String activityName { get; set; }
        public int timeSpent { get; set; } 
        public Boolean isProductive { get; set; }
        private List<String> productiveTerms = new List<string> {"code", "coding", "coded", "email", "research" };

        public Activity(String activityName, DateTime startingTime)
        {
            this.activityName = activityName;
            DateTime endingTime = DateTime.Now;
            TimeSpan timeSpan = endingTime.Subtract(startingTime);
            //Debug.WriteLine("Seconds difference: " + timeSpan.Seconds);
            timeSpent = timeSpan.Minutes;
            //timeSpent = timeSpan.Seconds;
            //Debug.WriteLine("Minutes difference: " + minuteDifference);
            isProductive = CheckProductive(activityName);
            
        }

        private bool CheckProductive(string activityName)
        {
            String[] words = activityName.Split(' ');
            foreach(String word in words)
            {
                if (productiveTerms.Contains(word.ToLower()))
                    return true;
            }
            return false;
        }
    }
}
