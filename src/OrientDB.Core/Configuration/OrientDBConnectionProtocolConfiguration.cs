using OrientDB.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientDB.Core.Configuration
{
    public class OrientDBConnectionProtocolConfiguration<TDataType>
    {
        public OrientDBSerializationConfiguration<TDataType> SerializeWith { get; }

        private readonly OrientDBConfiguration _configuration;
        private readonly Action<IOrientDBConnectionProtocol<TDataType>> _configAction;
        private readonly Action<IOrientDBRecordSerializer<TDataType>> _serializerAction;

        internal OrientDBConnectionProtocolConfiguration(OrientDBConfiguration configuration, Action<IOrientDBRecordSerializer<TDataType>> serializerAction, Action<IOrientDBConnectionProtocol<TDataType>> configAction)
        {
            _configuration = configuration;
            _configAction = configAction;
            _serializerAction = serializerAction;
            SerializeWith = new OrientDBSerializationConfiguration<TDataType>(_configuration, _serializerAction);
        }
    }
}
