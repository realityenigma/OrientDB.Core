using OrientDB.Core.Abstractions;
using System;

namespace OrientDB.Core.Data
{
    public class OrientConnection
    {
        private readonly IOrientDBRecordSerializer _serializer;
        private readonly OrientConnectionOptions _connectionOptions;

        internal OrientConnection(IOrientDBRecordSerializer serializer, OrientConnectionOptions connectionOptions)
        {
            if (serializer == null)
                throw new ArgumentNullException($"{nameof(serializer)} cannot be null.");
            if (connectionOptions == null)
                throw new ArgumentNullException($"{nameof(connectionOptions)} cannot be null.");
            _serializer = serializer;
            _connectionOptions = connectionOptions;
        }
    }
}
