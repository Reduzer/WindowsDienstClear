using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    internal class HandlersPing
    {
        #region Vars & Obj

        private string importance;
        private string message;
        private string type;
        private int count;

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

        }

        private void checkForImportance()
        {
            switch (type)
            {
                case "Drop":
                    importance = exceptionEnums.needsHelpNow.ToString();
                    break;
                case "Delete":
                    importance = exceptionEnums.needsHelpNow.ToString();
                    break;
                default:
                    break;
            }
        }

        private void selectPersonToPing()
        {

        }

        #endregion
    }
}
