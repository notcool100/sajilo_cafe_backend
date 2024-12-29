using Microsoft.Extensions.Configuration;

namespace App.Shared
{
    public class BaseContext<TEntity> : DbContext where TEntity : class, IAggregateRoot
    {
        private readonly IConfiguration _configuration;
        public BaseContext(DbContextOptions<BaseContext<TEntity>> options,IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        //need to make more generic to support configring from sperate config file 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string provider = _configuration["ConnectionStrings:Provider"];
            string defaultConnection = _configuration["ConnectionStrings:DefaultConnection"];
            Console.WriteLine($"Provider: {provider}");
            Console.WriteLine($"DefaultConnection: {defaultConnection}");
            Console.WriteLine($"Config: {_configuration["ConnectionStrings:DefaultConnection"]}");
            if (defaultConnection == null)
            {
                throw new NotSupportedException("Default connection string not found");
            }
            switch (provider)
            {
                case "MSSQL":
                    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MSSQL")?? defaultConnection);
                    break;
                case "pgsql":
                    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("pgsql")?? defaultConnection);
                    break;
                default:
                    throw new NotSupportedException("Database provider not supported");
            }
            _ = optionsBuilder.UseLowerCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
