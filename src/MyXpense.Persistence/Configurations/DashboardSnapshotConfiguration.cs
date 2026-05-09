using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyXpense.Domain.Entities;

namespace MyXpense.Persistence.Configurations;

public class DashboardSnapshotConfiguration : IEntityTypeConfiguration<DashboardSnapshot>
{
    public void Configure(EntityTypeBuilder<DashboardSnapshot> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.SnapshotMonth).IsRequired().HasMaxLength(10);
        builder.Property(e => e.TotalExpense).HasPrecision(18, 2);
        builder.Property(e => e.TotalIncome).HasPrecision(18, 2);
        builder.Property(e => e.AverageDailySpend).HasPrecision(18, 2);

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
