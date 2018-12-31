using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileArchiver
{
    class FAException : Exception
    {
        public FAException(string message) : base(message) { }
    }
    class ControlException : Exception
    {
        public ControlException(string message) : base(message) { }
    }

}
