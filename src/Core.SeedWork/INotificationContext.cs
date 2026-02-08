namespace Core.SeedWork;

public interface INotificationContext
{
    IEnumerable<EntityWithNotification> GetEntitiesWithNotifications();
}
