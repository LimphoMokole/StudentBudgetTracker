using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPRJ271
{
    internal class InvalidTransactionException:Exception
    {
        
        public InvalidTransactionException(string message) : base(message) { }
    }
}

