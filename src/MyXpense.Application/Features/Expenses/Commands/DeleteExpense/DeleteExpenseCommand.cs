using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyXpense.Application.Common.Interfaces;

namespace MyXpense.Application.Features.Expenses.Commands.DeleteExpense;

public record DeleteExpenseCommand(Guid Id) : IRequest<bool>;

public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteExpenseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Expenses.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            return false;
        }

        _context.Expenses.Remove(entity); // Soft delete handled by interceptor
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
