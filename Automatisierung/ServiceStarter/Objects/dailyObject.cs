using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStarter
{
    internal class dailyObject
    {
        private string date;
        private string lastTimeChecked;

        public dailyObject()
        {

        }

        public string LastTimeChecked
        {
            get { return lastTimeChecked; }
            set { lastTimeChecked = value; }
        }
    }
}
