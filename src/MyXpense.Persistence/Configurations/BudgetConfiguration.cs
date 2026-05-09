using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyXpense.Domain.Entities;

namespace MyXpense.Persistence.Configurations;

public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.BudgetName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.MonthlyLimit).HasPrecision(18, 2);

        builder.HasOne(e => e.User)
            .WithMany(u => u.Budgets)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Tag)
            .WithMany()
            .HasForeignKey(e => e.TagId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
