using Microsoft.Extensions.DependencyInjection;
using repo.contracts.UserContracts;
using repo.contracts.UtitlityContracts;
using repo.services.UserServices;
using repo.services.UtilityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repo.services
{
    public static class ServiceExtension
    {
        public static void ConfigureDependencies(this IServiceCollection service)
        {
            service.AddScoped<IDapperContext, DapperContext>();

            service.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
        }
    }
}
