namespace Domain.Notifications.Commons;

public record Notification(
    string Type, 
    string Property,
    string Message
);