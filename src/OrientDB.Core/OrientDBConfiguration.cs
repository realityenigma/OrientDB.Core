using OrientDB.Core.Abstractions;
using OrientDB.Core.Configuration;
using OrientDB.Core.Data;
using System;

namespace OrientDB.Core
{
    public class OrientDBConfiguration
    {
        public OrientDBSerializationConfiguration SerializeWith { get; private set; }
        public OrientDBConnectionConfiguration ConnectWith { get; private set; }
        public OrientDBLoggingConfiguration LogWith { get; private set; }

        private IOrientDBRecordSerializer _serializer;
        private IOrientDBConnectionProtocol _connectionProtocol;
        private IOrientDBLogger _logger;

        private OrientConnection _orientConnection;

        public OrientDBConfiguration()
        {
            SerializeWith = new OrientDBSerializationConfiguration(this, (s) =>
            {
                if (s == null)
                    throw new ArgumentNullException($"{nameof(s)} cannot be null.");
                _serializer = s;
            });
            ConnectWith = new OrientDBConnectionConfiguration(this, (protocol) =>
            {
                if (protocol == null)
                    throw new ArgumentNullException($"{nameof(protocol)} cannot be null.");
                _connectionProtocol = protocol;
            });
            LogWith = new OrientDBLoggingConfiguration(this, (l) =>
            {
                if (l == null)
                    throw new ArgumentNullException($"{nameof(l)} cannot be null.");
                _logger = l;
            });
        }

        public OrientConnection CreateConnection()
        {
            OrientConnection connection = new OrientConnection(_serializer, _connectionProtocol, _logger);

            return connection;
        }
    }
}
