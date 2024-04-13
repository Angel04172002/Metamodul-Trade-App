using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetamodulTradeApp.Core.Exceptions
{
    public class NullEntityModelException : Exception
    {
        public NullEntityModelException()
        {
            
        }

        public NullEntityModelException(string message)
            :base(message)
        {
            
        }
    }
}
