using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CloudOps.Application.DTOs;
using CloudOps.Application.Services;
using CloudOps.Infrastructure;
using CloudOps.Infrastructure.Workers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddHostedService<OutboxProcessor>();

var jwtSection = builder.Configuration.GetSection("Jwt");
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["SigningKey"]!));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidAudience = jwtSection["Audience"],
            IssuerSigningKey = signingKey
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanWrite", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/api/auth/login", (LoginRequest request) =>
{
    // Plantilla académica: reemplazar por validación real de usuarios.
    var role = request.Email.Contains("admin", StringComparison.OrdinalIgnoreCase) ? "Admin" : "Student";
    var claims = new List<Claim>
    {
        new(JwtRegisteredClaimNames.Sub, request.Email),
        new(ClaimTypes.Name, request.Email),
        new(ClaimTypes.Role, role)
    };

    var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        issuer: jwtSection["Issuer"],
        audience: jwtSection["Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddHours(2),
        signingCredentials: credentials);

    return Results.Ok(new { access_token = new JwtSecurityTokenHandler().WriteToken(token), role });
}).WithTags("Auth");

app.MapGet("/api/products", async (ProductService service, CancellationToken ct) =>
    Results.Ok(await service.ListAsync(ct)))
    .WithTags("Products")
    .RequireAuthorization();

app.MapPost("/api/products", async (CreateProductRequest request, ProductService service, CancellationToken ct) =>
    Results.Created("/api/products", await service.CreateAsync(request, ct)))
    .WithTags("Products")
    .RequireAuthorization("CanWrite");

app.MapPost("/api/orders", async (CreateOrderRequest request, OrderService service, CancellationToken ct) =>
    Results.Created("/api/orders", await service.CreateAsync(request, ct)))
    .WithTags("Orders")
    .RequireAuthorization();

app.Run();

public sealed record LoginRequest(string Email, string Password);
