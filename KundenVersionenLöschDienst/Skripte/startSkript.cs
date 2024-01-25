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
    public class startSkript
    {
        private string path = "";
        private string[] skriptNames;
        private bool done;
        private int amountOfSkripts = 0;

        public startSkript(){
            
        }

        private void getAmountOfSkripts()
        {
            var source = new DirectoryInfo(path);

            var myFile = (from f in source.GetFiles()
                          where f.Extension == ".bat"
                          select f);
            
            foreach(FileInfo f in myFile){
                amountOfSkripts++;
                skriptNames[amountOfSkripts] = f.Name;
            }
        }

        public void startSkripts(){
            getAmountOfSkripts();

            System.Diagnostics.Process processToStart = new System.Diagnostics.Process();

            for(int i = 0; i < amountOfSkripts; i++){
                processToStart.StartInfo.FileName = skriptNames[i];
                processToStart.StartInfo.Arguments = @"";
                processToStart.Start();
            }

            amountOfSkripts = 0;
        }
    }
}