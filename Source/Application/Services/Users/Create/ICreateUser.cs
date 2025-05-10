using Domain.Notifications.Commons;
using OneOf;

namespace Application.Services.Users.Create;

public interface ICreateUser
{
    Task<OneOf<Guid, ValidationNotifiable, ConflictNotifiable>> CreateUserAsync(CreateUserDto dto);
}