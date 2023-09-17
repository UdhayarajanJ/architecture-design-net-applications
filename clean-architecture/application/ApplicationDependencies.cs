using application.Interfaces;
using application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace application
{
    public static class ApplicationDependencies
    {
        public static void Configure_Application_Dependencies(this IServiceCollection services)
        {
            services.AddScoped<IComplaintTypeAsyncRepository, ComplaintTypeAsyncRepository>();
            services.AddScoped<IComplaintStatusAsyncRepository, ComplaintStatusAsyncRepository>();
            services.AddScoped<IComplaintDetailsAsyncRepository, ComplaintDetailsAsyncRepository>();
        }
    }
}
