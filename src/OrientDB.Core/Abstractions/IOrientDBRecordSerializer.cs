using System.Collections.Generic;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBRecordSerializer<TDataType>
    {
        OrientDBRecordFormat RecordFormat { get; }

        IEnumerable<TResultType> Deserialize<TResultType>(TDataType data) where TResultType : IOrientDBEntity;

        TDataType Serialize<T>(T input) where T : IOrientDBEntity;
    }
}
