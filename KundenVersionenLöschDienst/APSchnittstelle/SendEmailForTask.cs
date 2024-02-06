using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using Outlook = Microsoft.Office.Interop.Outlook;

namespace KundenVersionenLöschDienst {
    public class SendEmailForTask : emailBase 
    {
        private SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        private int counter;

        public SendEmailForTask()
        {
            counter = 0;
        }

        private void connectSQL()
        {
            builder.DataSource = "FDEU-131\\SQLEXPRESS";
            builder.UserID = "sa";
            builder.Password = "applesauce/2";
            builder.InitialCatalog = "InstanthalterRichDB";
        }

        private void getReciever()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string SqlCommand = "";
                    int i = 0;

                    using (SqlCommand cmd = new SqlCommand(SqlCommand, connection))
                    {
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                base.reciever[i] = rd.GetString(0);
                                i++;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.setException(e.ToString());
            }
        }

        public void setMessage(string msg)
        {
            message = msg;
            counter++;
            getReciever();
            sendMailToDev();
        }

        private void sendMailToDev()
        {
            try
            {
                Outlook.MailItem mailItem = (Outlook.MailItem)outlook.CreateItem(Outlook.OlItemType.olMailItem);

                Outlook.Recipient orecipient;

                foreach (string s in reciever)
                {
                    orecipient = (Outlook.Recipient)mailItem.Recipients.Add(s);
                    orecipient.Resolve();
                }

                mailItem.Subject = subject;

                mailItem.Body = message;

                mailItem.Save();
                mailItem.Send();

                orecipient = null;
                mailItem = null;
                outlook = null;
            }
            catch (Exception e)
            {
                ExceptionHandler.setException(e.ToString());
            }
        }
    }
}