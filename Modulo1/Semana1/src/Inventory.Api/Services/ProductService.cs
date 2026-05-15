using Inventory.Api.Models;
using Inventory.Api.Repositories;

namespace Inventory.Api.Services;

public sealed class ProductService(IProductRepository repository, IPricingPolicy pricingPolicy) : IProductService
{
    public Task<IReadOnlyList<Product>> GetAllAsync() => repository.GetAllAsync();

    public Task<Product?> GetByIdAsync(Guid id) => repository.GetByIdAsync(id);

    public async Task<OperationResult<Product>> CreateAsync(CreateProductRequest request)
    {
        var errors = Validate(request);
        if (errors.Count > 0)
            return OperationResult<Product>.Failure(errors.ToArray());

        var product = new Product(Guid.NewGuid(), request.Name.Trim(), request.BasePrice, request.Stock, request.IsPremium);
        await repository.AddAsync(product);
        return OperationResult<Product>.Success(product);
    }

    public async Task<OperationResult<ProductPriceResponse>> CalculatePriceAsync(Guid id)
    {
        var product = await repository.GetByIdAsync(id);
        if (product is null)
            return OperationResult<ProductPriceResponse>.Failure("Product not found");

        return OperationResult<ProductPriceResponse>.Success(pricingPolicy.Calculate(product));
    }

    private static List<string> Validate(CreateProductRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name is required");

        if (request.BasePrice <= 0)
            errors.Add("BasePrice must be greater than zero");

        if (request.Stock < 0)
            errors.Add("Stock cannot be negative");

        return errors;
    }
}
