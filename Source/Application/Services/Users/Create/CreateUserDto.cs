namespace Application.Services.Users.Create;

public record CreateUserDto(
    string Name, 
    string Email,
    string Password
);