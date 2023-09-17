using infrastructure.Contracts;
using infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Extension
{
    public static class InfrastructureDependencies
    {
        public static void Configure_Infrastructure_Dependencies(this IServiceCollection services)
        {
            services.AddScoped<ISMSService, SMSService>();
            services.AddSingleton<IJWTService, JWTTokenService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IDapperContext, DapperContext>();
        }
    }
}
