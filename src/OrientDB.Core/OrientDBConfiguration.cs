using OrientDB.Core.Abstractions;
using OrientDB.Core.Configuration;
using OrientDB.Core.Data;
using System;
using System.Reflection;

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
                _connectionProtocolReturnType = type;
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
            if (_connectionProtocol == null)
                throw new NullReferenceException($"{nameof(_connectionProtocol)} cannot be null.");
            if (_serializer == null)
                throw new NullReferenceException($"{nameof(_serializer)} cannot be null.");

            Type genericType = typeof(OrientConnection<>).MakeGenericType(_connectionProtocolReturnType);

            ConstructorInfo info = genericType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];

            IOrientConnection orientConnection = (IOrientConnection)info.Invoke(new object[] { _serializer, _connectionProtocol, _logger });
          
            return orientConnection;
        }
    }
}
