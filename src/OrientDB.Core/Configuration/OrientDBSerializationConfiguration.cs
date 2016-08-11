using OrientDB.Core.Abstractions;
using System;

namespace OrientDB.Core.Configuration
{
    public class OrientDBSerializationConfiguration
    {
        private readonly OrientDBConfiguration _configuration;
        private readonly Action<IOrientDBRecordSerializer> _addSerializer;

        internal OrientDBSerializationConfiguration(OrientDBConfiguration configuration, Action<IOrientDBRecordSerializer> addSerializer)
        {
            if (configuration == null)
                throw new ArgumentNullException($"{nameof(configuration)} cannot be null.");
            _configuration = configuration;
            _addSerializer = addSerializer;
        }

        public OrientDBConfiguration Serializer(IOrientDBRecordSerializer serializer)
        {
            if (serializer == null)
                throw new ArgumentNullException($"{nameof(serializer)} cannot be null.");
            _addSerializer(serializer);
            return _configuration;
        }
    }
}