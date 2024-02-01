using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    public abstract class skriptBase
    {
        #region Vars & Obj

        protected string path;
        protected string[] nameOfSkripts;
        protected string type;
        protected bool done;
        protected short amountOfSkripts;

        #endregion

        #region Methods

        protected void getSkripts()
        {
            var source = new DirectoryInfo(path);

            var myFile = (from f in source.GetFiles()
                          where f.Extension == type
                          select f);

            foreach (FileInfo f in myFile)
            {
                amountOfSkripts++;
                nameOfSkripts[amountOfSkripts] = f.Name;
            }
        }


        protected void startSkripts()
        {
            System.Diagnostics.Process processToStart = new System.Diagnostics.Process();

            for (int i = 0; i < amountOfSkripts; i++)
            {
                processToStart.StartInfo.FileName = nameOfSkripts[i];
                processToStart.StartInfo.Arguments = @"";
                processToStart.Start();
            }

            amountOfSkripts = 0;
        }

        #endregion
    }
}
