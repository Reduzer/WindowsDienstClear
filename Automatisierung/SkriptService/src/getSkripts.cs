using SkriptService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SkriptService.src
{
    /// <summary>
    /// Klasse zum herausfinden von Skripten
    /// </summary>
    internal class getSkripts
    {
        private string path;
        List<string> sSkriptsNames;

        public getSkripts(string path)
        {
            this.path = path;
        }

        public List<string> getSkript()
        {
            try
            {
                get();
                if (check())
                {
                    return sSkriptsNames;
                }
                else
                {
                    throw new CheckFailedException();   
                }
            }
            catch (CheckFailedException e)
            {
                return null;
            }
        }

        private void get()
        {
            
        }

        private bool check()
        {
            return false;
        }
    }
}
