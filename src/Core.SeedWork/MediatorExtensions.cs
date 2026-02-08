using Mediator;

namespace Core.SeedWork;

public static class MediatorExtensions
{
    public static async Task DispatchNotificationsAsync(
        this IMediator mediator,
        INotificationContext context,
        CancellationToken cancellationToken = default)
    {
        var entitiesWithEvents = context.GetEntitiesWithNotifications();

        var domainEvents = entitiesWithEvents
            .SelectMany(entity =>
            {
                var events = entity.Notifications.ToList();
                entity.ClearNotification();
                return events;
            })
            .ToList();

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent, cancellationToken);
    }
}
