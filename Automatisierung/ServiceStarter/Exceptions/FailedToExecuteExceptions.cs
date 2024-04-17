using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStarter.Exceptions
{
    internal class FailedToExecuteExceptions : Exception
    {
        public FailedToExecuteExceptions() : base() { }
        public FailedToExecuteExceptions(string message) : base(message) { }
        public FailedToExecuteExceptions(string message, Exception inner) : base(message, inner) { }
    }
}
