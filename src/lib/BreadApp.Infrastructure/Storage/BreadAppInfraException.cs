using System;
using System.Runtime.Serialization;

namespace BreadApp.Infrastructure.Storage
{
    [Serializable]
    internal class BreadAppInfraException : Exception
    {
        public BreadAppInfraException()
        {
        }

        public BreadAppInfraException(string message) : base(message)
        {
        }

        public BreadAppInfraException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BreadAppInfraException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}