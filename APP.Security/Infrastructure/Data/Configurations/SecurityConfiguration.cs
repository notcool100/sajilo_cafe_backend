using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Security.App.Infrastructure.Data.Configurations
{
    internal static class SecuritySchema
    {
        public static string Name = "Security";
    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            _ = entity.ToTable("users", SecuritySchema.Name);


        }
    }
}
