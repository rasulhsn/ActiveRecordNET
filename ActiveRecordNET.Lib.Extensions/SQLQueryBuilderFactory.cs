using System;
using ActiveRecordNET.Lib.Extensions.SQLite;

namespace ActiveRecordNET.Lib.Extensions
{
    public static class SQLQueryBuilderFactory
    {
        public static ISQLQueryBuilder Create(string providerName)
        {
            switch (providerName)
            {
                case "System.Data.SQLite":
                    return new SQLiteQueryBuilder();
                default:
                    throw new Exception();
            }
        }
    }
}
