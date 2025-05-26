using Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings.Commons;

public abstract class BaseMapping<TEntity> : IBaseMapping where TEntity : BaseEntity
{
    protected abstract string TableName { get; }
    
    public void Map(ModelBuilder modelBuilder)
    {
        var entityBuilder = modelBuilder.Entity<TEntity>();
        MapBase(entityBuilder);
        MapEntity(entityBuilder);
    }

    private void MapBase(EntityTypeBuilder<TEntity> builder)
    {
        builder.ToTable(TableName);
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever().HasColumnName("id").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
    }
    
    protected abstract void MapEntity(EntityTypeBuilder<TEntity> builder);
}