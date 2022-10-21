using System.Collections.Generic;
using ActiveRecordNET.Lib.Common.Tests;

namespace ActiveRecordNET.Lib.Integration.Tests
{
    [AdoConfiguration(typeof(TestAdoConfigurationFactory))]
    public class TestAdoObject : AdoObject
    {
        public IEnumerable<TestUserObject> GetAll()
        {
            var queryBuilder = this.Query()
                              .SetCommand("SELECT * FROM Users");

            return this.RunEnumerable<TestUserObject>(queryBuilder);
        }

        public void Add(TestUserObject newObject)
        {
            var queryBuilder = this.Query()
                .SetCommand("INSERT INTO Users (Name, IsActive) VALUES (@name, @isActive)")
                    .AddParam((param) =>
                    {
                        param.ParameterName = "@name";
                        param.DbType = System.Data.DbType.String;
                        param.Value = newObject.Name;
                    }).AddParam((param) => {
                        param.ParameterName = "@isActive";
                        //param.DbType = System.Data.DbType.Boolean;
                        param.Value = newObject.IsActive;
                    });

            this.Run(queryBuilder);
        }
    }
}
