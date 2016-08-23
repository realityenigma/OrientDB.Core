using OrientDB.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrientDB.Core.Data
{
    public class OrientConnection<TResultType> : IOrientConnection
    {
        private readonly IOrientDBRecordSerializer _serializer;
        private readonly IOrientDBConnectionProtocol<TResultType> _connectionProtocol;
        private readonly IOrientDBLogger _logger;

        internal OrientConnection(IOrientDBRecordSerializer serializer, IOrientDBConnectionProtocol<TResultType> connectionProtocol, IOrientDBLogger logger)
        {
            if (serializer == null)
                throw new ArgumentNullException($"{nameof(serializer)} cannot be null.");
            if (connectionProtocol == null)
                throw new ArgumentNullException($"{nameof(connectionProtocol)} cannot be null.");
            if (logger == null)
                throw new ArgumentNullException($"{nameof(logger)} cannot be null.");
            _serializer = serializer;
            _connectionProtocol = connectionProtocol;
            _logger = logger;
        }

        public IEnumerable<T> ExecuteQuery<T>(string sql)
        {
            _logger.Debug($"Executing SQL Query: {sql}");
            var data = _connectionProtocol.ExecuteQuery(sql);
            return _serializer.Deserialize<T, TResultType>(data);
        }

        public OrientDBExecutionResult ExecuteCommand(string sql)
        {
            _logger.Debug($"Executing SQL Command: {sql}");
            var data = _connectionProtocol.ExecuteCommand(sql);
            return _serializer.Deserialize<OrientDBExecutionResult, TResultType>(data).First();
        }
    }
}
