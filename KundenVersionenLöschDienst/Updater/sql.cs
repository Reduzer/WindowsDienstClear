using System;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    internal class sql : sqlBase
    {
        #region Vars & Obj

        private int oldVersion;
        private int newVersion;
        private int currentVersion;
        private int currentID;
        private string date;

        #endregion

        public sql()
        {
            base.setInitialCatalog(@"");
        }

        public bool writeToDB()
        {
            date = System.DateTime.Now.ToString("dd.MM.yyyy");

            try
            {
                using (SqlConnection connection = new SqlConnection(base.builder.ConnectionString))
                {
                    string sql = "INSERT INTO dbo.VersionsLog (OLDVERSION, NEWVERSION, DATE, ID) VALUES (@old, @new, @date, @id)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@old", System.Data.SqlDbType.Int).Value = oldVersion;
                        command.Parameters.Add("@new", System.Data.SqlDbType.Int).Value = newVersion;
                        command.Parameters.Add("@date", System.Data.SqlDbType.NVarChar, 50).Value = date;
                        if (getCurrentID() > 0)
                        {
                            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = currentID;
                        }
                        else
                        {
                            return false;
                        }

                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                }

                oldVersion = newVersion;

                return true;
            }
            catch
            {
                return false;
            }
        }

        private int getCurrentID()
       {
            try
            {
                using (SqlConnection connection = new SqlConnection(base.builder.ConnectionString))
                {
                    string sqlCommand = "SELECT TOP 1 ID FROM dbo.VersionLog ORDER BY ID DESC";

                    using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                    {
                        connection.Open();

                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            currentID = rd.GetInt32(0);
                        }

                        connection.Close();
                    }
                }
                return currentID;
            }
            catch
            {
                return 0;
            }
        }

        public int getCurrentVersion()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(base.builder.ConnectionString))
                {

                    string sqlCommand = "SELECT TOP 1 New FROM dbo.VersionLog ORDER BY ID DESC";

                    using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                    {
                        connection.Open();

                        SqlDataReader rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            currentVersion = rd.GetInt32(0);
                        }

                        connection.Close();
                    }

                    return currentVersion;
                }
            }
            catch
            {
                return oldVersion;
            }
        }
    }
}
