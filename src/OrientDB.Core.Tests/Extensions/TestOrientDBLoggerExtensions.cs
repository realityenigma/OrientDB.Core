using OrientDB.Core.Configuration;
using OrientDB.Core.Tests.Loggers;

namespace OrientDB.Core.Tests.Extensions
{
    public static class TestOrientDBLoggerExtensions
    {
        public static OrientDBConfiguration DemoLogger(this OrientDBLoggingConfiguration configuration)
        {
            return configuration.Logger(new UnitTestDemoLogger());
        }
    }
}
