using SkriptService.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkriptService
{
    /// <summary>
    /// Klasse für das Arbeiten mit Skripten
    /// </summary>

    public class Skript
    {
        private handler m_skriptHandler;

        private List<Strings> typeList = new List<Strings>();

        

        public Skript() 
        {
            m_skriptHandler = new handler();
        }

        private void fillList(){
            typeList.Add("");
            typeList.Add("");
            typeList.Add("");
            typeList.Add("");
        }

        public void RunSkripts()
        {
            m_skriptHandler.doThings();
        }
    }
}
