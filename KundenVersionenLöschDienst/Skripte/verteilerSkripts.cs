using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    internal class verteilerSkripts : skriptBase
    {

        public verteilerSkripts()
        {
            base.path = @"";
            base.type = @".bat";
            base.done = false;
        }

        public void start()
        {
            base.getSkripts();
            base.startSkripts();
        }
    }
}
