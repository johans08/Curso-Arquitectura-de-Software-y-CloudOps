using CloudOps.Application.Abstractions;
using CloudOps.Application.DTOs;
using CloudOps.Domain.Entities;
using CloudOps.Domain.Events;

namespace CloudOps.Application.Services;

public sealed class OrderService
{
    private readonly IOrderRepository _orders;
    private readonly IProductRepository _products;
    private readonly IOutboxWriter _outbox;

    public OrderService(IOrderRepository orders, IProductRepository products, IOutboxWriter outbox)
    {
        _orders = orders;
        _products = products;
        _outbox = outbox;
    }

    public async Task<OrderResponse> CreateAsync(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var order = new Order(request.CustomerId);

        foreach (var item in request.Items)
        {
            var product = await _products.GetByIdAsync(item.ProductId, cancellationToken)
                ?? throw new InvalidOperationException($"Product {item.ProductId} was not found.");
            order.AddItem(product.Id, item.Quantity, product.UnitPrice);
        }

        await _orders.AddAsync(order, cancellationToken);
        await _outbox.AddAsync(new OrderCreatedEvent(order.Id, order.CustomerId, order.Total, DateTime.UtcNow), cancellationToken);

        return new OrderResponse(order.Id, order.CustomerId, order.Status, order.Total);
    }
}
