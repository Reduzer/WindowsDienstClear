using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    public class startSkript
    {
        private string path = "";
        private string[] skriptNames;
        private bool done;
        private int amountOfSkripts;

        public startSkript(){
            
        }

        private void getAmountOfSkripts(){
            var source = new DirectoryInfo(path);

            var myFile = (from f in source.getFiles()
                            select f)
            
            foreach(FileInfo f in myFile){
                amountOfSkripts++;
                skriptNames[amountOfSkripts] = f.name;
            }
        }

        public bool startSkripts(){
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