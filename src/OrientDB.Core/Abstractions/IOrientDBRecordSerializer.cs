using System.Collections.Generic;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBRecordSerializer
    {
        IEnumerable<T> Deserialize<T, TResult>(TResult data);

        void Serialize<TResult>(TResult data);
    }
}
