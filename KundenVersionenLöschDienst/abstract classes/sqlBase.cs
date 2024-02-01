using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    public class sqlBase
    {
        #region Vars & Obj

        protected SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        protected string dataSource = @"";
        protected string userID = @"";
        protected string password = @"";
        protected string initialCatalog;

        #endregion

        #region Constructors

        public sqlBase()
        {
            
        }

        #endregion

        #region Methods

        public bool setInitialCatalog(string x)
        {
            this.initialCatalog = x;
            return true;
        }

        public void connectSql()
        {
            builder.DataSource = dataSource;
            builder.UserID = userID;
            builder.Password = password;
            builder.InitialCatalog = initialCatalog;
        }

        #endregion
    }
}
