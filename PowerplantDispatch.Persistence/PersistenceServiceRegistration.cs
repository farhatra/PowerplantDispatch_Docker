using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerplantDispatch.Application.Contracts;
using PowerplantDispatch.Persistence.Repositories;

namespace PowerplantDispatch.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.AddTransient<IProductionPlanService, ProductionPlanService>();

            return services;
        }
    }
}
