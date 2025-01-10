

namespace Cafe.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddCafeInfraServices(this IServiceCollection services)
        {
            //services.AddScoped<BaseContext<CafeContext>>(sp =>
            //{
            //    var contextFactory = sp.GetRequiredService<IDbContextFactory<CafeContext>>();
            //    return contextFactory.CreateDbContext();
            //});
            services.AddDbContext<BaseContext<CafeContext>>();
            services.AddScoped<ICafe, CafeRepo>();
            services.AddAutoMapper(typeof(CafeMappingProfile));
        }
    }
}
