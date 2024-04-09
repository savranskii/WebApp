using WebApp.Domain.PlayerAggregate.Entities;
using WebApp.Domain.Seeds;

namespace WebApp.Domain.PlayerAggregate.Repositories;

public interface IPlayerRepository : IRepository<long, Player>
{
    IUnitOfWork UnitOfWork { get; }

    Task<IEnumerable<Player>> GetAllAsync();
}
