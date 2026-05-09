using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyXpense.Application.Features.Expenses.Commands.CreateExpense;

namespace MyXpense.API.GraphQL;

public class Mutation
{
    public async Task<Guid> CreateExpense(CreateExpenseCommand command, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(command, cancellationToken);
    }
}
