using Domain.Enums;
using Domain.Extensions;
using Domain.Notifications.Commons;

namespace Domain.Notifications;

public class InvalidUserNotifiable : Notifiable
{
    public void AddNotification(string property, string message)
    {
        AddNotification(new Notification(EErrorType.InvalidUser.GetDescription(), property, message));
    }
}