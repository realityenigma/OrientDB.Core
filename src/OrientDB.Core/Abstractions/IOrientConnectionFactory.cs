namespace OrientDB.Core.Abstractions
{
    public interface IOrientConnectionFactory
    {
        IOrientConnection GetConnection();
    }
}
