using OrientDB.Core.Configuration;
using OrientDB.Core.Tests.Serializers;
using System;

namespace OrientDB.Core.Tests.Extensions
{
    public static class TestOrientDBRecordSerializerExtensions
    {
        public static OrientDBConfiguration TestRecordSerializer(this OrientDBSerializationConfiguration<byte[]> configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException($"{nameof(configuration)} cannot be null");
            return configuration.Serializer(new UnitTestDemoRecordSerializer());
        }
    }
}
