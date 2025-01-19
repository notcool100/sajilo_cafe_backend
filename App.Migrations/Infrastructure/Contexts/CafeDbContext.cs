namespace App.Migrations.Infrastructure.Contexts
{
    public class CafeDbContext : BaseContext<CafeDbContext>, IAggregateRoot
    {
        public CafeDbContext(DbContextOptions<BaseContext<CafeDbContext>> options, IConfiguration configuration)
            : base(options, configuration)
        {
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<CafeM> Cafes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<SubModule> SubModules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("cafe");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CafeDbContext).Assembly);

            modelBuilder.Entity<User>().ToTable("User", "security");
            modelBuilder.Entity<SubModule>().ToTable("SubModules", "security");
            modelBuilder.Entity<UserRole>().ToTable("UserRole", "security");
            modelBuilder.Entity<UserStatusLog>().ToTable("UserStatusLog", "security");
            modelBuilder.Entity<ModuleRole>().ToTable("ModuleRole", "security");
            modelBuilder.Entity<SubModuleFunction>().ToTable("SubModuleFunction", "security");
            modelBuilder.Entity<Module>().ToTable("Module", "security");
            modelBuilder.Entity<Menu>().ToTable("Menu", "security");
        }
    }
}
