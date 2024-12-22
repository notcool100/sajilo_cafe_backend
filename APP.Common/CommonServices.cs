using Microsoft.Extensions.DependencyInjection;

namespace App.Shared
{
    public static class CommonServiceCollection
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
