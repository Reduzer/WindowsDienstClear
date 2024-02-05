using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace KundenVersionenLöschDienst
{
    internal class HandlersPing
    {
        #region Vars & Obj

        private string importance;
        private string message;
        private string type;
        private int count;

        private string[] recipients;

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        #endregion

        #region Constructors

        public HandlersPing()
        {

        }

        #endregion

        #region Methods

        #region Set

        public string Message
        {
            set { message = value; }
        }

        public string Type
        { 
            set { type = value; } 
        }

        public int Count
        {
            set { count = value; }
        }

        #endregion

        public void ping()
        {
            checkForImportance();
            selectPersonToPing();
            sendPing();
        }

        private void checkForImportance()
        {
            switch (type)
            {
                case "Drop":
                    importance = exceptionEnums.needsHelpNow.ToString();
                    break;
                case "Delete":
                    importance = exceptionEnums.needsDevPing.ToString();
                    break;
                default:
                    break;
            }
        }

        private void selectPersonToPing()
        {
            string sqlCommand;

            switch (importance)
            {
                case "needsHelpNow":
                    sqlCommand = "";
                    break;
                case "needsDevPing":
                    sqlCommand = "";
                    break;
                case "needsAdminPing":
                    sqlCommand = "";
                    break;
                case "none":
                    sqlCommand = "";
                    break;
                default:
                    sqlCommand = "";
                    break;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                    {
                        connection.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            int counter = 0;
                            while (rd.Read())
                            {
                                recipients[counter] = rd.GetString(0);
                                counter++;
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

        private void sendPing()
        {

        }

        #endregion
    }
}
