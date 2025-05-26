using Microsoft.EntityFrameworkCore;

namespace Infra.Mappings.Commons;

public interface IBaseMapping
{
    void Map(ModelBuilder modelBuilder);
}