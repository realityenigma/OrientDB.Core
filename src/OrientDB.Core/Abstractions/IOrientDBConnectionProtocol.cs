namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBConnectionProtocol
    {
        byte[] ExecuteQuery(string sql);
        byte[] ExecuteCommand(string sql);
        IOrientDBTransaction NewTransaction();
    }
}
