namespace ActiveRecordNET.Lib.Extensions.SQLite
{
    public class SQLiteQueryBuilder : ISQLQueryBuilder
    {
        public IInsertQueryBuilder Insert(string table)
        {
            throw new System.NotImplementedException();
        }

        public ISelectQueryBuilder Select(params string[] columns)
        {
            return new SQLiteSelectQueryBuilder(columns);
        }
    }
}
