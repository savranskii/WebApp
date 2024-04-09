using FluentValidation;
using MediatR;
using WebApp.Api.Application.Models;
using WebApp.Api.Application.Validators;
using WebApp.Domain.PlayerAggregate.Entities;
using WebApp.Domain.PlayerAggregate.Repositories;
using WebApp.Domain.PlayerAggregate.ValueObjects;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Application.Handlers;

public record CreatePlayerCommand(CreatePlayerRequest Data) : IRequest<Player>;

public class CreatePlayerHandler(IPlayerRepository repo, ILogger<CreatePlayerHandler> logger)
    : IRequestHandler<CreatePlayerCommand, Player>
{
    public async Task<Player> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(LogCategory.CommandHandler, "Validating request");
        await new CreatePlayerCommandValidator().ValidateAndThrowAsync(request, cancellationToken);

        var player = new Player(
            request.Data.Email,
            new FullName(
                FirstName: request.Data.FirstName,
                LastName: request.Data.LastName
            ),
            new Address(
                Street: request.Data.Street,
                City: request.Data.City,
                Country: request.Data.Country,
                ZipCode: request.Data.ZipCode
            ));

        logger.LogInformation(LogCategory.CommandHandler, "Creating Player");

        repo.Create(player);
        await repo.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        logger.LogInformation(LogCategory.CommandHandler, "Player created");

        return player;
    }
}
