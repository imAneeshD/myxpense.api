using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyXpense.Application.Features.Expenses.DTOs;
using MyXpense.Application.Features.Expenses.Queries.GetAllExpenses;
using MyXpense.Application.Features.Categories.DTOs;
using MyXpense.Application.Features.Categories.Queries.GetCategories;
using MyXpense.Application.Features.Users.DTOs;
using MyXpense.Application.Features.Users.Queries.GetUsers;
using MyXpense.Application.Features.Groups.DTOs;
using MyXpense.Application.Features.Groups.Queries.GetGroups;
using MyXpense.Application.Features.Dashboard.DTOs;
using MyXpense.Application.Features.Dashboard.Queries.GetDashboard;
using MyXpense.Application.Features.Notifications.DTOs;
using MyXpense.Application.Features.Notifications.Queries.GetNotifications;
using MyXpense.Application.Features.Budgets.DTOs;
using MyXpense.Application.Features.Budgets.Queries.GetBudgets;

namespace MyXpense.API.GraphQL;

public class Query
{
    [UseFiltering]
    [UseSorting]
    public async Task<List<ExpenseDto>> GetExpenses([Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetAllExpensesQuery(), cancellationToken);
    }

    public async Task<List<CategoryDto>> GetCategories(Guid userId, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetCategoriesQuery(userId), cancellationToken);
    }

    public async Task<List<UserDto>> GetUsers([Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetUsersQuery(), cancellationToken);
    }

    public async Task<List<GroupDto>> GetGroups([Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetGroupsQuery(), cancellationToken);
    }

    public async Task<DashboardDto> GetDashboard(Guid userId, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetDashboardQuery(userId), cancellationToken);
    }

    public async Task<List<NotificationDto>> GetNotifications(Guid userId, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetNotificationsQuery(userId), cancellationToken);
    }

    public async Task<List<BudgetDto>> GetBudgets(Guid userId, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetBudgetsQuery(userId), cancellationToken);
    }
}
