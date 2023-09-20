using repo.application.Services;

namespace repo.application.Extensions
{
    public static class HealthCheckServiceExtension
    {
        public static void ConfigureHealthCheckService(this IServiceCollection services)
        {
            services.AddHealthChecks()
                                .AddCheck<HealthCheckApplication>("ApplicationHealth", tags: new[] { "ApplicationLevel" })
                                .AddCheck<HealthCheckDatabase>("HealthCheckDatabase", tags: new[] { "DatabaseLevel" });
        }
    }
}
