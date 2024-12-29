
namespace Security.Infrastructure.Data
{
    internal static class SecuritySchema
    {
        public static string Name = "security";
    }
    public partial class SecurityContext : BaseContext<SecurityContext>, IAggregateRoot
    {
        public SecurityContext(DbContextOptions<BaseContext<SecurityContext>> options,IConfiguration configuration) : base(options, configuration)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<UserStatusLog> UserStatus => Set<UserStatusLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SecuritySchema.Name);
            base.OnModelCreating(modelBuilder);
        }

    }

}
