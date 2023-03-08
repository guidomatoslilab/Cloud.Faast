using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Faast.Integracion.Utils.Exceptions
{
    public class IntegracionException : Exception
    {
        public IntegracionException()
        { }

        public IntegracionException(string message)
            : base(message)
        { }

        public IntegracionException(string message, Exception innerException)
            : base(message, innerException)
        { }

    }
}
