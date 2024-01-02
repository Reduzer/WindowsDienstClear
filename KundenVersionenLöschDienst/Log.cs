using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    internal class Log
    {
        #region Objects

        FileStream fs;

        #endregion

        #region Vars

        private string path = @"./Logs";

        private string message;
        private string date;
        private string time;

        private int count;
        private int acutalCount;
        private int checkMessage;

        #endregion

        #region Constructors

        public Log()
        {
            createLog();
        }

        #endregion

        #region Methods

        public void setTime(string date, string time)
        {
            this.date = date;
            this.time = time;
        }

        public void createLog()
        {
            using (fs = File.Create(path))
            {
                writeToLog("Log erstellt am: " + date + " um: " + time + " Uhr");
            }
        }

        public void setMessage(string message)
        {
            this.message = message;

            writeToLog(message);
        }

        public void setCount(int count)
        {
            this.count = count;
            writeToLog(count.ToString());
        }

        public void setActualCount(int actualcount)
        {
            this.acutalCount = actualcount;
            writeToLog(actualcount.ToString());
        }

        private void writeToLog(string msg)
        {
            byte[] mesg = new UTF8Encoding(true).GetBytes(message);
            byte[] mesgMSG = new UTF8Encoding(true).GetBytes(msg);

            if (msg == null)
            {
                fs.Write(mesg, 0 , mesg.Length);
            }
            else if(msg != null)
            {
                fs.Write(mesgMSG, 0 , mesgMSG.Length);
            } 
        }

        #endregion
    }
}
