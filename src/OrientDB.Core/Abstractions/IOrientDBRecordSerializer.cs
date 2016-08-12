using System.Collections.Generic;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBRecordSerializer
    {
        IEnumerable<T> Deserialize<T>(byte[] data);

        void Serialize(byte[] data);
    }
}
