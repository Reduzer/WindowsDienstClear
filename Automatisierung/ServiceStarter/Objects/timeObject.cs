using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStarter
{
    internal class timeObject
    {
        private readonly string type;
        private string nextTimeToDo;
        private string lastTimeChecked;

        public timeObject(string type)
        {
            this.type = type;
        }

        public string NextTimeToDo
        {
            get { return nextTimeToDo; }
            set { nextTimeToDo = value; }
        }

        public string LastTimeChecked
        {
            get { return lastTimeChecked; }
            set { lastTimeChecked = value; }
        }

        public string Type
        {
            get { return type; }
        }
    }
}
