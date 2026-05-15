namespace MessagingLab.Api.Events;

public interface IEventBus
{
    ValueTask PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : notnull;
    IAsyncEnumerable<object> SubscribeAsync(CancellationToken cancellationToken = default);
}
