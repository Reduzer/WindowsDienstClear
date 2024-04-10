using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStarter
{
    internal class hourlyObject
    {
        private string date;
        private string lastTimeChecked;

        public hourlyObject()
        {

        }

        public string LastTimeChecked
        {
            get { return lastTimeChecked; }
            set { lastTimeChecked = value; }
        }
    }
}
