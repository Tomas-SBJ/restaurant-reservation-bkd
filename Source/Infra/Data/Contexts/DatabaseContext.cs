using Infra.Data.Mappings.Commons;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Contexts;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var mappingTypes = typeof(BaseMapping<>).Assembly
            .GetTypes()
            .Where(x => x.IsAssignableTo(typeof(IBaseMapping)))
            .Where(x => !x.IsAbstract)
            .ToList();

        foreach (var mappingType in mappingTypes)
        {
            var mapping = Activator.CreateInstance(mappingType);
            var initializedMethod = mapping?.GetType().GetMethod(nameof(IBaseMapping.Map));
            
            initializedMethod?.Invoke(mapping, [modelBuilder]);
        }
    }
}