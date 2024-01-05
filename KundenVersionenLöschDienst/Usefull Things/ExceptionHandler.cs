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

    static class ExceptionHandler
    {
        #region Vars & Obj

        static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        private static string message;
        private static int count = 0;


        #endregion

        #region Methods

        public static void setException(string e)
        {
            message = e;
            count++;

            writeToDB();
        }

        public static void connectSQL()
        {
            builder.DataSource = "";
            builder.UserID = "";
            builder.Password = "";
            builder.InitialCatalog = "";
        }

        private static void writeToDB()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string sqlCommand = "INSERT INTO dbo.Table_1 (ErrorMessage, ErrorCount) VALUES (@message, @count)";

                    using (SqlCommand cmd = new SqlCommand(sqlCommand,connection))
                    {
                        cmd.Parameters.Add("@message", System.Data.SqlDbType.NVarChar,50).Value = message;
                        cmd.Parameters.Add("@count", System.Data.SqlDbType.Int).Value = count;

                        connection.Open();

                        cmd.ExecuteNonQuery();

                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                setException(e.ToString());
            }
        }
        #endregion

        #region ApPing

        public static void setExceptionAPPing(string msg) 
        { 
            if(msg == ""){
                //Error with Creating Ping
                pingDev();
                writeToDBAP();
            }
            else if(msg == ""){
                //Error on Finding Person
                pingDev();
                writeToDBAP();
            }
            else if(){
                //Error on Connection
                pingDev();
                writeToDBAP();
            }
            else{
                // Other Errors
                pingDev();
                writeToDBAP();
            }
        }

        private static void pingDev(string msg){
            //Create AP Ping for Developer of program
            
        }

        private static void writeToDBAP(){

        }

        #endregion
    }
}