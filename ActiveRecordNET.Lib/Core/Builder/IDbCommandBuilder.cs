using System.Data;

namespace ActiveRecordNET.Lib
{
    public interface IDbCommandBuilder
    {
        public IDbCommand Build();
    }
}
