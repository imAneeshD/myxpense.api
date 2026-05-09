using System;
using MyXpense.Domain.Common;

namespace MyXpense.Domain.Entities;

public class Notification : BaseAuditableEntity
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string NotificationType { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime TriggeredAt { get; set; }

    public User User { get; set; } = null!;
}
