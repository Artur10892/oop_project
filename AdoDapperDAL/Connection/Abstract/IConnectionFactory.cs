using System.Data;

namespace AdoDapperDAL.Connection.Abstract
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();

        string GetConnectionString();
    }
}
