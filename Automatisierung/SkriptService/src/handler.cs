using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkriptService.src
{
    /// <summary>
    /// Handler Klasse für Skripte
    /// </summary>
    internal class handler
    {
        private getSkripts m_getSkripts;
        private runSkripts m_runSkripts;

        private string sPath;

        public handler(string path)
        {
            sPath = path;
            m_getSkripts = new getSkripts(sPath);
            m_runSkripts = new runSkripts(sPath);
        }

        public void doThings()
        {
            run(get());
        }

        private List<string> get()
        {
            return m_getSkripts.getSkript();
        }

        private void run(List<String> sList)
        {
            m_runSkripts.run(sList);
        }
    }
}
