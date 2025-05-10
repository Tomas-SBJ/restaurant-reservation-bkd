using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Mappings.Commons;

public interface IBaseMapping
{
    void Map(ModelBuilder modelBuilder);
}