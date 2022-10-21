namespace ActiveRecordNET.Lib.Extensions
{
    public interface ISQLQueryBuilder
    {
        ISelectQueryBuilder Select(params string[] columns);
        IInsertQueryBuilder Insert(string table);
    }
}
