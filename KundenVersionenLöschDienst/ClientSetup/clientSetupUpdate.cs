using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    internal class clientSetupUpdate
    {
        #region Vars & Obj

        //Hinzufügen, der jeweiligen Pfade, wo die Versionen liegen.
        private string sourcePath = @"";
        private string installPath = @"";

        #endregion

        #region Constructors

        public clientSetupUpdate() 
        {
            
        }

        #endregion

        #region Methods 

        public bool check()
        {
            if (getCurrentVersion() != getSourcePathVersion())
            {
                Update();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Update()
        {

        }

        private string getCurrentVersion()
        {
            string currentVersion = "";

            try
            {
                var source = FileVersionInfo.GetVersionInfo(installPath);

                currentVersion = source.FileVersion;

            }
            catch (Exception e)
            {
                ExceptionHandler.setException(e.ToString());
                return null;
            }

            return currentVersion;
        }

        private string getSourcePathVersion()
        {
            string sourcePathVersion = "";

            try
            {
                var source = FileVersionInfo.GetVersionInfo(sourcePath);

                sourcePathVersion = source.FileVersion;
            }
            catch (Exception e) 
            {
                ExceptionHandler.setException(e.ToString());
                return null;
            }

            return sourcePathVersion;
        }

        #endregion
    }
}