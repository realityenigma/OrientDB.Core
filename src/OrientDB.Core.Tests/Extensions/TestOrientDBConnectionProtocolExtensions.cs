using OrientDB.Core.Configuration;
using OrientDB.Core.Tests.Connections;
using System;

namespace OrientDB.Core.Tests.Extensions
{
    public static class TestOrientDBConnectionProtocolExtensions
    {
        public static OrientDBConnectionProtocolConfiguration UnitTestConnection<ResultType>(this OrientDBConnectionConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException($"{nameof(configuration)} cannot be null");
            var connection = new UnitTestDemoConnectionProtocol();
            return configuration.Connect<ResultType>(connection);
        }
    }
}
