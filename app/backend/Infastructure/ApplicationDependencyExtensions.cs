using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace backend.Infastructure
{
    public static class ApplicationDependencyExtensions
    {
        // Register the MediatR
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assemblyList = new[]
            {
                typeof(BaseCqrsRequest<>).Assembly,
                Assembly.GetExecutingAssembly()
            };

            services.AddMediatR(assemblyList);


            return services;
        }
    }
}
