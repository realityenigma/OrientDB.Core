using OrientDB.Core.Abstractions;
using System;

namespace OrientDB.Core.Configuration
{
    public class OrientDBLoggingConfiguration
    {
        private readonly OrientDBConfiguration _configuration;
        private readonly Action<IOrientDBLogger> _loggerAction;

        internal OrientDBLoggingConfiguration(OrientDBConfiguration configuration, Action<IOrientDBLogger> loggerAction)
        {
            _configuration = configuration;
            _loggerAction = loggerAction;
        }

        OrientDBConfiguration Logger(IOrientDBLogger logger)
        {
            _loggerAction(logger);
            return _configuration;
        }
    }
}