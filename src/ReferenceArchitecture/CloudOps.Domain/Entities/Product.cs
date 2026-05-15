namespace CloudOps.Domain.Entities;

public sealed class Product
{
    private Product() { }

    public Product(string name, string sku, decimal unitPrice, string? metadataJson = null)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Product name is required.", nameof(name));
        if (string.IsNullOrWhiteSpace(sku)) throw new ArgumentException("SKU is required.", nameof(sku));
        if (unitPrice <= 0) throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price must be greater than zero.");

        Id = Guid.NewGuid();
        Name = name.Trim();
        Sku = sku.Trim().ToUpperInvariant();
        UnitPrice = unitPrice;
        MetadataJson = metadataJson;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Sku { get; private set; } = string.Empty;
    public decimal UnitPrice { get; private set; }
    public string? MetadataJson { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
}
