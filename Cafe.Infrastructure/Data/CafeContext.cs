

namespace Cafe.Infrastructure.Application
{
    public partial class CafeContext : BaseContext<CafeContext>, IAggregateRoot
    {
        public CafeContext(DbContextOptions<BaseContext<CafeContext>> options) : base(options)
        {
        }
        public  DbSet<CafeM> Cafes => Set<CafeM>();

        public  DbSet<Employee> Employees => Set<Employee>();
        public  DbSet<Subscription> Subscriptions => Set<Subscription>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }

}
