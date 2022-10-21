using System.Collections.Generic;

namespace ActiveRecordNET.Lib
{
    public abstract class AdoObject
    {
        protected IEnumerable<T> RunEnumerable<T>(IDbCommandBuilder commandBuilder) where T : new()
        {
            var dbCommand = commandBuilder.Build();
            
            var result = AdoCommandExecuter.Reader<T>(dbCommand);
            
            if (!result.IsSuccess)
            {
                throw new AdoObjectProxyException("Occur error!", result.Errors);
            }

            return result.Object;
        }

        protected T Run<T>(IDbCommandBuilder commandBuilder) where T : new()
        {      
            var dbCommand = commandBuilder.Build();

            var result = AdoCommandExecuter.Scalar(dbCommand);

            if (!result.IsSuccess)
            {
                throw new AdoObjectProxyException("Occur error!", result.Errors);
            }

            return (T)result.Object;
        }

        protected void Run(IDbCommandBuilder commandBuilder)
        {
            var dbCommand = commandBuilder.Build();

            var result = AdoCommandExecuter.Query(dbCommand);

            if (!result.IsSuccess)
            {
                throw new AdoObjectProxyException("Occur error!", result.Errors);
            }
        }

        protected AdoCommandBuilder Query()
        {
            var factory = AdoConfigurationResolver.GetConfigurationFactory(this.GetType());
            var adoConnectionString = factory.CreateConnectionString();

            var commandBuilder = new AdoCommandBuilder(adoConnectionString);

            return commandBuilder;
        }
    }
}
