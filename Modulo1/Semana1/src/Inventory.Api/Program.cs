using Inventory.Api.Models;
using Inventory.Api.Repositories;
using Inventory.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddSingleton<IPricingPolicy, DefaultPricingPolicy>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok", service = "Inventory.Api" }));

app.MapGet("/products", async (IProductService service) =>
{
    var products = await service.GetAllAsync();
    return Results.Ok(products);
});

app.MapGet("/products/{id:guid}", async (Guid id, IProductService service) =>
{
    var product = await service.GetByIdAsync(id);
    return product is null ? Results.NotFound(new { message = "Product not found" }) : Results.Ok(product);
});

app.MapPost("/products", async (CreateProductRequest request, IProductService service) =>
{
    var result = await service.CreateAsync(request);
    return result.IsSuccess
        ? Results.Created($"/products/{result.Value!.Id}", result.Value)
        : Results.BadRequest(new { errors = result.Errors });
});

app.MapGet("/products/{id:guid}/price", async (Guid id, IProductService service) =>
{
    var result = await service.CalculatePriceAsync(id);
    return result.IsSuccess ? Results.Ok(result.Value) : Results.NotFound(new { errors = result.Errors });
});

app.Run("http://localhost:5000");
