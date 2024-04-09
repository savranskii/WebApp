using WebApp.Api.Application.Constants;
using WebApp.Api.Infrastructure.Endpoints;

namespace WebApp.Api.Extensions;

public static class EndpointConfiguration
{
    public static void MapPlayersEndpoints(this WebApplication app)
    {
        app.MapGroup("/api/v1/players")
            .MapPlayersApi()
            .RequireRateLimiting(RateLimitPolicy.FixedPolicy)
            .WithOpenApi()
            .WithTags("Players")
            .AllowAnonymous();
    }

    private static RouteGroupBuilder MapPlayersApi(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:long}", PlayersEndpoint.GetAsync).WithDescription("Get player by ID");
        group.MapGet("/", PlayersEndpoint.GetAllAsync).WithDescription("Retrieve all players");
        group.MapPost("/", PlayersEndpoint.CreateAsync).WithDescription("Create new player");
        group.MapPut("/", PlayersEndpoint.UpdateAsync).WithDescription("Update existing player");
        group.MapDelete("/{id:long}", PlayersEndpoint.DeleteAsync).WithDescription("Delete player by ID");

        return group;
    }
}
