namespace WebApp.Domain.Seeds;

public interface IEntity<T> where T : struct
{
}

public interface IEntity : IEntity<long>
{
    long Id { get; protected set; }
}

public abstract class Entity : IEntity
{
    long _Id;

    public virtual long Id
    {
        get => _Id;
        set => _Id = value;
    }
}
