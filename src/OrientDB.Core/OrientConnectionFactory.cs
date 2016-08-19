using OrientDB.Core.Abstractions;
using OrientDB.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OrientDB.Core
{
    internal class OrientConnectionFactory<T> : IOrientConnectionFactory
    {
        private readonly IOrientDBConnectionProtocol<T> _connectionProtocol;
        private readonly IOrientDBRecordSerializer _serializer;
        private readonly IOrientDBLogger _logger;

        internal OrientConnectionFactory(IOrientDBConnectionProtocol<T> connectionProtocol,
            IOrientDBRecordSerializer serializer, IOrientDBLogger logger)
        {
            _connectionProtocol = connectionProtocol;
            _serializer = serializer;
            _logger = logger;
        }

        public IOrientConnection GetConnection()
        {
            if (_connectionProtocol == null)
                throw new NullReferenceException($"{nameof(_connectionProtocol)} cannot be null.");
            if (_serializer == null)
                throw new NullReferenceException($"{nameof(_serializer)} cannot be null.");
            if (_logger == null)
                throw new NullReferenceException($"{nameof(_logger)} cannot be null.");

            return new OrientConnection<T>(_serializer, _connectionProtocol, _logger);
        }
    }
}
