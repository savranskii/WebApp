namespace WebApp.Domain.Seeds;

public interface IRepository<TKey, TValue>
    where TKey : struct
    where TValue : new()
{
    Task<TValue?> GetByIdAsync(TKey id);
    void Update(TValue item);
    void Create(TValue item);
    Task DeleteAsync(TKey id);
}
