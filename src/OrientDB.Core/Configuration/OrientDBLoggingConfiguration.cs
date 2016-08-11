namespace OrientDB.Core.Configuration
{
    public class OrientDBLoggingConfiguration
    {
        private readonly OrientDBConfiguration _configuration;

        internal OrientDBLoggingConfiguration(OrientDBConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}