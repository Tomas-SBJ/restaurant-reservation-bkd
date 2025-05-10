using Domain.Entities.Users;
using Domain.Notifications.Commons;
using OneOf;

namespace Application.Services.Users.Create;

internal class CreateUser(
    IUserRepository userRepository
) : ICreateUser
{
    public async Task<OneOf<Guid, ValidationNotifiable, ConflictNotifiable>> CreateUserAsync(CreateUserDto dto)
    {
        var user = await userRepository.GetByEmailAsync(dto.Email);

        if (user != null)
        {
            var conflict = new ConflictNotifiable();
            conflict.AddNotification(nameof(dto), $"User with email: {dto.Email} already exists");
            return conflict;
        }

        var userResult = User.CreateUser(dto.Name, dto.Email, dto.Password, null);

        if (userResult.IsT1)
            return userResult.AsT1;

        var userId = await userRepository.InsertOneAsync(userResult.AsT0);

        return userId;
    }
}