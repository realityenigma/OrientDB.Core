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
        private OrientConnectionOptions _connectionOptions;
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
            ConnectWith = new OrientDBConnectionConfiguration(this, (o) =>
            {
                if (o == null)
                    throw new ArgumentNullException($"{nameof(o)} cannot be null.");
                _connectionOptions = o;
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
            OrientConnection connection = new OrientConnection(_serializer, _connectionOptions, _logger);

            return connection;
        }
    }
}
