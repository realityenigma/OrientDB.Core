using System;

namespace OrientDB.Core.Configuration
{
    public class OrientDBConnectionConfiguration
    {
        private readonly OrientDBConfiguration _configuration;
        private readonly Action<OrientConnectionOptions> _configAction;

        internal OrientDBConnectionConfiguration(OrientDBConfiguration configuration, Action<OrientConnectionOptions> configAction)
        {
            _configuration = configuration;
            _configAction = configAction;
        }

        public OrientDBConfiguration Connect(string hostName, string userName, string password, string database, int port = 2424)
        {
            _configAction(new OrientConnectionOptions
            {
                Database = database,
                HostName = hostName,
                Password = password,
                Port = port,
                UserName = userName
            });
            return _configuration;
        }
    }
}