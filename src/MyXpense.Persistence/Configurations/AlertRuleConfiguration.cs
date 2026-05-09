using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyXpense.Domain.Entities;

namespace MyXpense.Persistence.Configurations;

public class AlertRuleConfiguration : IEntityTypeConfiguration<AlertRule>
{
    public void Configure(EntityTypeBuilder<AlertRule> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.RuleName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.RuleType).IsRequired().HasMaxLength(50);
        builder.Property(e => e.ThresholdPercentage).HasPrecision(5, 2);
        builder.Property(e => e.ThresholdAmount).HasPrecision(18, 2);

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
