using OrientDB.Core.Abstractions;
using OrientDB.Core.Configuration;
using OrientDB.Core.Data;
using System;

namespace OrientDB.Core
{
    public class OrientDBConfiguration
    {
        public OrientDBConnectionConfiguration ConnectWith { get; }
        public OrientDBLoggingConfiguration LogWith { get; }

        private IOrientDBRecordSerializer _serializer;
        private IOrientDBConnectionProtocol _connectionProtocol;
        private Type _connectionProtocolReturnType;
        private IOrientDBLogger _logger;

        private IOrientConnection _orientConnection;

        public OrientDBConfiguration()
        {
            ConnectWith = new OrientDBConnectionConfiguration(this, (s) =>
            {
                if (s == null)
                    throw new ArgumentNullException($"{nameof(s)} cannot be null.");
                _serializer = s;
            },
            (protocol, type) =>
            {
                if (protocol == null)
                    throw new ArgumentNullException($"{nameof(protocol)} cannot be null.");
                if (type == null)
                    throw new ArgumentNullException($"{nameof(type)} cannot be null.");
                _connectionProtocol = protocol;
            });
            LogWith = new OrientDBLoggingConfiguration(this, (l) =>
            {
                if (l == null)
                    throw new ArgumentNullException($"{nameof(l)} cannot be null.");
                _logger = l;
            });
        }

        public IOrientConnection CreateConnection()
        {
            Type genericType = typeof(OrientConnection<>).MakeGenericType(_connectionProtocolReturnType);

            IOrientConnection orientConnection = (IOrientConnection)Activator.CreateInstance(genericType, new object[] { _serializer, _connectionProtocol, _logger });

            return orientConnection;
        }
    }
}
