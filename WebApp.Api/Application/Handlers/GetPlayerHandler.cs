using MediatR;
using WebApp.Domain.PlayerAggregate.Entities;
using WebApp.Domain.PlayerAggregate.Repositories;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Application.Handlers;

public record GetPlayerQuery(long Id) : IRequest<Player>;

public class GetPlayerHandler(IPlayerRepository repo, ILogger<GetPlayerHandler> logger)
    : IRequestHandler<GetPlayerQuery, Player?>
{
    public async Task<Player?> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation(LogCategory.QueryHandler, "Retrieving player");

        return await repo.GetByIdAsync(request.Id);
    }
}
