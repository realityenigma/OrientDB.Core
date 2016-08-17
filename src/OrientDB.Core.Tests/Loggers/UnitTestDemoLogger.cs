using OrientDB.Core.Abstractions;
using System;

namespace OrientDB.Core.Tests.Loggers
{
    public class UnitTestDemoLogger : IOrientDBLogger
    {
        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message)
        {
            throw new NotImplementedException();
        }

        public void Information(string message)
        {
            throw new NotImplementedException();
        }

        public void Verbose(string message)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
