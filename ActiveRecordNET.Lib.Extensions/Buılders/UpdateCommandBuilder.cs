using System.Data;

namespace ActiveRecordNET.Lib.Extensions
{
    public class UpdateCommandBuilder<T> : IDbCommandBuilder
    {
        IDbCommand IDbCommandBuilder.Build()
        {
            throw new System.NotImplementedException();
        }
    }
}
