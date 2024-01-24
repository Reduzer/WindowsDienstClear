using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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

        deleteOldSetup delOld;

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
                delOld = new deleteOldSetup(getCurrentVersion());
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Update()
        {
            try{
                try{
                    var source = new DirectoryInfo(sourcePath);

                    var installpather = (from f in source.GetFiles()
                                        where f.Extension == ".exe"
                                        orderby f.LastWriteTime descending
                                        select f).First();

                    File.Copy(sourcePath, installPath);
                }
                catch(Exception){
                    ExceptionHandler.setException("Exception while copying new ClientSetup");
                }

                try{
                    ProcessStartInfo info = new ProcessStartInfo(installPath);
                    Directory.SetCurrentDirectory(Path.GetDirectoryName(installPath));

                    info.UseShellExecute = true;
                    info.Verb = "runas";

                    Process process = Process.Start(info);
                    process.WaitForExit();
                }
                catch(Exception){
                    ExceptionHandler.setException("Exception while updating the ClientSetup");
                }

                try{
                    string currentVersion;
                    string expectetVersion;

                    var actual = FileVersionInfo.GetVersionInfo(installPath);
                    var source = FileVersionInfo.GetVersionInfo(sourcePath);

                    currentVersion = actual.FileVersion;
                    expectetVersion = source.FileVersion;

                    if(currentVersion != expectetVersion){
                        throw new Exception();
                    }
                }
                catch(Exception){
                    ExceptionHandler.setException("Exception while checking if the version was updated");
                }
            }
            catch(Exception e){
                ExceptionHandler.setException(e.ToString());
            }
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