
using System.Reflection;

namespace App.Shared
{
    public class BaseContext<TEntity> : DbContext where TEntity : class, IAggregateRoot
    {
        public BaseContext(DbContextOptions<BaseContext<TEntity>> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
