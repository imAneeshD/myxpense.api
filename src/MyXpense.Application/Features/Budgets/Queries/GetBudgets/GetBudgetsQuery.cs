using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyXpense.Application.Common.Interfaces;
using MyXpense.Application.Features.Budgets.DTOs;

namespace MyXpense.Application.Features.Budgets.Queries.GetBudgets;

public record GetBudgetsQuery(Guid UserId) : IRequest<List<BudgetDto>>;

public class GetBudgetsQueryHandler : IRequestHandler<GetBudgetsQuery, List<BudgetDto>>
{
    private readonly IApplicationDbContext _context;

    public GetBudgetsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<BudgetDto>> Handle(GetBudgetsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Budgets
            .Where(b => b.UserId == request.UserId)
            .Include(b => b.Category)
            .Select(b => new BudgetDto
            {
                Id = b.Id,
                BudgetName = b.BudgetName,
                MonthlyLimit = b.MonthlyLimit,
                StartMonth = b.StartMonth,
                CategoryName = b.Category.Name
            })
            .ToListAsync(cancellationToken);
    }
}
