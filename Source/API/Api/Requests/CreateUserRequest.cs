using Application.Services.Users.Create;

namespace API.Api.Requests;

public class CreateUserRequest
{
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }

    internal static CreateUserDto ToCreateUserDto(CreateUserRequest request)
    {
        return new CreateUserDto(request.Name, request.Email, request.Password);
    }
}