using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Outlook = Microsoft.Office.Interop.Outlook;

namespace KundenVersionenLöschDienst
{
    public abstract class emailBase
    {
        #region Vars & Obj

        Outlook.Application outlook = new Outlook.Application();

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

        }

        #endregion
    }
}
