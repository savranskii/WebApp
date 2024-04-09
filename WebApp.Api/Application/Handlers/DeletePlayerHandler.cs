using FluentValidation;
using MediatR;
using WebApp.Api.Application.Validators;
using WebApp.Domain.PlayerAggregate.Repositories;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Application.Handlers;

public record DeletePlayerCommand(long Id) : IRequest;

public class DeletePlayerHandler(IPlayerRepository repo, ILogger<DeletePlayerHandler> logger)
    : IRequestHandler<DeletePlayerCommand>
{
    public async Task Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(LogCategory.CommandHandler, "Validating request");
        await new DeletePlayerCommandValidator().ValidateAndThrowAsync(request, cancellationToken);

        logger.LogInformation(LogCategory.CommandHandler, "Deleting player");

        await repo.DeleteAsync(request.Id);
        await repo.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        logger.LogInformation(LogCategory.CommandHandler, "Player deleted");
    }
}
