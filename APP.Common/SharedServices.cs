

namespace App.Shared
{
    public static class DependencyInjection
    {
        public static void AddSharedServices(this IServiceCollection services)
        {
            _ = services.AddValidatorsFromAssembly(Assembly.GetCallingAssembly());
            _ = services.AddAutoMapper(Assembly.GetCallingAssembly());

        }
    }
}
