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
    internal class pingSql
    {
        #region Vars & Obj

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        private string[] mailUser;
        private int count;


        #endregion

        #region Constructors

        public pingSql()
        {
            connectSql();
        }

        #endregion

        #region Methods

        private  void connectSql()
        {
            builder.UserID = "sa";
            builder.Password = "applesauce/2";
            builder.DataSource = "FDEU-131\\SQLEXPRESS";
            builder.InitialCatalog = "Test2";
        }

        public string[] returnMailUsers()
        {
            getEmailUsers();

            return mailUser;
        }

        private void getEmailUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    string sqlCommand = "";

                    using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                    {
                        connection.Open();

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while(rd.Read())
                            {
                                mailUser[count] = rd.GetString(count);
                                count++;
                            }
                        }

                        connection.Close();
                        count = 0;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.setException(e.ToString());
            }
        }

        #endregion
    }
}