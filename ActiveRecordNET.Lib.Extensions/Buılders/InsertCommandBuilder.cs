using System.Data;

namespace ActiveRecordNET.Lib.Extensions
{
    public class InsertCommandBuilder<T> : IDbCommandBuilder
    {
        IDbCommand IDbCommandBuilder.Build()
        {
            throw new System.NotImplementedException();
        }
    }
}
