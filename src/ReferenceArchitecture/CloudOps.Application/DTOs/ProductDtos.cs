namespace CloudOps.Application.DTOs;

public sealed record ProductResponse(Guid Id, string Name, string Sku, decimal UnitPrice);
public sealed record CreateProductRequest(string Name, string Sku, decimal UnitPrice, string? MetadataJson);
