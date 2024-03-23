using WebApp.Domain.UserAggregate.Entities;
using WebApp.Domain.Seeds;

namespace WebApp.Domain.UserAggregate.Repositories;

public interface IUserRepository : IRepository<long, User>
{
    IUnitOfWork UnitOfWork { get; }

    Task<IEnumerable<User>> GetAllAsync();
}
