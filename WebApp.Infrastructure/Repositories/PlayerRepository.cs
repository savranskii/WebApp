using Microsoft.EntityFrameworkCore;
using WebApp.Domain.PlayerAggregate.Entities;
using WebApp.Domain.PlayerAggregate.Repositories;
using WebApp.Domain.Seeds;
using WebApp.Infrastructure.Contexts;

namespace WebApp.Infrastructure.Repositories;

public class PlayerRepository(ApplicationDbContext context) : IPlayerRepository
{
    private readonly ApplicationDbContext _context = context;

    public IUnitOfWork UnitOfWork => _context;

    public void Create(Player item)
    {
        _context.Players.Add(item);
    }

    public async Task DeleteAsync(long id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player is not null)
        {
            _context.Players.Remove(player);
        }
    }

    public async Task<Player?> GetByIdAsync(long id)
    {
        return await _context.Players.FindAsync(id);
    }

    public async Task<IEnumerable<Player>> GetAllAsync()
    {
        return await _context.Players.ToListAsync();
    }

    public void Update(Player item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }
}
