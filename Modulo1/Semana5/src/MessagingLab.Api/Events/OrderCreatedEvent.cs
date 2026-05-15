namespace MessagingLab.Api.Events;

public sealed record OrderCreatedEvent(
    Guid EventId,
    Guid OrderId,
    string CustomerEmail,
    decimal Total,
    DateTimeOffset OccurredAt
);
