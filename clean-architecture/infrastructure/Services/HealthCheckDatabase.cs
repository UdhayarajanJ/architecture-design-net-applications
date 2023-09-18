using Dapper;
using infrastructure.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Services
{
    internal class HealthCheckDatabase : IHealthCheck
    {
        private readonly IDapperContext dapperContext;
        private readonly ILogger<HealthCheckDatabase> _logger;
        public HealthCheckDatabase(IDapperContext dapperContext, ILogger<HealthCheckDatabase> _logger)
        {
            this.dapperContext = dapperContext;
            this._logger = _logger;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            int result = 0;
            try
            {
                using (IDbConnection dbConnection = dapperContext.CreateConnection())
                    result = await dbConnection.QuerySingleOrDefaultAsync<int>("select 1");
                return HealthCheckResult.Healthy("Database is healthy here");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return HealthCheckResult.Unhealthy("Database is not health check log now");
            }
        }
    }
}
