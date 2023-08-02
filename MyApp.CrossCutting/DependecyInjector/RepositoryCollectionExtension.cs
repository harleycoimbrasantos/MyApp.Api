using Microsoft.Extensions.DependencyInjection;
using MyApp.Data.Interface;
using MyApp.Data.Repository;

namespace MyApp.CrossCutting.DependecyInjector
{
    public static class RepositoryCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerMovementRepository, CustomerMovementRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();

            return services;
        }
    }
}