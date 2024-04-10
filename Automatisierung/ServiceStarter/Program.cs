using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using PingService;
using ClientSetupService;
using SkriptService;
using UpdateService;
using System.Threading;
using ServiceStarter.Objects;

namespace ServiceStarter
{
    internal static class Program
    {
        private static Ping Ping = new Ping();
        private static ClientSetup ClientSetup = new ClientSetup();
        private static Skript Skript = new Skript();
        private static Update Update = new Update();

        private static hourlyObject hourlyObject = new hourlyObject();
        private static dailyObject dailyObject = new dailyObject();
        private static weeklyObject weeklyObject = new weeklyObject();
        private static monthlyObject monthlyObject = new monthlyObject();

        private static readonly int timeHourly = 0 * 0 * 0 * 60 * 60 * 1000;
        private static readonly int timeDaily = 0 * 0 * 24 * 60 * 60 * 1000;
        private static readonly int timeWeekly = 0 * 7 * 24 * 60 * 60 * 1000;
        private static readonly long timeMonthly = 30 * 24 * 60 * 60 * 1000; 

        private static readonly int timeForDailyTasks = 17;

        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new InstandhalterRich()
            };
            ServiceBase.Run(ServicesToRun);

            unchecked
            {
                Timer timerHourly = new Timer(timerCheck, hourlyObject, 0, timeHourly);
                Timer timerDaily = new Timer(timerCheck, dailyObject, 0, timeDaily);
                Timer timerWeekly = new Timer(timerCheck, weeklyObject, 0, timeWeekly);
                Timer timerMonthly = new Timer(timerCheck, monthlyObject, 0, timeMonthly);
            }
        }

        private static void timerCheck(object state)
        {
            if (state == hourlyObject)
            {
                doTasksHourly();
            }
            else
            {
                if (state == dailyObject)
                {
                    doTasksDaily();
                }
                else
                {
                    if (state == weeklyObject)
                    {
                        doTasksWeekly();
                    }
                    else
                    {
                        if (state == monthlyObject)
                        {
                            doTasksMonthly();
                        }
                    }

                }
            }
        }

        private static void doTasksHourly()
        {
            if (System.DateTime.Now.Hour == timeForDailyTasks)
            {

            }
        }

        private static void doTasksDaily()
        {

        }

        private static void doTasksWeekly()
        {

        }

        private static void doTasksMonthly()
        {

        }
    }
}