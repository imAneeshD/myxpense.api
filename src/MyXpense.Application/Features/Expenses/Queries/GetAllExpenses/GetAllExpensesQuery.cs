using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyXpense.Application.Common.Interfaces;
using MyXpense.Application.Features.Expenses.DTOs;

namespace MyXpense.Application.Features.Expenses.Queries.GetAllExpenses;

public record GetAllExpensesQuery : IRequest<List<ExpenseDto>>;

public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllExpensesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ExpenseDto>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Expenses
            .Include(e => e.Category)
            .OrderByDescending(e => e.ExpenseDate)
            .Select(e => new ExpenseDto
            {
                Id = e.Id,
                UserId = e.UserId,
                CategoryId = e.CategoryId,
                Title = e.Title,
                Description = e.Description,
                Amount = e.Amount,
                ExpenseDate = e.ExpenseDate,
                PaymentMethod = e.PaymentMethod,
                IsRecurring = e.IsRecurring,
                CategoryName = e.Category.Name
            })
            .ToListAsync(cancellationToken);
    }
}
