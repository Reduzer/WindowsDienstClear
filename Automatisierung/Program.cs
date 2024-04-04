using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automatisierung
{
    internal static class Program
    {
        private static Timer daily;
        private static Timer hourlyTimer;

        private static string currentDate;
        private static string lastDateActed;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Instanthalterrich()
            };
            ServiceBase.Run(ServicesToRun);

            //Hourly timer
            hourlyTimer = new Timer(check, null, 0, 0 * 0 * 1 * 60 * 60 * 1000);
            //Daily timer
            daily = new Timer(check, null, 0, 0 * 1 * 24 * 60 * 60 * 1000);
        }

        static void check(object state)
        {
            var time = System.DateTime.Now.Hour.ToString();
            var date = System.DateTime.Now.ToString("dd,MM,yyyy");

            if (time == "17")
            {
                
            }

            switch (date)
            {

            }
        }
    }
}
