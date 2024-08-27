using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PowerplantDispatch.Persistence;
using PowerplantDispatch.Application;
using PowerplantDispatch.Application.Features.Commands.CalculateProductionPlan;

namespace PowerplantDispatch.API
{
    public static class SetupExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddApplication();
            services.AddInfrastructureServices(configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddValidatorsFromAssemblyContaining<CalculateProductionPlanCommandValidator>();

            return builder;
        }

        public static WebApplication ConfigurePipeline(this WebApplicationBuilder builder)
        {
            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
