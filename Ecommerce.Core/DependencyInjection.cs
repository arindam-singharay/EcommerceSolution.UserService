using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the infrastructure services to the specified   .
        /// </summary>
        /// <param name="services">The IServiceCollection to add the services to.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // Register core services here
            // Example: services.AddScoped<IMyService, MyService>();
            return services;
        }
    }
}
