using Microsoft.Extensions.DependencyInjection;
using MyApp.Services.Interfaces;
using MyApp.Services.Service;

namespace MyApp.CrossCutting.DependecyInjector
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFileManagementService, FileManagementService>();
            services.AddScoped<ICustomerMovementService, CustomerMovementService>();

            return services;
        }
    }
}