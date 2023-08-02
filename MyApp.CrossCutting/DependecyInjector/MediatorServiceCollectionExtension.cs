using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.CrossCutting.DependecyInjector
{
    public static class MediatorServiceCollectionExtension
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("MyApp.Application");
            services.AddMediatR(assembly);
            return services;
        }
    }
}