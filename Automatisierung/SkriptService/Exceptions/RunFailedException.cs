using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkriptService.Exceptions
{
    internal class RunFailedException : Exception
    {
        public RunFailedException() : base() { }
        public RunFailedException(string message) : base(message) { }
        public RunFailedException(string message, Exception inner) : base(message, inner) { }
    }
}
