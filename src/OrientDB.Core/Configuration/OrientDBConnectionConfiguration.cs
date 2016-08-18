using OrientDB.Core.Abstractions;
using System;

namespace OrientDB.Core.Configuration
{
    public class OrientDBConnectionConfiguration<TResultType>
    {
        private readonly OrientDBConfiguration _configuration;
        private readonly Action<IOrientDBConnectionProtocol<TResultType>> _configAction;
        private readonly Action<IOrientDBRecordSerializer> _serializerAction;

        internal OrientDBConnectionConfiguration(OrientDBConfiguration configuration, Action<IOrientDBRecordSerializer> serializerAction, Action<IOrientDBConnectionProtocol<TResultType>> configAction)
        {
            _configuration = configuration;
            _configAction = configAction;
            _serializerAction = serializerAction;
        }

        public OrientDBConnectionProtocolConfiguration<TResultType> Connect(IOrientDBConnectionProtocol<TResultType> protocol)
        {
            _configAction(protocol);
            return new OrientDBConnectionProtocolConfiguration<TResultType>(_configuration, _serializerAction, _configAction);
        }
    }
}