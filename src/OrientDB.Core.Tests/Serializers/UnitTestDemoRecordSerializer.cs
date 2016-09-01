using OrientDB.Core.Abstractions;
using System;
using System.Collections.Generic;

namespace OrientDB.Core.Tests.Serializers
{
    public class UnitTestDemoRecordSerializer : IOrientDBRecordSerializer<byte[]>
    {
        public OrientDBRecordFormat RecordFormat
        {
            get
            {
                return OrientDBRecordFormat.CSV;
            }
        }

        public IEnumerable<TResultType> Deserialize<TResultType>(byte[] data) where TResultType : IOrientDBEntity
        {
            throw new NotImplementedException();
        }

        public byte[] Serialize<T>(T input) where T : IOrientDBEntity
        {
            throw new NotImplementedException();
        }
    }
}
