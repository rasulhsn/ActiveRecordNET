namespace ActiveRecordNET.Lib.Extensions
{
    public interface IInsertQueryBuilder : IQueryBuilder
    {
        IInsertQueryBuilder Value(string column, object value);
    }
}
