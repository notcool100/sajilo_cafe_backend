using App.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cafe.Infrastructure.Application
{
    public class CafeContext:BaseContext
    {
        public virtual DbSet<CafeM> Cafe { get; set; }

        public virtual DbSet<Employee> Cafestaffs { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<CafeM>(entity =>
        {
            _ = entity.HasKey(e => e.Id).HasName("cafe_pkey");

            _ = entity.ToTable("cafe", "security");

            _ = entity.Property(e => e.Id).HasColumnName("Id");
            _ = entity.Property(e => e.Address).HasColumnName("address");
            _ = entity.Property(e => e.CafeLogo).HasColumnName("cafe_logo");
            _ = entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("cafename");
            _ = entity.Property(e => e.EntryDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("EntryDate");
            _ = entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

            _ = entity.HasOne(d => d.Subscription).WithMany(p => p.Caves)
                .HasForeignKey(d => d.Subscriptionid)
                .HasConstraintName("cafe_subscriptionid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
