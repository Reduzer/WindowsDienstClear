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
    internal class updater
    {
        #region Vars & Obj

        sql sql = new sql();

        readonly string dirPath = "";
        readonly string insPath = "";
        readonly string updPath = "";
        readonly string updInstaller;

        #endregion

        #region Constructors

        public updater()
        {
            updInstaller = insPath + "APInstaller.exe";
        }

        #endregion

        #region Methods

        public void check()
        {
            if (getCurrentFileVersion() == getNextFileVersion())
            {
                return;
            }
            else
            {
                move(dirPath, updPath);

                update(updInstaller);
            }
        }

        private void move(string directorypath, string installerpath)
        {
            var source = new DirectoryInfo(directorypath);

            var myFile = (from f in source.GetFiles()
                          where f.Extension == ".exe"
                          orderby f.LastWriteTime descending
                          select f).First();

            File.Copy(directorypath, installerpath);
        }

        private void update(string updateInstaller)
        {
            ProcessStartInfo info = new ProcessStartInfo(updateInstaller);
            Directory.SetCurrentDirectory(Path.GetDirectoryName(updateInstaller));

            info.UseShellExecute = true;
            info.Verb = "runas";

            Process process = Process.Start(info);

            process.WaitForExit();
        }

        private void delete(string installerpath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(installerpath);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();
            }
        }

        private string getCurrentFileVersion()
        {
            string currentVersion;

            var source = FileVersionInfo.GetVersionInfo(insPath);

            currentVersion = source.FileVersion;

            return currentVersion;
        }

        private string getNextFileVersion()
        {
            return null;
        }

        #endregion
    }
}
