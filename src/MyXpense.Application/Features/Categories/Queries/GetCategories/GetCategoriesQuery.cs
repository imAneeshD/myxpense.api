using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyXpense.Application.Common.Interfaces;
using MyXpense.Application.Features.Categories.DTOs;

namespace MyXpense.Application.Features.Categories.Queries.GetCategories;

public record GetCategoriesQuery(Guid UserId) : IRequest<List<CategoryDto>>;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetCategoriesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .Where(t => t.UserId == request.UserId || (t.GroupId != null)) // Simplified logic
            .Select(t => new CategoryDto
            {
                Id = t.Id,
                Name = t.Name,
                Color = t.Color,
                Icon = t.Icon,
                GroupId = t.GroupId
            })
            .ToListAsync(cancellationToken);
    }
}
