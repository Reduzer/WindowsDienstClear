using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using SkriptService.Exceptions;

namespace SkriptService.src
{
    /// <summary>
    /// Handler Klasse für Skripte
    /// </summary>
    internal class handler
    {
        private getSkripts m_getSkripts;
        private runSkripts m_runSkripts;

        private List<string> typeList = new List<string>();

        private string sPath;

        public handler(List<string> givenTypes)
        {
            foreach(string s in typeList){
                sPath = getCorrectSkripts(givenTypes[i]);
                m_getSkripts = new getSkripts(sPath);
                m_runSkripts = new runSkripts(sPath);
            }
        }

        public void doThings()
        {
            run(get());
        }

        private string getCorrectSkripts(string path){
            switch(type){
                case "":
            }
        }

        private List<string> get()
        {
            return m_getSkripts.getSkript();
        }

        private bool run(List<String> sList)
        {
            try{
                if(m_runSkripts.run(sList);){
                    
                }
                else{
                    throw new runntimeException();
                }
            }
            catch(runntimeException){

            }
            catch(Exception){
                
            }
        }
    }
}
