using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    internal static class Program
    {
        #region Objects

        static Log log = new Log(System.DateTime.Today.ToString("dd.MM.yyyy"), System.DateTime.Today.ToString("H,m"));
        static DeleteFiles del = new DeleteFiles();
        static updater upd = new updater();

        #endregion

        static void Main()
        { 
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new InstantHalterRich()
            };
            ServiceBase.Run(ServicesToRun);
            
            //30 Day timer
            Timer timer = new Timer(timercallback, null, 0, 1000 * 60 * 60 * 24 * 10);
            Timer timerUpdate = new Timer(timercallbackUpdate, null, 0, 7 * 24 * 60 * 60 * 1000);
        }

        public static void timercallback(object state)
        {
            try
            {
                del.countFiles();
                del.countFilesToDelete();
                if (del.deleteFiles())
                {
                    return;
                }
                else
                {
                    log.setMessage("An error accured but we dont know what tf happend");
                }
            }
            catch (Exception e)
            {
                log.setMessage(e.ToString());
            }
        }
        public static void timercallbackUpdate(object state)
        {
            try
            {

            }
            catch (Exception e)
            {
                log.setMessage(e.ToString());
            }
        }
    }
}
