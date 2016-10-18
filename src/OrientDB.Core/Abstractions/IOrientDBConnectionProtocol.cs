using OrientDB.Core.Models;
using System.Collections.Generic;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBConnectionProtocol<TDataType>
    {
        IEnumerable<TResultType> ExecuteQuery<TResultType>(string sql, IOrientDBRecordSerializer<TDataType> serializer) where TResultType : OrientDBEntity;
        IOrientDBCommandResult ExecuteCommand(string sql, IOrientDBRecordSerializer<TDataType> serializer);
    }
}
