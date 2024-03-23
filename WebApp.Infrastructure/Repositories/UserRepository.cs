using Microsoft.EntityFrameworkCore;
using WebApp.Domain.UserAggregate.Entities;
using WebApp.Domain.UserAggregate.Repositories;
using WebApp.Domain.Seeds;
using WebApp.Infrastructure.Contexts;

namespace WebApp.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public IUnitOfWork UnitOfWork => _context;

    public void Create(User item)
    {
        _context.Users.Add(item);
    }

    public async Task DeleteAsync(long id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is not null)
        {
            _context.Users.Remove(user);
        }
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public void Update(User item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }
}
