using Automatisierung.src.Enums;
using Automatisierung.src.tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatisierung.src.check
{
    internal class checkHandler
    {
        private string time;
        private string date;
        private string fullDate;

        private const string timeForDailyTask = "17";
        private const string timeForWeeklyTask = "Friday";
        private readonly string[] month = new string[] {"1","2","3","4","5","6","7","8","9","10","11","12"}; 
        private const string timeForMonthlyTask = "31";
        private const string timeForYearlyTask = "31.12";

        private taskHandler taskHandler = new taskHandler();

        public checkHandler()
        {

        }

        public void check(string time, string date, string fullDate)
        {
            this.time = time;
            this.date = date;
            this.fullDate = fullDate;

            checkForTasks();
        }

        private void checkForTasks() 
        {
            if (time == timeForDailyTask)
            {
                sendTask(taskEnum.daily.ToString());
            }
            else
            {
                if (true)
                {

                }
            }
        }

        public void sendTask(string tasksToDo)
        {
            switch (tasksToDo)
            {

            }
        }
    }
}
