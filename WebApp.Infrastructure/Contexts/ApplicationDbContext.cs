using Microsoft.EntityFrameworkCore;
using WebApp.Domain.UserAggregate.Entities;
using WebApp.Domain.Seeds;
using WebApp.Infrastructure.EntityConfigurations;

namespace WebApp.Infrastructure.Contexts;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users => Set<User>();

    public async Task<bool> SaveEntitiesAsync(CancellationToken ct = default)
    {
        await base.SaveChangesAsync(ct);

        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
