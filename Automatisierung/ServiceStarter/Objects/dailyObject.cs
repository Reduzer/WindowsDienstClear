﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStarter
{
    internal class dailyObject
    {
        private const string type = "daily";
        private string nextTimeToDo;
        private string lastTimeChecked;

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
