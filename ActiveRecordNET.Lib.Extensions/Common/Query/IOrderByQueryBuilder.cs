namespace ActiveRecordNET.Lib.Extensions
{
    public interface IOrderByQueryBuilder : IQueryBuilder
    {
        IQueryBuilder Asc();
        IQueryBuilder Desc();
    }
}
