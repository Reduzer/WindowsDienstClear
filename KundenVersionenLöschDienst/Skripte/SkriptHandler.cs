using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst.Skripte
{
    internal class SkriptHandler
    {
        private backupSkripts backupSkripts = new backupSkripts();
        private restoreSkripts restoreSkripts = new restoreSkripts();
        private verteilerSkripts verteilerSkripts = new verteilerSkripts();

        public void startSkripts()
        {
            try
            {
                backupSkripts.start();
                restoreSkripts.start();
                verteilerSkripts.start();
            }
            catch (Exception e)
            {
                ExceptionHandler.setException("Exception while running the Skripts. Error: " + e.ToString());
            }
            
        }
    }
}
