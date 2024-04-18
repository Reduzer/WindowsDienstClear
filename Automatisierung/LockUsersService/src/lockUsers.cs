using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockUsersService.src
{
    internal class lockUsers
    {
        private List<string> vs_User = new List<string>();

        public lockUsers()
        {

        }


        public void uLock(List<string> vs_User)
        {
            this.vs_User = vs_User;

            LockUsers();
        }

        private void LockUsers()
        {

        }
    }
}
