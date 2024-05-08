using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkriptService.Exceptions{
    internal class runntimeException : Exception{
        public runntimeException(string message) : base(message) { }
        public runntimeException(string message) : base(message) { }
        public runntimeException(string message, Exception inner) : base(message, inner) { }
    }
}