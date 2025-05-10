using Domain.Enums;
using Domain.Extensions;
using Domain.Notifications.Base;

namespace Domain.Notifications.Commons;

public class ValidationNotifiable : Notifiable
{
    public void AddNotification(string property, string message)
    {
        AddNotification(new Notification(EErrorType.ValidationError.GetDescription(), property, message));
    }
}