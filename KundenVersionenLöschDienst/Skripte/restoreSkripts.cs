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
    internal class restoreSkripts : skriptBase
    {
        public restoreSkripts()
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
