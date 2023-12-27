using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    internal  class DeleteFiles
    {
        #region Vars

        private int fileCount;
        private int actualFileCount = 0;

        private string[] allFileNames;
        private string[] filesToDelete;

        private string path = @"";


        #endregion

        #region Constructors

        public DeleteFiles()
        {

        }

        #endregion

        #region Methods

        public int countFiles()
        {
            if (Directory.GetDirectories(path) != null)
            {
                fileCount = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly).Length;

                return fileCount;
            }
            else
            {
                return 0;
            }
            
        }

        public int countFilesToDelete()
        {
            allFileNames = Directory.GetDirectories(path);

            for (int i = 0; i < fileCount; i++)
            {
                if (Directory.GetCreationTime(allFileNames[i]).Month < DateTime.Today.Month)
                {
                    if (Directory.GetCreationTime(allFileNames[i]).Day < DateTime.Today.Day)
                    {
                        actualFileCount++;
                        filesToDelete[i] = allFileNames[i];
                    }
                }
            }

            return actualFileCount;
        }

        public bool deleteFiles()
        {
            for(int i = 0; i < actualFileCount; i++) 
            {
                Directory.Delete(filesToDelete[i]);
                actualFileCount--;
            }

            if (actualFileCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
