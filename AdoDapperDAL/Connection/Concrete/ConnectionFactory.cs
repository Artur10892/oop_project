using System;
using System.Data;
using System.Data.SqlClient;
using AdoDapperDAL.Connection.Abstract;
using Microsoft.Extensions.Configuration;

namespace AdoDapperDAL.Connection.Concrete
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection GetConnection() 
        {
            return new SqlConnection(GetConnectionString());
        }
        
        public string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            
            return configuration.GetConnectionString("MSSQLConnection");
        }
    }
}
