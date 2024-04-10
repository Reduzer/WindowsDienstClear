using ClientSetupService;
using PingService;
using SkriptService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateService;

namespace ServiceStarter
{
    internal class taskHandler
    {
        private Ping Pong = new Ping();
        private ClientSetup ClientSetup = new ClientSetup();
        private Skript Skript = new Skript();
        private Update Update = new Update();

        public taskHandler()
        {

        }

        public void newTask(ServiceStarter.timeObject TaskOBJ)
        {
            switch (TaskOBJ.Type)
            {
                case "hourly":
                    doTasksHourly();
                    break;
                case "daily":
                    doTasksDaily();
                    break;
                case "weekly":
                    doTasksWeekly();
                    break;
                case "monthly":
                    doTasksMonthly();
                    break;
                default:
                    break;
            }
        }

        private void doTasksHourly()
        {

        }

        private void doTasksDaily()
        {

        }

        private void doTasksWeekly()
        {

        }

        private void doTasksMonthly()
        {

        }

    }
}
