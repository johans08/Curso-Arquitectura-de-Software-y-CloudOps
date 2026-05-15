using DataStrategyLab.Api.Documents;
using DataStrategyLab.Api.Sql;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogDbContext>(options => options.UseSqlite("Data Source=catalog.db"));
builder.Services.AddSingleton<IDocumentStore<UserProfileDocument>, JsonDocumentStore<UserProfileDocument>>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();
    db.Database.EnsureCreated();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok", data = "sql-nosql" }));

app.MapPost("/sql/products", async (CreateProductRequest request, CatalogDbContext db) =>
{
    var product = new ProductEntity { Name = request.Name, Price = request.Price, Category = request.Category };
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Created($"/sql/products/{product.Id}", product);
});

app.MapGet("/sql/products", async (CatalogDbContext db) => Results.Ok(await db.Products.ToListAsync()));

app.MapPost("/nosql/profiles", async (UserProfileDocument profile, IDocumentStore<UserProfileDocument> store) =>
{
    var id = string.IsNullOrWhiteSpace(profile.Id) ? Guid.NewGuid().ToString("N") : profile.Id;
    var document = profile with { Id = id };
    await store.UpsertAsync(id, document);
    return Results.Created($"/nosql/profiles/{id}", document);
});

app.MapGet("/nosql/profiles/{id}", async (string id, IDocumentStore<UserProfileDocument> store) =>
{
    var document = await store.GetAsync(id);
    return document is null ? Results.NotFound() : Results.Ok(document);
});

app.Run("http://localhost:5000");

public sealed record CreateProductRequest(string Name, decimal Price, string Category);
