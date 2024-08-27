using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PowerplantDispatch.Application.Contracts;
using PowerplantDispatch.Application.Features.Commands.CalculateProductionPlan;
using PowerplantDispatch.Application.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(typeof(CalculateProductionPlanCommandHandler).Assembly);
            //services.AddMediatR(typeof(GetProductionPlanQueryHandler).Assembly);
            //services.AddTransient<IProductionPlanService, ProductionPlanService>(); // Assuming you will implement this in the Infrastructure layer or elsewhere

            return services;
        }
    }
}
