using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API
{
    public class ServicesDomainException : Exception
    {
        public ServicesDomainException()
        { }

        public ServicesDomainException(string message)
            : base(message)
        { }

        public ServicesDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
