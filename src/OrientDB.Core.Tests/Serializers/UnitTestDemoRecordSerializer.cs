using OrientDB.Core.Abstractions;
using OrientDB.Core.Models;
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

        public IEnumerable<TResultType> Deserialize<TResultType>(byte[] data) where TResultType : OrientDBEntity
        {
            throw new NotImplementedException();
        }

        public byte[] Serialize<T>(T input) where T : OrientDBEntity
        {
            throw new NotImplementedException();
        }
    }
}
