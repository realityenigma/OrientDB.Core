using OrientDB.Core.Abstractions;
using OrientDB.Core.Data;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace OrientDB.Core
{
    internal class OrientConnectionFactory<TDataType> : IOrientConnectionFactory
    {
        private readonly IOrientDBConnectionProtocol<TDataType> _connectionProtocol;
        private readonly IOrientDBRecordSerializer<TDataType> _serializer;
        private readonly IOrientDBLogger _logger;

        private readonly ConcurrentDictionary<int, IOrientConnection> _connectionManager = new ConcurrentDictionary<int, IOrientConnection>();

        internal OrientConnectionFactory(IOrientDBConnectionProtocol<TDataType> connectionProtocol,
            IOrientDBRecordSerializer<TDataType> serializer, IOrientDBLogger logger)
        {
            _connectionProtocol = connectionProtocol;
            _serializer = serializer;
            _logger = logger;
        }

        public IOrientConnection GetConnection()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            IOrientConnection connection;
            if (_connectionManager.ContainsKey(threadId))
            {               
                _connectionManager.TryGetValue(threadId, out connection);
                return connection;
            }

            if (_connectionProtocol == null)
                throw new NullReferenceException($"{nameof(_connectionProtocol)} cannot be null.");
            if (_serializer == null)
                throw new NullReferenceException($"{nameof(_serializer)} cannot be null.");
            if (_logger == null)
                throw new NullReferenceException($"{nameof(_logger)} cannot be null.");

            connection = new OrientConnection<TDataType>(_serializer, _connectionProtocol, _logger);
            _connectionManager.AddOrUpdate(threadId, connection, (key, conn) => _connectionManager[key] = conn);
            return connection;
        }
    }
}
