using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    internal class restoreSkripts
    {
        #region Vars & Obj

        private string path = @"";
        private string[] namesOfSkripts;

        #endregion

        #region Constructors

        public restoreSkripts()
        {

        }

        #endregion

        #region Methods

        public bool run()
        {
            if (getSkripts())
            {
                if (runSkripts())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        private bool getSkripts()
        {
            var source = new DirectoryInfo(path);

            var info = (from f in source.GetFiles(path)
                        where f.Extension == ".sql"
                        select f);

            int count = 0;

            foreach (FileInfo f in info)
            {
                namesOfSkripts[count] = f.Name;
                count++;
            }

            return true;
        }

        private bool runSkripts()
        {
            try
            {
                System.Diagnostics.Process processStart = new System.Diagnostics.Process();

                for (int i = 0; i < namesOfSkripts.Length; i++)
                {
                    processStart.StartInfo.FileName = namesOfSkripts[i];
                    processStart.StartInfo.Arguments = @"";

                    processStart.Start();

                    processStart.WaitForExit();
                }

                return true;
            }
            catch (Exception e)
            {
                ExceptionHandler.setException("Error while running skripts: " + e.ToString());
                return false;
            }
            
        }

        #endregion

    }
}
