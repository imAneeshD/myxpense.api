using System;

namespace MyXpense.Application.Features.Groups.DTOs;

public class GroupDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid AdminUserId { get; set; }
    public bool IsDefault { get; set; }
    public int MemberCount { get; set; }
}
