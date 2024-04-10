using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSetupService.src
{
    public class compareVersions
    {
        private readonly string path = "";

        private string currentVersion;
        private string newestVersion;

        public compareVersions(){
            init();
        }

        private void init(){

        }

        public bool compareVersions(){
            //true = there is a new version | false = there is no new version
            bool returnBool = false;
            
            if(currentVersion == newestVersion){
                returnBool = true;
            }

            return returnBool; 
        }

        private void getCurrentVersion(){

        }

        private void getNewestVersion(){

        }
    }
}