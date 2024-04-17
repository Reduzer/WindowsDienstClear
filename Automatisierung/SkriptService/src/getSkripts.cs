using SkriptService.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
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
            var source = new DirectoryInfo(path);

            var myFiles = (from f in source.GetFiles()
                           where f.Extension == ".bat"
                           select f);

            foreach (var s in myFiles)
            {
                sSkriptsNames.Add(s.Name);
            }


            var myfiles = (from f in source.GetFiles()
                           where f.Extension == ""
                           select f);
            foreach (var s in myfiles)
            {
                sSkriptsNames.Add(s.Name);
            }
        }

        private bool check()
        {
            if (sSkriptsNames == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
