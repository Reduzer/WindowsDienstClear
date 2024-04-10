using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSetupService
{
    public class ClientSetup
    {
        private compareVersions compareVersions;
        private getNewVersion getNewestVersion;

        public ClientSetup()
        {
            compareVersions = new compareVersions();
            getNewestVersion = new getNewVersion();
        }

        public void main()
        {

        }
    }
}
