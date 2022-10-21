namespace ActiveRecordNET.Lib.Extensions
{
    public interface IFromQueryBuilder : IQueryBuilder
    {
        IFromQueryBuilder Alias(string alias);
        IWhereQueryBuilder Where(string column);
        IOrderByQueryBuilder OrderBy(string column);
    }
}
