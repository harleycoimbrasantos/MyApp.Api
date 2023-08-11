using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;
using MyApp.ReportService.Interfaces;
using MyApp.ReportService.Services;
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
            services.AddScoped<IPdfService, PdfService>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            return services;
        }
    }
}