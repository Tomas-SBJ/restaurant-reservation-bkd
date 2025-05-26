using Domain.Entities.Abstractions;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Base;

public class BaseEntityRepository<TEntity>(DatabaseContext context) : IBaseEntityRepository<TEntity> 
    where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> Entity = context.Set<TEntity>();
    
    public async Task<Guid> InsertOneAsync(TEntity entity)
    {
        await Entity.AddAsync(entity);
        return entity.Id;
    }
}