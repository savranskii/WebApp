using FluentValidation;
using MediatR;
using WebApp.Api.Application.Models;
using WebApp.Api.Application.Validators;
using WebApp.Domain.PlayerAggregate.Repositories;
using WebApp.Domain.PlayerAggregate.ValueObjects;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Application.Handlers;

public record UpdatePlayerCommand(UpdatePlayerRequest Data) : IRequest;

public class UpdatePlayerHandler(IPlayerRepository repo, ILogger<UpdatePlayerHandler> logger)
    : IRequestHandler<UpdatePlayerCommand>
{
    public async Task Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(LogCategory.CommandHandler, "Validating request");
        await new UpdatePlayerCommandValidator().ValidateAndThrowAsync(request, cancellationToken);

        logger.LogInformation(LogCategory.CommandHandler, "Updating player");

        var player = await repo.GetByIdAsync(request.Data.Id) ?? throw new ArgumentException("Invalid ID");
        player.SetName(new FullName(
            FirstName: request.Data.FirstName,
            LastName: request.Data.LastName
        ));
        player.SetAddress(new Address(
            Street: request.Data.Street,
            City: request.Data.City,
            Country: request.Data.Country,
            ZipCode: request.Data.ZipCode
        ));

        await repo.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        logger.LogInformation(LogCategory.CommandHandler, "Player updated");
    }
}
