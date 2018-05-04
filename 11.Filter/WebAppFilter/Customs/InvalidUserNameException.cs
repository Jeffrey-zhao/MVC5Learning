using System;
using System.Runtime.Serialization;

namespace WebAppFilter.Customs
{
    [Serializable]
    internal class InvalidUserNameException : Exception
    {
        public InvalidUserNameException()
        {
        }

        public InvalidUserNameException(string message) : base(message)
        {
        }

        public InvalidUserNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidUserNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}