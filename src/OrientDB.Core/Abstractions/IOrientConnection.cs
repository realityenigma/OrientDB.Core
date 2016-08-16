using OrientDB.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientConnection
    {
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql);

        Task<OrientDBExecutionResult> ExecuteCommandAsync(string sql);

        IOrientDBTransaction BeginTransaction();

        void CreateDatabase(string databaseName);

        bool DatabaseExists(string databaseName);
    }
}
