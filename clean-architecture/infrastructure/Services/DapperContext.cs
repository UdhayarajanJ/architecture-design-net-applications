using infrastructure.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Services
{
    public class DapperContext : IDapperContext
    {
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("Sqlserver") ?? string.Empty;

        public IDbConnection CreateConnection()
        { 
            if(string.IsNullOrEmpty(_connectionString))
                throw new ArgumentNullException(nameof(_connectionString));

            return new SqlConnection(_connectionString);
        }

        ~DapperContext() { }
    }
}
