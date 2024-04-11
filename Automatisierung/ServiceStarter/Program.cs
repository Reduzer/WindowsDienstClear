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
using ServiceStarter.Enums;

namespace ServiceStarter
{
    internal static class Program
    {
        private static timeObject m_hourlyObject = new timeObject(timeIntervals.hourly.ToString());
        private static timeObject m_dailyObject = new timeObject(timeIntervals.daily.ToString());
        private static timeObject m_weeklyObject = new timeObject(timeIntervals.weekly.ToString());
        private static timeObject m_monthlyObject = new timeObject(timeIntervals.monthly.ToString());
        private static timeObject m_quaterlyObject = new timeObject(timeIntervals.quaterly.ToString());
        private static timeObject m_fourMonthObject = new timeObject(timeIntervals.fourMonth.ToString());
        private static timeObject m_halfYearObject = new timeObject(timeIntervals.halfYear.ToString());
        private static timeObject m_anualyObject = new timeObject(timeIntervals.anualy.ToString());

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

            Timer timerHourly = new Timer(timerCheck, m_hourlyObject, 0, timeHourly);
            Timer timerDaily = new Timer(timerCheck, m_dailyObject, 0, timeDaily);
            Timer timerWeekly = new Timer(timerCheck, m_weeklyObject, 0, timeWeekly);
            Timer timerMonthly = new Timer(timerCheck, m_monthlyObject, 0, timeMonthly);
            
        }

        private static void timerCheck(object state)
        {
            if (state == m_hourlyObject)
            {
                taskHandler.newTask(m_hourlyObject);
            }
            else
            {
                if (state == m_dailyObject)
                {
                    if (System.DateTime.Now.Hour == timeForDailyTasks)
                    {
                        taskHandler.newTask(m_dailyObject);
                    }
                }
                else
                {
                    if (state == m_weeklyObject)
                    {
                        taskHandler.newTask(m_weeklyObject);
                    }
                    else
                    {
                        if (state == m_monthlyObject)
                        {
                            taskHandler.newTask(m_monthlyObject);
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