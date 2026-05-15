using Inventory.Api.Models;

namespace Inventory.Api.Services;

public interface IProductService
{
    Task<IReadOnlyList<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task<OperationResult<Product>> CreateAsync(CreateProductRequest request);
    Task<OperationResult<ProductPriceResponse>> CalculatePriceAsync(Guid id);
}
