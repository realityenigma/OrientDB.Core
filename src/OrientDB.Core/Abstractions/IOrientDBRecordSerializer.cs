using System.Collections.Generic;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBRecordSerializer<TDataType>
    {
        IEnumerable<TResultType> Deserialize<TResultType>(TDataType data);

        TDataType Serialize<T>(T input);
    }
}
