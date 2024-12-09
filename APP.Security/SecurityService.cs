using Microsoft.Extensions.DependencyInjection;

using APP.Security;
using APP.Security.Repo.Implimantation;
using APP.Security.Repo.Interface;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DashboardServiceCollection
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.AddTransient<ILoginUser, LoginUser>();
            services.AddTransient<ICreateCafe, CreateCafe>();
            services.AddSingleton<Token>();
            return services;
        }

    }
}
