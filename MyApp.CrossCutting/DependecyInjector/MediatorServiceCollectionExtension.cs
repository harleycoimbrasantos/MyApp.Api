using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyApp.CrossCutting.PipelineBehavior;
using System.Reflection;

namespace MyApp.CrossCutting.DependecyInjector
{
    public static class MediatorServiceCollectionExtension
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Application.Context).Assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            return services;
        }
    }
}
