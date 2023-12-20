using System;
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

        private string fileName;
        private string[] filesToDelete;

        private string path = @"";

        private double creationDate;

        #endregion

        #region Constructors

        public DeleteFiles()
        {

        }

        #endregion

        #region Methods

        public int countFiles()
        {
            if (true /* Wenn Datein vorhanden sind */)
            {
                //Get File amount

                return fileCount;
            }
            else
            {
                return 0;
            }
            
        }

        public int countFilesToDelete()
        {
            for (int i = 0; i < fileCount; i++)
            {
                if (true /*File Creation Date > 30 days*/)
                {
                    actualFileCount++;
                    //fileName -> filesToDelete[]
                }
            }

            return actualFileCount;
        }

        public bool deleteFiles()
        {
            foreach (string file in filesToDelete)
            {
                //Delete File, where fileName -> filesToDelete[]
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
