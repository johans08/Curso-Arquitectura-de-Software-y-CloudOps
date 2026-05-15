namespace CloudOps.Application.DTOs;

public sealed record CreateOrderItemRequest(Guid ProductId, int Quantity);
public sealed record CreateOrderRequest(Guid CustomerId, IReadOnlyList<CreateOrderItemRequest> Items);
public sealed record OrderResponse(Guid Id, Guid CustomerId, string Status, decimal Total);
