using Inventory.Api.Models;

namespace Inventory.Api.Repositories;

public sealed class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products =
    [
        new Product(Guid.Parse("11111111-1111-1111-1111-111111111111"), "Laptop", 1200m, 10, true),
        new Product(Guid.Parse("22222222-2222-2222-2222-222222222222"), "Mouse", 25m, 100, false)
    ];

    public Task<IReadOnlyList<Product>> GetAllAsync() => Task.FromResult<IReadOnlyList<Product>>(_products);

    public Task<Product?> GetByIdAsync(Guid id) => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

    public Task AddAsync(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }
}
