using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyXpense.Application.Common.Interfaces;
using MyXpense.Application.Features.Dashboard.DTOs;

namespace MyXpense.Application.Features.Dashboard.Queries.GetDashboard;

public record GetDashboardQuery(Guid UserId) : IRequest<DashboardDto>;

public class GetDashboardQueryHandler : IRequestHandler<GetDashboardQuery, DashboardDto>
{
    private readonly IDashboardService _dashboardService;

    public GetDashboardQueryHandler(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public async Task<DashboardDto> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
    {
        var monthly = await _dashboardService.GetMonthlyTotalAsync(request.UserId, cancellationToken);
        var weekly = await _dashboardService.GetWeeklyTotalAsync(request.UserId, cancellationToken);
        var breakdown = await _dashboardService.GetCategoryBreakdownAsync(request.UserId, cancellationToken);

        // Map from anonymous objects/dynamic to DTO (simplified)
        return new DashboardDto
        {
            MonthlyTotal = (decimal)((dynamic)monthly).Total,
            WeeklyTotal = (decimal)((dynamic)weekly).Total,
            CategoryBreakdown = ((System.Collections.Generic.IEnumerable<dynamic>)breakdown)
                .Select(b => new CategoryBreakdownDto { Category = b.Category, Total = b.Total })
                .ToList()
        };
    }
}
