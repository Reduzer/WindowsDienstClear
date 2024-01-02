using KundenVersionenLöschDienst.Ping;
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

        static Log log = new Log();
        static DeleteFiles del = new DeleteFiles();
        static updater upd = new updater();
        static ApPing ApPing = new ApPing();
        static EmailPing EmailPing = new EmailPing();

        static int year = 2024;

        #endregion

        static void Main()
        { 
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new InstantHalterRich()
            };
            ServiceBase.Run(ServicesToRun);

            log.setTime(System.DateTime.Today.ToString("dd.MM.yyyy"), System.DateTime.Now.ToString("H.m"));
            
            //20 Day timer for File Deletion
            Timer timer = new Timer(timercallback, null, 0, 1000 * 60 * 60 * 24 * 20);
            //7 Day Timer for Version Updates
            Timer timerUpdate = new Timer(timercallbackUpdate, null, 0, 7 * 24 * 60 * 60 * 1000);


            if (System.DateTime.Now.Date.ToString("dd.MM") == "01.06")
            {
                timercallbackCertifikate();
            }
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
                upd.check();
            }
            catch (Exception e)
            {
                log.setMessage(e.ToString());
            }
        }

        public static void timercallbackCertifikate()
        {
            if (System.DateTime.Today.Date.ToString("dd.MM.yyyy") == "01.06." + year)
            {
                EmailPing.sendEmail();
            }
            else if (System.DateTime.Today.Date.ToString("dd.MM.yyyy") == "25.06." + year)
            {
                ApPing.test();
                year++;
            }
            else
            {
                return;
            }
        }
    }
}
