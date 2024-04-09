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

namespace ServiceStarter
{
    internal static class Program
    {
        private static Ping Ping = new Ping();
        private static ClientSetup ClientSetup = new ClientSetup();
        private static Skript Skript = new Skript();
        private static Update Update = new Update();

        private static readonly int timeHourly = 0;

        private static hourlyObject hourlyObject = new hourlyObject();
        private static dailyObject dailyObject = new dailyObject();
        private static monthlyObject monthlyObject = new monthlyObject();

        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new InstandhalterRich()
            };
            ServiceBase.Run(ServicesToRun);

            Timer timerHourly = new Timer(timerCheck, hourlyObject, 0, timeHourly);

        }

        private static void timerCheck(object state)
        {
            if (true /*check for object type*/)
            {

            }
        }

        private static void doTasksHourly()
        {

        }

        private static void doTasksDaily()
        {

        }

        private static void doTasksMonthly()
        {

        }
    }
}
