using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using Outlook = Microsoft.Office.Interop.Outlook;
using KundenVersionenLöschDienst;

namespace KundenVersionenLöschDienst {
    public class SendEmailForTask : emailBase 
    {
        #region

        private string importance;
        private string executedCommand;

        #endregion

        public SendEmailForTask()
        {
            base.counter = 0;
        }


        public bool setInfo(string importance, string message, string[] reciever)
        {
            this.importance = importance;
            this.executedCommand = message;
            base.reciever = reciever;

            if (this.importance != null && executedCommand != null && base.reciever != null)
            {
                send();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void send()
        {
            base.message = @"Illegal Command Exception! Executed Command '" + executedCommand + "' Time: " + System.DateTime.Now;
            base.subject = @" " + importance;

            base.sendMail();
        }
    }
}