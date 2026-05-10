using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyXpense.Application.Common.Interfaces;
using MyXpense.Domain.Entities;

namespace MyXpense.Application.Features.Expenses.Commands.CreateExpense;

public record CreateExpenseCommand : IRequest<Guid>
{
    public Guid UserId { get; init; }
    public Guid CategoryId { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public decimal Amount { get; init; }
    public DateTime ExpenseDate { get; init; }
    public string? PaymentMethod { get; init; }
    public bool IsRecurring { get; init; }
}

public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateExpenseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = new Expense
        {
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            Title = request.Title,
            Description = request.Description,
            Amount = request.Amount,
            ExpenseDate = request.ExpenseDate,
            PaymentMethod = request.PaymentMethod,
            IsRecurring = request.IsRecurring
        };

        _context.Expenses.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
