namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBConnectionProtocol
    {
        TResult ExecuteQuery<TResult>(string sql);
        TResult ExecuteCommand<TResult>(string sql);
        IOrientDBTransaction NewTransaction();
    }
}
