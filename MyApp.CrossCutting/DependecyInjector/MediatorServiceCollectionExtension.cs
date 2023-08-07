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
            return services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
                .AddMediatR(config =>
                    {
                        config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                    });
        }
    }
}
