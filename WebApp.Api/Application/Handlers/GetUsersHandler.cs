using MediatR;
using WebApp.Domain.UserAggregate.Entities;
using WebApp.Domain.UserAggregate.Repositories;
using WebApp.Infrastructure.Constants;

namespace WebApp.Api.Application.Handlers;

public record GetUsersQuery : IRequest<IEnumerable<User>>;

public class GetUsersHandler(IUserRepository repo, ILogger<GetUsersHandler> logger)
    : IRequestHandler<GetUsersQuery, IEnumerable<User>>
{
    private readonly IUserRepository _repo = repo;
    private readonly ILogger<GetUsersHandler> _logger = logger;

    public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(LogCategory.QueryHandler, "Retrieving users");

        return await _repo.GetAllAsync();
    }
}
