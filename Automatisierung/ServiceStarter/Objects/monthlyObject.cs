using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStarter
{
    internal class monthlyObject
    {
        private const string type = "monthly";
        private string nextTimeToDo;
        private string lastTimeChecked;

        public string LastTimeChecked
        {
            get { return lastTimeChecked; }
            set { lastTimeChecked = value; }
        }

        public string NextTimeToDo
        {
            get { return nextTimeToDo; }
            set { nextTimeToDo = value; } 
        }

        public string Type
        {
            get { return type; }
        }
    }
}
