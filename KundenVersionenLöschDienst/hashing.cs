using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KundenVersionenLöschDienst
{
    internal class hashing
    {
        #region Objects
        
        SHA512 sha512 = SHA512.Create();
        
        #endregion

        #region Vars

        private string message;
        private string salt;
        private string hash;

        private byte[] data;

        #endregion

        #region Methods

        public bool setMessage(string message)
        {
            this.message = message;

            return true;
        }

        public int generateHash()
        { 

            return 0;
        }

        #endregion
    }
}
