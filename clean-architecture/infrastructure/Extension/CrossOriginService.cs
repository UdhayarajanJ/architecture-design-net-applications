using Microsoft.Extensions.Logging;
using Serilog.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace infrastructure.Extension
{
    public static class CrossOriginService
    {
        public static void ConfigureCorsService(this IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("Cors-Policy", 
                                                           policy => policy.AllowAnyOrigin()
                                                                           .AllowAnyMethod()
                                                                           .AllowAnyHeader()));
        }
    }
}
