using SkriptService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkriptService.src
{
    /// <summary>
    /// Klasse zum Ausführen von Skripten
    /// </summary>

    internal class runSkripts
    {
        private string sPath;

        List<string> sFileNames = new List<string>();

        public runSkripts(string Path) 
        {
            sPath = Path;
        }

        public bool run(List<string> List)
        {
            sFileNames = List;

            try
            {
                doStuff();

                return true;
            }
            catch (RunFailedException)
            {
                return false;
            }
        }

        private void doStuff()
        {
            try
            {

            }
            catch (Exception)
            {
                throw new RunFailedException();
            }
        }
    }
}
