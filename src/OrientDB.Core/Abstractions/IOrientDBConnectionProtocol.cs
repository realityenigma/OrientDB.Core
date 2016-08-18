namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBConnectionProtocol<TResult>
    {
        TResult ExecuteQuery(string sql);
        TResult ExecuteCommand(string sql);
        IOrientDBTransaction NewTransaction();
    }
}
