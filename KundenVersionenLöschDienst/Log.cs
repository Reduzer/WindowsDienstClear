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

        hashing hash = new hashing();
        FileStream fs;

        #endregion

        #region Vars

        private string path = @"";

        private string message;
        private string date;
        private string time;

        private int count;
        private int acutalCount;
        private int checkMessage;

        #endregion

        #region Constructors

        public Log(string date, string time)
        {
            this.date = date;
            this.time = time;
            createLog();
        }

        #endregion

        #region Methods

        public void createLog()
        {
            using (fs = File.Create(path))
            {
                writeToLog("Log erstellt am: " + date + " um: " + time + " Uhr");
            }
        }

        public bool setMessage(string message, int messageValue)
        {
            this.message = message;

            if (hash.setMessage(message))
            {
                checkMessage = hash.generateHash();
                if (checkMessage == messageValue)
                {
                    writeToLog(null);
                    return true;
                }
                else{
                    return false;
                }
            }
            return false;
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
