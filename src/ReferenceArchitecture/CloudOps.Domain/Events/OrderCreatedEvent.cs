namespace CloudOps.Domain.Events;

public sealed record OrderCreatedEvent(Guid OrderId, Guid CustomerId, decimal Total, DateTime OccurredOnUtc);
