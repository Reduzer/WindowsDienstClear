using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    public class backupSkripts : skriptBase
    {
        public backupSkripts() 
        {
            base.path = @"";
            base.type = @".sql";
            base.done = false;
        }

        public void start()
        {
            base.getSkripts();
            base.startSkripts();
        }
    }
}
