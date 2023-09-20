using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace repo.application.Middlewares
{
    public static class HealthMiddleware
    {
        public static IEndpointRouteBuilder ConfigureHealthMiddleWare(this IEndpointRouteBuilder app)
        {
            app.MapHealthChecks("/healthchecks", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            return app;

        }
    }
}
