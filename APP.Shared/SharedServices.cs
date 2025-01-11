

using Microsoft.EntityFrameworkCore;

namespace App.Shared
{
    public static class DependencyInjection
    {
        public static void AddSharedServices(this IServiceCollection services)
        {
            foreach (var type in typeof(BaseContext<>).Assembly.DefinedTypes
            .Where(t => !t.IsAbstract
                        && !t.IsGenericTypeDefinition
                        && typeof(IEntityTypeConfiguration<>).IsAssignableFrom(t)))
            {
                services.AddSingleton(typeof(IEntityTypeConfiguration<>), type);
            }
            _ =services.AddTransient(typeof(IBaseInterface<,>), typeof(IBaseRepo<,>));
            _ = services.AddValidatorsFromAssembly(Assembly.GetCallingAssembly());
            _ = services.AddAutoMapper(Assembly.GetCallingAssembly());
            
        }
    }
}
