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

        private readonly string sPath = "";

        public Skript() 
        {
            m_skriptHandler = new handler(sPath);

            Init();
        }

        private void Init()
        {

        }

        public void Main()
        {

        }
    }
}
