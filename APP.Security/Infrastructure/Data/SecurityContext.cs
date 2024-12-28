namespace Security.App.Infrastructure.Data
{
    public partial class SecurityContext : BaseContext<SecurityContext>, IAggregateRoot
    {
        public SecurityContext(DbContextOptions<BaseContext<SecurityContext>> options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<UserStatusLog> UserStatus => Set<UserStatusLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    }

}
