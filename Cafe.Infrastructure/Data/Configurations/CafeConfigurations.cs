namespace Cafe.Infrastructure.Data.Configurations
{
    internal static class CafeSchema
    {
        public static string Name = "cafe";
    }
    public class CafeMConfiguration : IEntityTypeConfiguration<CafeM>
    {
        public void Configure(EntityTypeBuilder<CafeM> entity)
        {
            _ = entity.ToTable("cafes", CafeSchema.Name);
            _ = entity.HasKey(e => e.Id).HasName("cafe_pkey");
            _ = entity.Property(e => e.EntryDate)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP")
                        .HasColumnType("timestamp without time zone");
            _ = entity.HasOne(d => d.Subscription).WithMany(p => p.Caves)
                        .HasForeignKey(d => d.Subscriptionid);

        }
    }
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            _ = entity.ToTable("employees", CafeSchema.Name);

        }
    }
}
