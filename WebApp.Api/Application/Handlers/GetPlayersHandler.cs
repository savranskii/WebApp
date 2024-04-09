using MediatR;
using WebApp.Domain.PlayerAggregate.Entities;
using WebApp.Domain.PlayerAggregate.Repositories;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Application.Handlers;

public record GetPlayersQuery : IRequest<IEnumerable<Player>>;

public class GetPlayersHandler(IPlayerRepository repo, ILogger<GetPlayersHandler> logger)
    : IRequestHandler<GetPlayersQuery, IEnumerable<Player>>
{
    public async Task<IEnumerable<Player>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation(LogCategory.QueryHandler, "Retrieving players");

        return await repo.GetAllAsync();
    }
}
