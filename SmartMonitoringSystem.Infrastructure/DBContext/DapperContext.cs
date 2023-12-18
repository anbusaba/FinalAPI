using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace SmartMonitoringSystem.Infrastructure.DBContext
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
            Console.WriteLine($"Connection String: {_connectionString}");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
