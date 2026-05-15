namespace MessagingLab.Api.Events;

public sealed class OrderCreatedConsumer(IEventBus eventBus, ILogger<OrderCreatedConsumer> logger) : BackgroundService
{
    private readonly HashSet<Guid> _processedEvents = [];

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await foreach (var message in eventBus.SubscribeAsync(stoppingToken))
        {
            if (message is not OrderCreatedEvent orderCreated)
                continue;

            if (!_processedEvents.Add(orderCreated.EventId))
            {
                logger.LogWarning("Duplicate event ignored: {EventId}", orderCreated.EventId);
                continue;
            }

            logger.LogInformation(
                "Processing OrderCreatedEvent. OrderId={OrderId}, Email={Email}, Total={Total}",
                orderCreated.OrderId,
                orderCreated.CustomerEmail,
                orderCreated.Total);

            await Task.Delay(500, stoppingToken);
            logger.LogInformation("Notification sent for order {OrderId}", orderCreated.OrderId);
        }
    }
}
