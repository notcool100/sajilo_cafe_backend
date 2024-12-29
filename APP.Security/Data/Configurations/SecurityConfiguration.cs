using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Security.Infrastructure.Domain.Users;

namespace Security.Infrastructure.Data.Configurations
{
    
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            _ = entity.ToTable("users", SecuritySchema.Name);


        }
    }
}
