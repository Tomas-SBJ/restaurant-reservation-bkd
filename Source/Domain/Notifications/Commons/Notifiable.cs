namespace Domain.Notifications.Commons;

public abstract class Notifiable
{
    private readonly List<Notification> _errors = [];
    
    public IReadOnlyCollection<Notification> Notifications => _errors;
    public bool IsValid => _errors.Count == 0;
    public bool IsInvalid => _errors.Count != 0;

    protected void AddNotification(Notification error)
    {
        _errors.Add(error);
    }
}