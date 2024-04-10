using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStarter
{
    internal class monthlyObject
    {
        private string date;
        private string lastTimeChecked;

        public monthlyObject()
        {

        }

        public string LastTimeChecked
        {
            get { return lastTimeChecked; }
            set { lastTimeChecked = value; }
        }
    }
}
