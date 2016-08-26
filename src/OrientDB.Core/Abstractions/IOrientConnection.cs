using OrientDB.Core.Data;
using System.Collections.Generic;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientConnection
    {
        IEnumerable<TResultType> ExecuteQuery<TResultType>(string sql);
        IOrientDBCommandResult ExecuteCommand(string sql);        
    }
}
