using infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Extension
{
    public static class HealthCheckService
    {
        public static void ConfigureHealthCheckService(this IServiceCollection services)
        {
            services.AddHealthChecks()
                                .AddCheck<HealthCheckApplication>("ApplicationHealth",tags:new[] { "ApplicationLevel" })
                                .AddCheck<HealthCheckDatabase>("HealthCheckDatabase", tags: new[] { "DatabaseLevel" });
        }
    }
}
