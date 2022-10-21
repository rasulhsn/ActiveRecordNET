using System.Data;

namespace ActiveRecordNET.Lib.Extensions
{
    public class DeleteCommandBuilder<T> : IDbCommandBuilder
    {
        IDbCommand IDbCommandBuilder.Build()
        {
            throw new System.NotImplementedException();
        }
    }
}
