
namespace App.Migrations
{
    public static class DependencyInjection
    {
        public static void AddMigrationInfraServices(this IServiceCollection services)
        {
            services.AddDbContext<BaseContext<CafeDbContext>>();
        }
    }
}

