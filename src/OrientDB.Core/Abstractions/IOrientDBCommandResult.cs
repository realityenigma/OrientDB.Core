namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBCommandResult
    {
        int RecordsAffected { get; }
    }
}
