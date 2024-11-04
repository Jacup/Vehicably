using Vehicably.Domain.Entities;

namespace Vehicably.Domain.Exceptions;

public class EntityNotFoundException<T> : CustomException where T : DbObject
{
    public EntityNotFoundException(Guid entityId) : base($"Entity of type '{typeof(T).Name}' with ID = '{entityId}' not found")
    {
        EntityId = entityId;
    }

    public Guid EntityId { get; private set; }
}
