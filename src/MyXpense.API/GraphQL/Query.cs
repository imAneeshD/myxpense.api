using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyXpense.Application.Features.Expenses.DTOs;
using MyXpense.Application.Features.Expenses.Queries.GetAllExpenses;

namespace MyXpense.API.GraphQL;

public class Query
{
    public async Task<List<ExpenseDto>> GetExpenses([Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetAllExpensesQuery(), cancellationToken);
    }
}
