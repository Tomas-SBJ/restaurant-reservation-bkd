using Domain.Enums;
using Domain.Extensions;
using Domain.Notifications.Base;

namespace Domain.Notifications.Commons;

public class ConflictNotifiable : Notifiable
{
    public void AddNotification(string property, string message)
    {
        AddNotification(new Notification(EErrorType.ConflictError.GetDescription(), property, message));
    }
}