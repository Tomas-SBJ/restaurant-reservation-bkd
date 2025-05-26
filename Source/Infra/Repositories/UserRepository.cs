using Domain.Entities.Users;
using Infra.Contexts;
using Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

internal class UserRepository(DatabaseContext context) : BaseEntityRepository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Entity.AsNoTracking().Where(x => x.Email == email).FirstOrDefaultAsync();
    }
}