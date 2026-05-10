using System.Collections.Generic;
using System.Security.Claims;
using MyXpense.Domain.Entities;

namespace MyXpense.Application.Common.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(User user);
}
