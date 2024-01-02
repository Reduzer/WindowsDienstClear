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
            builder.ConnectionString = "";
            builder.InitialCatalog = "";
        }

        private void getEmailUsers()
        {

        }

        #endregion
    }
}