using System;
using System.Runtime.Serialization;

namespace BLL.Exceptions
{
    [Serializable]
    public class ShopProjectException : Exception
    {
        private static readonly string DefaultMessage = "Shop Project exception was thrown.";

        public ShopProjectException() : base(DefaultMessage)
        {
        }

        public ShopProjectException(string message) : base(message)
        {
        }

        public ShopProjectException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ShopProjectException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}