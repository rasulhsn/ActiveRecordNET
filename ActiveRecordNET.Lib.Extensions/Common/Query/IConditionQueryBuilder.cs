namespace ActiveRecordNET.Lib.Extensions
{
    public interface IConditionQueryBuilder : IQueryBuilder
    {
        IWhereQueryBuilder And(string column);
        IWhereQueryBuilder Or(string column);
    }
}
