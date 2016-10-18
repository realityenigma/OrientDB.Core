using OrientDB.Core.Models;
using System.Collections.Generic;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBRecordSerializer<TDataType>
    {
        OrientDBRecordFormat RecordFormat { get; }

        IEnumerable<TResultType> Deserialize<TResultType>(TDataType data) where TResultType : OrientDBEntity;

        TDataType Serialize<T>(T input) where T : OrientDBEntity;
    }
}
