using System;
using MyXpense.Domain.Common;

namespace MyXpense.Domain.Entities;

public class AlertRule : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public string RuleName { get; set; } = string.Empty;
    public string RuleType { get; set; } = string.Empty;
    public decimal? ThresholdPercentage { get; set; }
    public decimal? ThresholdAmount { get; set; }
    public bool IsEnabled { get; set; } = true;

    public User User { get; set; } = null!;
}
