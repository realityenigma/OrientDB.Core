using OrientDB.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientDB.Core.Configuration
{
    public class OrientDBConnectionProtocolConfiguration
    {

        public OrientDBSerializationConfiguration SerializeWith { get; }

        private readonly OrientDBConfiguration _configuration;
        private readonly Action<IOrientDBConnectionProtocol, Type> _configAction;
        private readonly Action<IOrientDBRecordSerializer> _serializerAction;

        internal OrientDBConnectionProtocolConfiguration(OrientDBConfiguration configuration, Action<IOrientDBRecordSerializer> serializerAction, Action<IOrientDBConnectionProtocol, Type> configAction)
        {
            _configuration = configuration;
            _configAction = configAction;
            _serializerAction = serializerAction;
            SerializeWith = new OrientDBSerializationConfiguration(_configuration, _serializerAction);
        }
    }
}
