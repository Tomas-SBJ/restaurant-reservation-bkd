using Domain.Entities.Users;
using Domain.Enums;
using FluentAssertions;
using Microsoft.VisualBasic.CompilerServices;
using Xunit;

namespace UnitTests.Entities;

public class UserTests
{
    [Fact]
    public void CreateUser_GivenValidData_ThenReturnUser()
    {
        const string name = "name";
        const string email = "name@gmail.com";
        const string password = "password";
        const EUserRole role = EUserRole.Admin;

        var result = User.CreateUser(name, email, password, role);
        var user = result.AsT0;

        result.IsT0.Should().BeTrue();
        user.Name.Should().Be(name);
        user.Email.Should().Be(email);
        user.Role.Should().Be(role);
        BCrypt.Net.BCrypt.Verify(password, user.Password).Should().BeTrue();
    }

    [Fact]
    public void CreateUser_GivenNullOrEmptyEmail_ThenReturnNotification()
    {
        var result = User.CreateUser("name", "", "password");
        var notification = result.AsT1;

        result.IsT1.Should().BeTrue();
        notification.Notifications.Should().ContainSingle(x =>
            x.Property == nameof(User.Email) && x.Message == "Email cannot be null or empty");
    }
    
    [Fact]
    public void CreateUser_GivenInvalidEmail_ThenReturnNotification()
    {
        var result = User.CreateUser("name", "namegmail.com", "password");
        var notification = result.AsT1;

        result.IsT1.Should().BeTrue();
        notification.Notifications.Should().ContainSingle(x =>
            x.Property == nameof(User.Email) && x.Message == "Invalid email format");
    }
    
    [Fact]
    public void CreateUser_GivenNullOrEmptyName_ThenReturnNotification()
    {
        var result = User.CreateUser("", "name@gmail.com", "password");
        var notification = result.AsT1;

        result.IsT1.Should().BeTrue();
        notification.Notifications.Should().ContainSingle(x =>
            x.Property == nameof(User.Name) && x.Message == "Name cannot be null or empty");
    }
    
    [Fact]
    public void CreateUser_GivenNullOrEmptyPassword_ThenReturnNotification()
    {
        var result = User.CreateUser("name", "name@gmail.com", "");
        var notification = result.AsT1;

        result.IsT1.Should().BeTrue();
        notification.Notifications.Should().ContainSingle(x =>
            x.Property == nameof(User.Password) && x.Message == "Password cannot be null or empty");
    }

    [Fact]
    public void CreateUser_GivenMultipleInvalidFields_ThenReturnMultipleNotifications()
    {
        var result = User.CreateUser("", "invalidEmail", "");
        var notification = result.AsT1;

        result.IsT1.Should().BeTrue();
        notification.Notifications.Should().Contain(x => x.Property == nameof(User.Name));
        notification.Notifications.Should().Contain(x => x.Property == nameof(User.Email));
        notification.Notifications.Should().Contain(x => x.Property == nameof(User.Password));
        notification.Notifications.Should().HaveCount(3);
    }
}