﻿using KundenVersionenLöschDienst.Skripte;
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

        static DeleteFiles del = new DeleteFiles();
        static updater upd = new updater();
        static SkriptHandler startSkript = new SkriptHandler();
        static clientSetupUpdate updClientSetup = new clientSetupUpdate();
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
            
            //20 Day timer for File Deletion
            Timer timer = new Timer(timercallback, null, 0, 1000 * 60 * 60 * 24 * 20);
            //7 Day Timer for Version Updates
            Timer timerUpdate = new Timer(timercallbackUpdate, null, 0, 7 * 24 * 60 * 60 * 1000);
            //Daily Timer for Certifikate Check
            Timer timerCertifikate = new Timer(dailyCallBack, null, 0, 1 * 24 * 60 * 60 * 1000);
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
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.setException(e.ToString());
            }
        }

        public static void timercallbackUpdate(object state)
        {
            try
            {
                startSkript.startSkripts();
                upd.check();
                updClientSetup.check();
            }
            catch (Exception e)
            {
                ExceptionHandler.setException(e.ToString());
            }
        }

        public static void dailyCallBack(object state)
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

        public static void iniLoad()
        {

        }
    }
}
