using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BackupService.src
{
    internal class connectSql
    {
        private SqlConnectionStringBuilder builder;
        private List<string> vs_SqlSkriptNames = new List<string>();

        public connectSql()
        {
            builder = new SqlConnectionStringBuilder();
        }

        public void connectToSql()
        {

        }

        private void setSqlInfo()
        {
            builder.UserID = "";
            builder.Password = "";
            builder.InitialCatalog = "";
            builder.ConnectionString = "";
        }

    }
}
