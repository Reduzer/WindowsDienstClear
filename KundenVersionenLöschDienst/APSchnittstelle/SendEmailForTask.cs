using System;
using System.Collenctions.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using Outlook = Microsoft.Office.Interop.Outlook;

namespace KundenVersionenLöschDienst {
    public class SendEmailForTask {

        Outlook.Application outlook = new Outlook.Application();
        
        
        private string[] reciever;
        private string subject;
        private string[] message;

        public SendEmailForTask(){

        }

        private void getReciever(){
            
        }

        public void setMessage(){

        }

        public void sendMailToDev(){
        
        }

    }
}