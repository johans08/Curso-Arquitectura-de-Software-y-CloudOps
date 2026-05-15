namespace ModularMonolith.Api.Modules.Catalog;

public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services)
    {
        services.AddSingleton<ICatalogService, CatalogService>();
        return services;
    }

    public static IEndpointRouteBuilder MapCatalogEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/catalog").WithTags("Catalog");

        group.MapGet("/products", (ICatalogService service) => Results.Ok(service.GetProducts()));
        group.MapGet("/products/{id:guid}", (Guid id, ICatalogService service) =>
        {
            var product = service.GetProduct(id);
            return product is null ? Results.NotFound() : Results.Ok(product);
        });

        return app;
    }
}

public interface ICatalogService
{
    IReadOnlyList<CatalogProduct> GetProducts();
    CatalogProduct? GetProduct(Guid id);
}

public sealed class CatalogService : ICatalogService
{
    private readonly List<CatalogProduct> _products =
    [
        new CatalogProduct(Guid.Parse("11111111-1111-1111-1111-111111111111"), "Architecture Book", 45m),
        new CatalogProduct(Guid.Parse("22222222-2222-2222-2222-222222222222"), "Cloud Ops Course", 150m)
    ];

    public IReadOnlyList<CatalogProduct> GetProducts() => _products;
    public CatalogProduct? GetProduct(Guid id) => _products.FirstOrDefault(p => p.Id == id);
}

public sealed record CatalogProduct(Guid Id, string Name, decimal Price);
