using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiveRecordNET.Lib.Extensions.SQLite
{
    public class SQLiteInsertQueryBuilder : IInsertQueryBuilder
    {
        const string INSERT = "INSERT INTO";

        private readonly string _tableName;
        private readonly Dictionary<string, List<object>> _values;

        public SQLiteInsertQueryBuilder(string table)
        {
            _tableName = table ?? throw new ArgumentNullException(nameof(table));
            _values = new Dictionary<string, List<object>>();
        }
        
        public IInsertQueryBuilder Value(string column, object value)
        {
            if (_values.ContainsKey(column))
            {
                var list = _values[column];
                list.Add(value);
            }
            else
            {
                _values.Add(column, new List<object>() { value });
            }

            return this;
        }

        public string Build()
        {
            StringBuilder builder = new StringBuilder();

            var grouppedColumns = _values.Keys.GroupBy(x => x)
                .Select(x => x.Key);

            builder.Append($"{INSERT} {_tableName} ");

            foreach (var column in grouppedColumns)
            

            return builder.ToString();
        }
    }
}
