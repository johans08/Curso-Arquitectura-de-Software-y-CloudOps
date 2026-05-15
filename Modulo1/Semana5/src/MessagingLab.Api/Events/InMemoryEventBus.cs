using System.Threading.Channels;

namespace MessagingLab.Api.Events;

public sealed class InMemoryEventBus : IEventBus
{
    private readonly Channel<object> _channel = Channel.CreateUnbounded<object>();

    public async ValueTask PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : notnull
    {
        await _channel.Writer.WriteAsync(@event, cancellationToken);
    }

    public IAsyncEnumerable<object> SubscribeAsync(CancellationToken cancellationToken = default)
    {
        return _channel.Reader.ReadAllAsync(cancellationToken);
    }
}
