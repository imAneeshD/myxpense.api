using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyXpense.Application.Features.Expenses.Commands.CreateExpense;
using MyXpense.Application.Features.Expenses.Commands.DeleteExpense;
using MyXpense.Application.Features.Auth.Commands.Login;
using MyXpense.Application.Features.Auth.DTOs;

namespace MyXpense.API.GraphQL;

public class Mutation
{
    public async Task<Guid> CreateExpense(CreateExpenseCommand command, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(command, cancellationToken);
    }

    public async Task<AuthResponse> Login(LoginCommand command, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(command, cancellationToken);
    }

    public async Task<bool> DeleteExpense(Guid id, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new DeleteExpenseCommand(id), cancellationToken);
    }
}
