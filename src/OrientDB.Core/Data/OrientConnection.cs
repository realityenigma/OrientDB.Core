using OrientDB.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientDB.Core.Data
{
    public class OrientConnection
    {
        private readonly IOrientDBRecordSerializer _serializer;
        private readonly IOrientDBConnectionProtocol _connectionProtocol;
        private readonly IOrientDBLogger _logger;

        internal OrientConnection(IOrientDBRecordSerializer serializer, IOrientDBConnectionProtocol connectionProtocol, IOrientDBLogger logger)
        {
            if (serializer == null)
                throw new ArgumentNullException($"{nameof(serializer)} cannot be null.");
            if (connectionProtocol == null)
                throw new ArgumentNullException($"{nameof(connectionProtocol)} cannot be null.");
            if (logger == null)
                throw new ArgumentNullException($"{nameof(logger)} cannot be null");
            _serializer = serializer;
            _connectionProtocol = connectionProtocol;
            _logger = logger;
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql)
        {
            _logger.Debug($"Executing SQL Query: {sql}");
            var data = await Task.FromResult(_connectionProtocol.ExecuteQuery(sql));
            return await Task.FromResult(_serializer.Deserialize<T>(data));
        }

        public async Task<OrientDBExecutionResult> ExecuteCommandAsync(string sql)
        {
            _logger.Debug($"Executing SQL Command: {sql}");
            var data = await Task.FromResult(_connectionProtocol.ExecuteCommand(sql));
            return await Task.FromResult(_serializer.Deserialize<OrientDBExecutionResult>(data).First());
        }

        public IOrientDBTransaction BeginTransaction()
        {
            return _connectionProtocol.NewTransaction();
        }

        public void CreateDatabase(string databaseName)
        {
            
        }

        public bool DatabaseExists(string databaseName)
        {
            return true;
        }
    }
}
