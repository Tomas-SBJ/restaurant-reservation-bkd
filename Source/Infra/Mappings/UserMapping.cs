using Domain.Entities.Users;
using Infra.Mappings.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings;

public class UserMapping : BaseMapping<User>
{
    protected override string TableName => "users";

    protected override void MapEntity(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Name).HasColumnName("name").IsRequired();
        builder.Property(x => x.Email).HasColumnName("email").IsRequired();
        builder.Property(x => x.Password).HasColumnName("password").IsRequired();
        builder.Property(x => x.Role).HasColumnName("role").HasConversion<string>();
    }
}