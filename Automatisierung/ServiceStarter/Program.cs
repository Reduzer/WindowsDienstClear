using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using PingService;
using ClientSetupService;
using SkriptService;
using UpdateService;


namespace ServiceStarter
{
    internal static class Program
    {

        private static timeObject hourlyObject = new timeObject("hourly");
        private static timeObject dailyObject = new timeObject("daily");
        private static timeObject weeklyObject = new timeObject("weekly");
        private static timeObject monthlyObject = new timeObject("monthly");

        private static taskHandler taskHandler = new taskHandler();

        private static readonly int timeHourly = 60 * 60 * 1000;
        private static readonly int timeDaily = timeHourly * 24;
        private static readonly int timeWeekly = timeDaily * 7;
        private static readonly int timeMonthly = timeWeekly * 30; 

        private static readonly int timeForDailyTasks = 17;

        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new InstandhalterRich()
            };
            ServiceBase.Run(ServicesToRun);

            Timer timerHourly = new Timer(timerCheck, hourlyObject, 0, timeHourly);
            Timer timerDaily = new Timer(timerCheck, dailyObject, 0, timeDaily);
            Timer timerWeekly = new Timer(timerCheck, weeklyObject, 0, timeWeekly);
            Timer timerMonthly = new Timer(timerCheck, monthlyObject, 0, timeMonthly);
            
        }

        private static void timerCheck(object state)
        {
            if (state == hourlyObject)
            {
                taskHandler.newTask(hourlyObject);
            }
            else
            {
                if (state == dailyObject)
                {
                    if (System.DateTime.Now.Hour == timeForDailyTasks)
                    {
                        taskHandler.newTask(dailyObject);
                    }
                }
                else
                {
                    if (state == weeklyObject)
                    {
                        taskHandler.newTask(weeklyObject);
                    }
                    else
                    {
                        if (state == monthlyObject)
                        {
                            taskHandler.newTask(monthlyObject);
                        }
                        else
                        {
                            throw new Exception("Aufgabenverteilung Scheitert aus Gründen");
                        }
                    }

                }
            }
        }
    }
}