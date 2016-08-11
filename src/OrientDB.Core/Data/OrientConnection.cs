using OrientDB.Core.Abstractions;
using System;

namespace OrientDB.Core.Data
{
    public class OrientConnection
    {
        private readonly IOrientDBRecordSerializer _serializer;
        private readonly OrientConnectionOptions _connectionOptions;
        private readonly IOrientDBLogger _logger;

        internal OrientConnection(IOrientDBRecordSerializer serializer, OrientConnectionOptions connectionOptions, IOrientDBLogger logger)
        {
            if (serializer == null)
                throw new ArgumentNullException($"{nameof(serializer)} cannot be null.");
            if (connectionOptions == null)
                throw new ArgumentNullException($"{nameof(connectionOptions)} cannot be null.");
            if (logger == null)
                throw new ArgumentNullException($"{nameof(logger)} cannot be null");
            _serializer = serializer;
            _connectionOptions = connectionOptions;
            _logger = logger;
        }
    }
}
