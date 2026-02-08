using Mediator.Notifications;

namespace Core.SeedWork;

public abstract class EntityWithNotification : Entity
{
    private readonly List<INotification> _notifications = [];

    public IReadOnlyCollection<INotification> Notifications => _notifications.AsReadOnly();

    public void AddNotification(INotification eventItem)
        => _notifications.Add(eventItem);

    public void RemoveNotification(INotification eventItem)
        => _notifications.Remove(eventItem);

    public void ClearNotification()
        => _notifications.Clear();
}
