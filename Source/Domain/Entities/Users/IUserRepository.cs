using Domain.Entities.Abstractions;

namespace Domain.Entities.Users;

public interface IUserRepository : IBaseEntityRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}