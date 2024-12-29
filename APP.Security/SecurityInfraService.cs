using Microsoft.Extensions.DependencyInjection;


namespace Security.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddSecurityInfraServices(this IServiceCollection services)
        {
            //_ = services.AddScoped<BaseContext<SecurityContext>>(sp =>
            //{
            //    var contextFactory = sp.GetRequiredService<IDbContextFactory<SecurityContext>>();
            //    return contextFactory.CreateDbContext();
            //});
            _=services.AddDbContext<BaseContext<SecurityContext>>();
        }
    }
}
