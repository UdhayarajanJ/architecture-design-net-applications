using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Middleware
{
    public static class HealthCheckMiddleware
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
/*
 app.MapHealthChecks("/health/cors", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
}).RequireCors("MyCorsPolicy");
 */