using System;

namespace Hardvare.Common.Exceptions
{
    public class InvalidEntityException : Exception
    {
        public InvalidEntityException(string message) : base(message)
        { }
    }
}
