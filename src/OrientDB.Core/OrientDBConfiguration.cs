﻿using OrientDB.Core.Abstractions;
using OrientDB.Core.Configuration;
using OrientDB.Core.Data;
using System;
using System.Reflection;
using System.Linq;

namespace OrientDB.Core
{
    public class OrientDBConfiguration
    {
        public OrientDBConnectionConfiguration<TResultType> ConnectWith<TResultType>()
        {
            _connectionType = typeof(TResultType);
            return new OrientDBConnectionConfiguration<TResultType>(this, (s) =>
            {
                if (s == null)
                    throw new ArgumentNullException($"{nameof(s)} cannot be null.");
                _serializer = s;
            }, (ca) =>
            {
                if (ca == null)
                    throw new ArgumentNullException($"{nameof(ca)} cannot be null.");
                _connectionProtocol = ca;
            });
        }
        public OrientDBLoggingConfiguration LogWith { get; }

        private IOrientDBRecordSerializer _serializer;
        private object _connectionProtocol;
        private IOrientDBLogger _logger;
        private Type _connectionType;

        private IOrientConnection _orientConnection;

        public OrientDBConfiguration()
        {
            LogWith = new OrientDBLoggingConfiguration(this, (l) =>
            {
                if (l == null)
                    throw new ArgumentNullException($"{nameof(l)} cannot be null.");
                _logger = l;
            });
        }
        

        public IOrientConnectionFactory CreateFactory()
        {
            var factoryType = typeof(OrientConnectionFactory<>).MakeGenericType(_connectionType);
      
            ConstructorInfo info = factoryType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)[0];

            return (IOrientConnectionFactory)info.Invoke(new object[] { _serializer, _connectionProtocol, _logger });
        }
    }
}
