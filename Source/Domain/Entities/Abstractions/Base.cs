namespace Domain.Entities.Abstractions;

public abstract class Base
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected void SetCreatedProperties()
    {
        CreatedAt = DateTime.UtcNow;
    }

    protected void SetUpdatedProperties()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}