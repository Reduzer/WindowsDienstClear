using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Office.Interop.Outlook;

namespace KundenVersionenLöschDienst
{
    static class ExceptionHandler
    {
        #region Vars & Obj

        private static SendEmailForTask smft = new SendEmailForTask();
        private static handlersSql handlersSql = new handlersSql();
        private static HandlersPing handlersPing = new HandlersPing();

        private static string message;
        private static string type;
        private static int count = 0;

        #endregion

        #region Methods

        public static void setException(string e)
        {
            message = e;
            count++;

            handlersSql.setInfo(e, count);
            ping();
        }

        private static void ping()
        {
            handlersPing.Message = message;
            handlersPing.Count = count;
            handlersPing.Type = type;

        }

        public static void setType(string x)
        {
            type = x;
        }

        #endregion
    }
}