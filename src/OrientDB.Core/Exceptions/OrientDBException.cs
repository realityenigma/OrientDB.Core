using System;

namespace OrientDB.Core.Exceptions
{
    public class OrientDBException : Exception
    {
        public OrientDBExceptionType ExceptionType { get; }

        public OrientDBException(OrientDBExceptionType type, string message) : base(message)
        {
            ExceptionType = type;
        }
    }
}
