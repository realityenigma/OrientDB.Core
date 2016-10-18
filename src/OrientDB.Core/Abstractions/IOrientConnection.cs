using OrientDB.Core.Data;
using OrientDB.Core.Models;
using System.Collections.Generic;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientConnection
    {
        IEnumerable<TResultType> ExecuteQuery<TResultType>(string sql) where TResultType : OrientDBEntity;
        IOrientDBCommandResult ExecuteCommand(string sql);        
    }
}
