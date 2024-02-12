using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Outlook = Microsoft.Office.Interop.Outlook;

namespace KundenVersionenLöschDienst
{
    public abstract class emailBase
    {
        #region Vars & Obj

        protected Outlook.Application outlook = new Outlook.Application();

        protected string[] reciever;
        protected string subject;
        protected string message;

        protected int counter = 0;

        #endregion

        #region Get & Set

        public String[] Reciever
        {
            get { return reciever; }
            set { reciever = value; }
        }

        public String Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string Message
        {
            get { return message;}
            set { message = value; }
        }

        #endregion

        #region Constructors

        public emailBase()
        {

        }

        #endregion

        #region Methods

        protected void sendMail()
        {
            try
            {
                Outlook.MailItem mailItem = (Outlook.MailItem)outlook.CreateItem(Outlook.OlItemType.olMailItem);

                Outlook.Recipient recipient;

                foreach (string s in reciever)
                {
                    recipient = (Outlook.Recipient)mailItem.Recipients.Add(s);
                    recipient.Resolve();
                }

                mailItem.Subject = subject;
                mailItem.Body = message;

                mailItem.Save();
                mailItem.Send();

                recipient = null;
                mailItem = null;
                outlook = null;
            }
            catch (System.Exception e)
            {
                ExceptionHandler.setException(e.ToString());
            }
        }

        #endregion
    }
}
