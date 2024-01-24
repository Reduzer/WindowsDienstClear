using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    public class deleteOldSetup
    {
        #region Vars & Obj

        private string oldVersion;
        private readonly string path = @"";
        private string[] fileNames;
        private int countOfFiles = 0;
        

        private bool finished = false;

        #endregion

        #region Constructors

        public deleteOldSetup(string version){
            this.oldVersion = version;
        }

        #endregion


        #region Methods

        public void runDel()
        {
            while (!finished)
            {
                if (getFiles())
                {
                    deleteSelectedFiles();
                }
            }
        }

        private bool getFiles()
        {
            try
            {
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(path);

                oldVersion = info.FileVersion;

                var source = new DirectoryInfo(path);
                var test = (from f in source.GetFiles()
                            where f.Exists
                            select f);

                foreach (FileInfo f in test)
                {
                    fileNames[countOfFiles] = f.Name;
                    countOfFiles++;
                }

                string version;
                for (int i = 0; i < countOfFiles; i++)
                {
                    
                }

                return true;
                
            }
            catch (Exception e)
            {
                ExceptionHandler.setException("Error while geting Files: " + e);
            }

            return false;
        }

        private void deleteSelectedFiles()
        {
            for (int i = 0; i < countOfFiles; i++)
            {
                
            }

            finished = true;
        }

        #endregion

    }
}