using OrientDB.Core.Abstractions;
using System;
using System.Collections.Generic;

namespace OrientDB.Core.Tests.Serializers
{
    public class UnitTestDemoRecordSerializer : IOrientDBRecordSerializer<byte[]>
    {
        public IEnumerable<TResultType> Deserialize<TResultType>(byte[] data)
        {
            throw new NotImplementedException();
        }

        public byte[] Serialize<T>(T input)
        {
            throw new NotImplementedException();
        }
    }
}
