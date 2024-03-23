using MediatR;
using WebApp.Domain.UserAggregate.Entities;
using WebApp.Domain.UserAggregate.Repositories;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Application.Handlers;

public record GetUserQuery(long Id) : IRequest<User>;

public class GetUserHandler(IUserRepository repo, ILogger<GetUserHandler> logger)
    : IRequestHandler<GetUserQuery, User?>
{
    private readonly IUserRepository _repo = repo;
    private readonly ILogger<GetUserHandler> _logger = logger;

    public async Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(LogCategory.QueryHandler, "Retrieving user");

        return await _repo.GetByIdAsync(request.Id);
    }
}
