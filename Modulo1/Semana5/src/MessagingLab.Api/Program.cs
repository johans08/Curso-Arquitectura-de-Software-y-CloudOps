using MessagingLab.Api.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();
builder.Services.AddHostedService<OrderCreatedConsumer>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok", messaging = "in-memory" }));

app.MapPost("/orders", async (CreateOrderRequest request, IEventBus eventBus) =>
{
    if (request.Total <= 0)
        return Results.BadRequest(new { message = "Total must be greater than zero" });

    var orderId = Guid.NewGuid();
    var @event = new OrderCreatedEvent(Guid.NewGuid(), orderId, request.CustomerEmail, request.Total, DateTimeOffset.UtcNow);

    await eventBus.PublishAsync(@event);

    return Results.Accepted($"/orders/{orderId}", new
    {
        orderId,
        status = "Accepted",
        eventId = @event.EventId,
        message = "Order accepted and event published"
    });
});

app.Run("http://localhost:5000");

public sealed record CreateOrderRequest(string CustomerEmail, decimal Total);
