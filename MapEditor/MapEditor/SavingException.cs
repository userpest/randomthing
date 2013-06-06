using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    class SavingException : Exception
    {
        public SavingException(string message)
            : base(message)
        {
        }
    }
}
