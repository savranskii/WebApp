using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Application.Handlers;
using WebApp.Api.Application.Models;
using WebApp.Domain.PlayerAggregate.Entities;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Infrastructure.Endpoints;

public class PlayersEndpoint
{
    public static async Task<Results<Ok<Player>, NotFound>> GetAsync(
        [FromRoute] long id,
        [FromServices] IMediator mediator,
        [FromServices] ILogger<PlayersEndpoint> logger)
    {
        logger.LogInformation(LogCategory.Endpoint, "Execute get by id player");

        var player = await mediator.Send(new GetPlayerQuery(id));

        return TypedResults.Ok(player);
    }

    public static async Task<Ok<IEnumerable<Player>>> GetAllAsync(
        [FromServices] IMediator mediator,
        [FromServices] ILogger<PlayersEndpoint> logger)
    {
        logger.LogInformation(LogCategory.Endpoint, "Execute get all player");

        var players = await mediator.Send(new GetPlayersQuery());

        return TypedResults.Ok(players);
    }

    public static async Task<Ok<Player>> CreateAsync(
        [FromBody] CreatePlayerRequest data,
        [FromServices] IMediator mediator,
        [FromServices] ILogger<PlayersEndpoint> logger)
    {
        logger.LogInformation(LogCategory.Endpoint, "Execute create player");

        var player = await mediator.Send(new CreatePlayerCommand(data));

        return TypedResults.Ok(player);
    }

    public static async Task<NoContent> UpdateAsync(
        [FromBody] UpdatePlayerRequest data,
        [FromServices] IMediator mediator,
        [FromServices] ILogger<PlayersEndpoint> logger)
    {
        logger.LogInformation(LogCategory.Endpoint, "Execute update player");

        await mediator.Send(new UpdatePlayerCommand(data));

        return TypedResults.NoContent();
    }

    public static async Task<NoContent> DeleteAsync(
        [FromRoute] long id,
        [FromServices] IMediator mediator,
        [FromServices] ILogger<PlayersEndpoint> logger)
    {
        logger.LogInformation(LogCategory.Endpoint, "Execute delete player");

        await mediator.Send(new DeletePlayerCommand(id));

        return TypedResults.NoContent();
    }
}
