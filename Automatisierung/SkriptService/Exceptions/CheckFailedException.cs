using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkriptService.Exceptions
{
    public class CheckFailedException : Exception
    {
        public CheckFailedException() : base() { }
        public CheckFailedException(string message) : base(message) { }
        public CheckFailedException(string message, Exception inner) : base(message, inner) { }

    }
}
