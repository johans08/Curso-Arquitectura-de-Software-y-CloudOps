namespace CloudOps.Domain.Entities;

public sealed class Order
{
    private readonly List<OrderItem> _items = new();

    private Order() { }

    public Order(Guid customerId)
    {
        if (customerId == Guid.Empty) throw new ArgumentException("Customer is required.", nameof(customerId));

        Id = Guid.NewGuid();
        CustomerId = customerId;
        Status = "Created";
        CreatedAtUtc = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public string Status { get; private set; } = "Created";
    public decimal Total { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public void AddItem(Guid productId, int quantity, decimal unitPrice)
    {
        if (productId == Guid.Empty) throw new ArgumentException("Product is required.", nameof(productId));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (unitPrice <= 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));

        _items.Add(new OrderItem(Id, productId, quantity, unitPrice));
        Total = _items.Sum(x => x.Subtotal);
    }
}
