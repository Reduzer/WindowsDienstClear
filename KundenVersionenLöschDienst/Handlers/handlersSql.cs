using Microsoft.Office.Interop.Outlook;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace KundenVersionenLöschDienst
{
    public class handlersSql
    {
        #region Vars & Obj

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        private string message;
        private string type;
        private string target;
        private int count;

        private string[] wordsOfMessage;

        #endregion

        #region Constructors

        public handlersSql() 
        {
            builder.ConnectionString = @"";
            builder.UserID = @"";   
            builder.Password = @"";
            builder.InitialCatalog = @"";
        }

        #endregion

        #region Methods

        public void setInfo(string message, int count)
        {
            this.message = message;
            this.count = count;

            check();
        }


        private void check()
        {
            wordsOfMessage = message.Split(' ');

            if (wordsOfMessage.Contains("DROP") )
            {
                type = @"Drop";
                target = wordsOfMessage[2];
            }
            else if(wordsOfMessage.Contains("DELETE"))
            {
                type = @"Delete";
                target = wordsOfMessage[2];
            }

            ExceptionHandler.setType(type);

            writeToDB();
        }

        private void writeToDB()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string sqlCommand = "INSERT INTO dbo.Table_1 (ErrorMessage, ErrorCount, ErrorType, ErrorTarget) VALUES (@message, @count, @type, @target)";

                    using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                    {
                        cmd.Parameters.Add("@message", System.Data.SqlDbType.NVarChar, 50).Value = message;
                        cmd.Parameters.Add("@count", System.Data.SqlDbType.Int).Value = count;
                        cmd.Parameters.Add("@type", System.Data.SqlDbType.NVarChar, 50).Value = type;
                        cmd.Parameters.Add("@target", System.Data.SqlDbType.NVarChar, 50).Value = target;

                        connection.Open();

                        cmd.ExecuteNonQuery();

                        connection.Close();
                    }
                }
            }
            catch (System.Exception e)
            {
                ExceptionHandler.setException(e.ToString());
            }
        }

        #endregion
    }
}
