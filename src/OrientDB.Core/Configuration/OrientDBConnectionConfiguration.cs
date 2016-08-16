using OrientDB.Core.Abstractions;
using System;

namespace OrientDB.Core.Configuration
{
    public class OrientDBConnectionConfiguration
    {
        private readonly OrientDBConfiguration _configuration;
        private readonly Action<IOrientDBConnectionProtocol, Type> _configAction;
        private readonly Action<IOrientDBRecordSerializer> _serializerAction;

        internal OrientDBConnectionConfiguration(OrientDBConfiguration configuration, Action<IOrientDBRecordSerializer> serializerAction, Action<IOrientDBConnectionProtocol, Type> configAction)
        {
            _configuration = configuration;
            _configAction = configAction;
            _serializerAction = serializerAction;
        }

        public OrientDBConnectionProtocolConfiguration Connect<TResultType>(IOrientDBConnectionProtocol protocol)
        {
            _configAction(protocol, typeof(TResultType));
            return new OrientDBConnectionProtocolConfiguration(_configuration, _serializerAction, _configAction);
        }
    }
}