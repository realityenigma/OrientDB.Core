using OrientDB.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientDB.Core.Tests.Connections
{
    public class UnitTestDemoConnectionProtocol : IOrientDBConnectionProtocol
    {
        public TResult ExecuteCommand<TResult>(string sql)
        {
            throw new NotImplementedException();
        }

        public TResult ExecuteQuery<TResult>(string sql)
        {
            throw new NotImplementedException();
        }

        public IOrientDBTransaction NewTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
