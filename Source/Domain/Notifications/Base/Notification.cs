namespace Domain.Notifications.Base;

public record Notification(
    string Type, 
    string Property,
    string Message
);