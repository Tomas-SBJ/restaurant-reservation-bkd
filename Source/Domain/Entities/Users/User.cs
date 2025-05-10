using Domain.Commons;
using Domain.Entities.Abstractions;
using Domain.Enums;
using Domain.Notifications.Commons;
using OneOf;

namespace Domain.Entities.Users;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public EUserRole? Role { get; private set; }

    private User(string name, string email, string password, EUserRole? role)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public static OneOf<User, ValidationNotifiable> CreateUser(
        string name,
        string email,
        string password,
        EUserRole? role)
    {
        var notifications = new ValidationNotifiable();
        
        if (string.IsNullOrWhiteSpace(email))
            notifications.AddNotification(nameof(Email), "Email cannot be null or empty");

        if (!RegexPatterns.EmailRegex().IsMatch(email))
            notifications.AddNotification(nameof(Email), "Invalid email format");
        
        if (string.IsNullOrWhiteSpace(name))
            notifications.AddNotification(nameof(Name), "Name cannot be null or empty");
        
        if (string.IsNullOrWhiteSpace(password))
            notifications.AddNotification(nameof(Password), "Password cannot be null or empty");

        if (notifications.IsInvalid)
            return notifications;
        
        return new User(name, email, password, role);
    }
}