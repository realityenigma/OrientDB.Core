using OrientDB.Core.Abstractions;
using System;

namespace OrientDB.Core.Configuration
{
    public class OrientDBConnectionConfiguration<TDataType>
    {
        private readonly OrientDBConfiguration _configuration;
        private readonly Action<IOrientDBConnectionProtocol<TDataType>> _configAction;
        private readonly Action<IOrientDBRecordSerializer<TDataType>> _serializerAction;

        internal OrientDBConnectionConfiguration(OrientDBConfiguration configuration, Action<IOrientDBRecordSerializer<TDataType>> serializerAction, Action<IOrientDBConnectionProtocol<TDataType>> configAction)
        {
            _configuration = configuration;
            _configAction = configAction;
            _serializerAction = serializerAction;
        }

        public OrientDBConnectionProtocolConfiguration<TDataType> Connect(IOrientDBConnectionProtocol<TDataType> protocol)
        {
            _configAction(protocol);
            return new OrientDBConnectionProtocolConfiguration<TDataType>(_configuration, _serializerAction, _configAction);
        }
    }
}