namespace Domain.Entities.Abstractions;

public interface IBaseEntityRepository<in TEntity> where TEntity : BaseEntity
{
    Task<Guid> InsertOneAsync(TEntity entity);
}