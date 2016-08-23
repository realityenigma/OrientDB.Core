using OrientDB.Core.Data;
using System.Collections.Generic;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientConnection
    {
        IEnumerable<T> ExecuteQuery<T>(string sql);
        OrientDBExecutionResult ExecuteCommand(string sql);        
    }
}
