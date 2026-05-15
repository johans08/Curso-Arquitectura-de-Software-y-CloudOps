using CloudOps.Application.Abstractions;
using CloudOps.Application.DTOs;
using CloudOps.Domain.Entities;

namespace CloudOps.Application.Services;

public sealed class ProductService
{
    private readonly IProductRepository _products;

    public ProductService(IProductRepository products)
    {
        _products = products;
    }

    public async Task<IReadOnlyList<ProductResponse>> ListAsync(CancellationToken cancellationToken)
    {
        var products = await _products.ListAsync(cancellationToken);
        return products.Select(p => new ProductResponse(p.Id, p.Name, p.Sku, p.UnitPrice)).ToList();
    }

    public async Task<ProductResponse> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Sku, request.UnitPrice, request.MetadataJson);
        await _products.AddAsync(product, cancellationToken);
        return new ProductResponse(product.Id, product.Name, product.Sku, product.UnitPrice);
    }
}
