using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    internal class ApPing
    {
        #region Vars & Obj

        private string[] name;

        //Si in AP
        private string message;
        private string searchName;
        private string date;
        private char[] kuerzelCreator;
        private char[] kuerzelReciever1;
        private char[] kuerzelReciever;
        private string loesungstext;



        #endregion

        #region Constructors

        public ApPing() 
        {
            
        } 

        #endregion

        #region Methods

        public void test()
        {

        }

        public void pingAP()
        {
            try
            {
                if (testApConnection())
                {
                    
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.setExceptionAPPing(e.ToString());
            }  
        }

        private bool testApConnection()
        {
            try
            {
                using (null)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.setException(e.ToString());
                return false;
            }
        }

        #endregion
    }
}
