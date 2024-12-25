
namespace App.Shared
{
    public class BaseContext<TEntity> : DbContext where TEntity : class, IAggregateRoot
    {
        public BaseContext(DbContextOptions<BaseContext<TEntity>> options) : base(options)
        {

        }
       
    }
}
