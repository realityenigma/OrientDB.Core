using OrientDB.Core.Abstractions;
using System;
using System.Collections.Generic;

namespace OrientDB.Core.Tests.Serializers
{
    public class UnitTestDemoRecordSerializer : IOrientDBRecordSerializer
    {
        public IEnumerable<T> Deserialize<T, TResult>(TResult data)
        {
            throw new NotImplementedException();
        }

        public void Serialize<TResult>(TResult data)
        {
            throw new NotImplementedException();
        }
    }
}
