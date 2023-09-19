using Microsoft.Extensions.Configuration;
using MySqlConnector;
using repo.contracts.UtitlityContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.services.UtilityServices
{
    internal class DapperContext : IDapperContext
    {
        private readonly string connectionString;
        public DapperContext(IConfiguration configuration) => connectionString = configuration.GetConnectionString("MysqlConnection") ?? string.Empty;
        public Task<DbConnection> CreateConnection() => Task.FromResult<DbConnection>(new MySqlConnection(connectionString));
    }
}
