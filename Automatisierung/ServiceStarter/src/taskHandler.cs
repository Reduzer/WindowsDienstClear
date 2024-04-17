using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UpdateService;
using ClientSetupService;
using PingService;
using SkriptService;
using BackupService;
using LockUsersService;
using ServiceStarter.Exceptions;

namespace ServiceStarter
{
    /// <summary>
    /// 
    /// </summary>
    internal class taskHandler
    {
        private Ping Pong = new Ping();
        private ClientSetup ClientSetup = new ClientSetup();
        private Skript Skript = new Skript();
        private Update Update = new Update();
        private Backup backup = new Backup();
        private lockusers lockusers = new lockusers();

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
            try
            {
                lockusers.lockUsers();
            }
            catch (FailedToExecuteExceptions)
            {

            }
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
