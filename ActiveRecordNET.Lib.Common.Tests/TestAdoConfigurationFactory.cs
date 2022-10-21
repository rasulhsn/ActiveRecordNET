using System.IO;

namespace ActiveRecordNET.Lib.Common.Tests
{
    public class TestAdoConfigurationFactory : AdoConfigurationFactory
    {
        const string SQL_FILE = "ARNetDb.db";

        protected override void Configure(AdoConnectionStringBuilder adoConnectionStringBuilder)
        {
            // For test -> sqllite
            string pathSqlLite = Path.Combine(PathUtils.TryGetRootPath(), "Data", SQL_FILE);

            adoConnectionStringBuilder.ConnectionString($"Data Source={pathSqlLite};Version=3;")
                   .SQLLite();
        }
    }
}
