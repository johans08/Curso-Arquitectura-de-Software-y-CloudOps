using ModularMonolith.Api.Modules.Catalog;
using ModularMonolith.Api.Modules.Orders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatalogModule();
builder.Services.AddOrdersModule();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok", style = "modular-monolith" }));
app.MapCatalogEndpoints();
app.MapOrdersEndpoints();

app.Run("http://localhost:5000");
