using System.Threading.Channels;

namespace TaskFlow.Api.Events;

public interface IEventBus
{
    ValueTask PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : notnull;
    IAsyncEnumerable<object> SubscribeAsync(CancellationToken cancellationToken = default);
}

public sealed class InMemoryEventBus : IEventBus
{
    private readonly Channel<object> _channel = Channel.CreateUnbounded<object>();

    public async ValueTask PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : notnull
    {
        await _channel.Writer.WriteAsync(message, cancellationToken);
    }

    public IAsyncEnumerable<object> SubscribeAsync(CancellationToken cancellationToken = default)
    {
        return _channel.Reader.ReadAllAsync(cancellationToken);
    }
}

public sealed record TaskCreatedEvent(Guid EventId, Guid TaskId, string Owner, string Title);

public sealed class TaskCreatedConsumer(IEventBus eventBus, ILogger<TaskCreatedConsumer> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var message in eventBus.SubscribeAsync(stoppingToken))
        {
            if (message is TaskCreatedEvent taskCreated)
            {
                logger.LogInformation("TaskCreatedEvent consumed. Task={TaskId}, Owner={Owner}, Title={Title}", taskCreated.TaskId, taskCreated.Owner, taskCreated.Title);
            }
        }
    }
}
