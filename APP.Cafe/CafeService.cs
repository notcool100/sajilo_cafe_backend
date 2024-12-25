using APP.Cafe;
using Microsoft.Extensions.DependencyInjection;
namespace Microsoft.Extensions.DependencyInjection
{
    public static class CafeService
    {
        public static IServiceCollection AddCafeServices(this IServiceCollection services)
        {
            services.AddTransient<CreateCafe>();
            //services.AddTransient<ILoginUser, LoginUser>();
            //services.AddTransient<ICreateCafe, CreateCafe>();
            //services.AddSingleton<Token>();
            return services;
        }
    }
}
