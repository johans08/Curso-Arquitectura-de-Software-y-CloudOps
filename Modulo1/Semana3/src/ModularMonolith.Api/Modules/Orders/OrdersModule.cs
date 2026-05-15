using ModularMonolith.Api.Modules.Catalog;

namespace ModularMonolith.Api.Modules.Orders;

public static class OrdersModule
{
    public static IServiceCollection AddOrdersModule(this IServiceCollection services)
    {
        services.AddSingleton<IOrderService, OrderService>();
        return services;
    }

    public static IEndpointRouteBuilder MapOrdersEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orders").WithTags("Orders");

        group.MapPost("/", (CreateOrderRequest request, IOrderService service) =>
        {
            var result = service.CreateOrder(request);
            return result is null
                ? Results.BadRequest(new { message = "Invalid product" })
                : Results.Created($"/orders/{result.Id}", result);
        });

        group.MapGet("/", (IOrderService service) => Results.Ok(service.GetOrders()));
        return app;
    }
}

public interface IOrderService
{
    Order? CreateOrder(CreateOrderRequest request);
    IReadOnlyList<Order> GetOrders();
}

public sealed class OrderService(ICatalogService catalogService) : IOrderService
{
    private readonly List<Order> _orders = [];

    public Order? CreateOrder(CreateOrderRequest request)
    {
        var product = catalogService.GetProduct(request.ProductId);
        if (product is null) return null;

        var order = new Order(Guid.NewGuid(), product.Id, product.Name, request.Quantity, product.Price * request.Quantity);
        _orders.Add(order);
        return order;
    }

    public IReadOnlyList<Order> GetOrders() => _orders;
}

public sealed record CreateOrderRequest(Guid ProductId, int Quantity);
public sealed record Order(Guid Id, Guid ProductId, string ProductName, int Quantity, decimal Total);
