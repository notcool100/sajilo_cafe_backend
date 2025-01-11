using Cafe.Infrastructure.Data.Configurations;
using System.Reflection;

namespace Cafe.Infrastructure.Data
{
    internal static class CafeSchema
    {
        public static string Name = "cafe";
    }
    public partial class CafeContext : BaseContext<CafeContext>, IAggregateRoot
    {
        public CafeContext(DbContextOptions<BaseContext<CafeContext>> options,IConfiguration configuration) : base(options,configuration)
        {
        }
        public DbSet<CafeM> Cafes => Set<CafeM>();

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(CafeSchema.Name);
            base.OnModelCreating(modelBuilder);
        }

    }

}
