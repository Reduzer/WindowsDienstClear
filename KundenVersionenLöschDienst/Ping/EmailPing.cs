using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Outlook = Microsoft.Office.Interop.Outlook;

namespace KundenVersionenLöschDienst
{
    internal class EmailPing
    {
        #region Vars & Obj

        pingSql pingsql = new pingSql();

        private string[] emailAdress;
        private string subject;
        private string message;

        Outlook.Application outlook = new Outlook.Application();

        #endregion

        #region Constructors

        public EmailPing()
        {
            subject = "SSL Zertifikat erneuerung";
            message = "Moin, hier einmal eine Erinnerung, dass das SSL Zertifikat des Schulungs-Servers in knapp einem Monat ausläuft. \nBitte daran denken, dies zu erneuern. \nEin AlphaPlan Ping folgt auch noch ^^\n\nLg der Instanthalerrich";
        }

        #endregion

        #region Methods

        private void setEmailAdresses()
        {
            emailAdress = pingsql.returnMailUsers();
        }

        public void sendEmail()
        {
            setEmailAdresses();

            try
            {
                Outlook.Application outlook = new Outlook.Application();

                Outlook.MailItem oMsg = (Outlook.MailItem)outlook.CreateItem(Outlook.OlItemType.olMailItem);

                Outlook.Recipient oRecipient1 = (Outlook.Recipient)oMsg.Recipients.Add(emailAdress[0]);
                Outlook.Recipient oRecipient2 = (Outlook.Recipient)oMsg.Recipients.Add(emailAdress[1]);
                oRecipient1.Resolve();

                oMsg.Subject = subject;

                oMsg.Body = message;

                oMsg.Save();
                oMsg.Send();

                oRecipient1 = null;
                oRecipient2 = null;
                oMsg = null;
                outlook = null;

            }
            catch (Exception e) 
            {
                Debug.WriteLine(e.ToString());
            }
        }
        #endregion
    }
}
