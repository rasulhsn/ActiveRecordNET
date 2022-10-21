using System.Collections.Generic;

namespace ActiveRecordNET.Lib.Extensions
{
    public interface ISelectQueryBuilder : IQueryBuilder
    {
        ISelectQueryBuilder Select(params string[] columns);
        ISelectQueryBuilder Select(IEnumerable<string> columns);
        IFromQueryBuilder From(string table);
    }
}
