using Microsoft.Extensions.DependencyInjection;

namespace App.Security
{
    public static class DashboardServiceCollection
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            _=services.AddTransient<ILoginUser, LoginUser>();
            _=services.AddTransient<ICreateCafe, CreateCafe>();
            _=services.AddSingleton<Token>();
            return services;
        }

    }
}
