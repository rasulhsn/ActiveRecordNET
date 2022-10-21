# ActiveRecordNET
The main purpose of this library represents the RD table as an object via the Active-Record pattern.

- Relation between objects is not supported.
- Complex type completely not supported.
- Property array is not supported.

Note: if you want to overcome the SRP problem, you can apply some design principles.

```csharp
public class DefaultConfigurationFactory : AdoConfigurationFactory
{
		protected override void Configure(AdoConnectionStringBuilder adoConnectionStringBuilder)
        {
			// Sample connection string.
			string connStr = "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;";			
            adoConnectionStringBuilder.ConnectionString(connStr).MSSQL();
        }
}

[AdoConfiguration(typeof(DefaultConfigurationFactory))]
public class User : AdoObject
{	    
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<User> GetAll()
        {
            // Declarative approach
            var selectQuery = this.Query()
                                   .Select("Users");

            return this.RunEnumerable<User>(selectQuery);
        }

        public void Add(User newObject)
        {
            // Declarative approach
            var insertQuery = this.Query().Insert("Users", newObject);

            insertQuery.Column(nameof(User.Name)).Only();
            insertQuery.Column(nameof(User.IsActive)).Only();

            this.Run(insertQuery);
        }

        public void Update(User newObject)
        {
            // Declarative approach
            var updateQuery = this.Query().Update("Users", newObject);

            updateQuery.Column(nameof(User.Id)).EqualTo(newObject.Id);
            updateQuery.Column(nameof(User.Name)).Only();
            updateQuery.Column(nameof(User.IsActive)).Only();

            this.Run(updateQuery);
        }

        public void Delete(long id)
        {
            // Declarative approach
            var deleteQuery = this.Query().Delete<User>("Users");

            deleteQuery.Column(nameof(User.Id)).EqualTo(id);

            this.Run(deleteQuery);
        }
}

```
