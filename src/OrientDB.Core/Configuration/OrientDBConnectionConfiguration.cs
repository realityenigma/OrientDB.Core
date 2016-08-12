using OrientDB.Core.Abstractions;
using System;

namespace OrientDB.Core.Configuration
{
    public class OrientDBConnectionConfiguration
    {
        private readonly OrientDBConfiguration _configuration;
        private readonly Action<IOrientDBConnectionProtocol> _configAction;

        internal OrientDBConnectionConfiguration(OrientDBConfiguration configuration, Action<IOrientDBConnectionProtocol> configAction)
        {
            _configuration = configuration;
            _configAction = configAction;
        }

        public OrientDBConfiguration Connect(IOrientDBConnectionProtocol protocol)
        {
            _configAction(protocol);
            return _configuration;
        }
    }
}