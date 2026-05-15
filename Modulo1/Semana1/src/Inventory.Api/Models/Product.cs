namespace Inventory.Api.Models;

public sealed record Product(
    Guid Id,
    string Name,
    decimal BasePrice,
    int Stock,
    bool IsPremium
);

public sealed record CreateProductRequest(
    string Name,
    decimal BasePrice,
    int Stock,
    bool IsPremium
);

public sealed record ProductPriceResponse(
    Guid ProductId,
    decimal BasePrice,
    decimal Discount,
    decimal FinalPrice
);
