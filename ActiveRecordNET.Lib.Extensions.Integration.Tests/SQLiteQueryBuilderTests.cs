using ActiveRecordNET.Lib.Common.Tests;
using ActiveRecordNET.Lib.Extensions.SQLite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActiveRecordNET.Lib.Extensions.Integration.Tests
{
    [TestClass]
    public class SQLiteQueryBuilderTests
    {

        [TestMethod]
        public void Sample()
        {
            string expectedQuery = $"SELECT * FROM {nameof(TestUserObject)} ";
            SQLiteQueryBuilder queryBuilder = new SQLiteQueryBuilder();

            string generatedQuery = queryBuilder.Select()
                                .From(nameof(TestUserObject))
                                .Build();

            Assert.ReferenceEquals(expectedQuery, generatedQuery);
        }

        [TestMethod]
        public void Sample2()
        {
            string expectedQuery = $"SELECT * FROM {nameof(TestUserObject)} AS T WHERE T.Name = 'Test' AND T.Id > 0 ";
            SQLiteQueryBuilder queryBuilder = new SQLiteQueryBuilder();

            string generatedQuery = queryBuilder.Select()
                                .From(nameof(TestUserObject))
                                .Alias("T")
                                .Where(nameof(TestUserObject.Name))
                                .EqualTo("Test")
                                .And(nameof(TestUserObject.Id))
                                .GreaterThan(0)
                                .Build();

            Assert.ReferenceEquals(expectedQuery, generatedQuery);
        }

        [TestMethod]
        public void Sample3()
        {
            string expectedQuery = $"SELECT T.Id, T.Name FROM {nameof(TestUserObject)} AS T WHERE T.Name = 'Test' AND T.Id > 0 ";
            SQLiteQueryBuilder queryBuilder = new SQLiteQueryBuilder();

            string generatedQuery = queryBuilder.Select("Id","Name")
                                .From(nameof(TestUserObject))
                                .Alias("T")
                                .Where(nameof(TestUserObject.Name))
                                .EqualTo("Test")
                                .And(nameof(TestUserObject.Id))
                                .GreaterThan(0)
                                .Build();

            Assert.ReferenceEquals(expectedQuery, generatedQuery);
        }

        [TestMethod]
        public void Sample4()
        {
            string expectedQuery = $"SELECT T.Id, T.Name FROM {nameof(TestUserObject)} AS T WHERE T.Name = 'Test' AND T.Id > 0 ";
            SQLiteQueryBuilder queryBuilder = new SQLiteQueryBuilder();

            string generatedQuery = queryBuilder.Insert(nameof(TestUserObject))
                                                .Value(nameof(TestUserObject.Name), "Emre")
                                                .Build();
                                

            Assert.ReferenceEquals(expectedQuery, generatedQuery);
        }
    }
}
