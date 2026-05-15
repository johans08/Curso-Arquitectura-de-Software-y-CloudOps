using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>() ?? new JwtOptions();
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Secret));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt.Issuer,
            ValidAudience = jwt.Audience,
            IssuerSigningKey = key,
            ClockSkew = TimeSpan.FromMinutes(1)
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("CanReadReports", policy => policy.RequireClaim("scope", "reports.read"));
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

var users = new[]
{
    new AppUser("admin", "admin123", "Admin", ["reports.read", "reports.write"]),
    new AppUser("student", "student123", "User", ["reports.read"])
};

app.MapPost("/auth/login", (LoginRequest request) =>
{
    var user = users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);
    if (user is null)
        return Results.Unauthorized();

    var claims = new List<Claim>
    {
        new(JwtRegisteredClaimNames.Sub, user.Username),
        new(ClaimTypes.Name, user.Username),
        new(ClaimTypes.Role, user.Role)
    };

    claims.AddRange(user.Scopes.Select(scope => new Claim("scope", scope)));

    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(jwt.Issuer, jwt.Audience, claims, expires: DateTime.UtcNow.AddMinutes(30), signingCredentials: credentials);
    var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

    return Results.Ok(new { accessToken, tokenType = "Bearer", expiresInMinutes = 30 });
});

app.MapGet("/me", (ClaimsPrincipal user) => Results.Ok(new
{
    name = user.Identity?.Name,
    role = user.FindFirstValue(ClaimTypes.Role),
    scopes = user.FindAll("scope").Select(c => c.Value)
})).RequireAuthorization();

app.MapGet("/admin/dashboard", () => Results.Ok(new { message = "Admin dashboard" }))
    .RequireAuthorization("AdminOnly");

app.MapGet("/reports", () => Results.Ok(new[] { "architecture-report", "security-report" }))
    .RequireAuthorization("CanReadReports");

app.Run("http://localhost:5000");

public sealed record LoginRequest(string Username, string Password);
public sealed record AppUser(string Username, string Password, string Role, string[] Scopes);

public sealed class JwtOptions
{
    public string Issuer { get; set; } = "SecurityLab";
    public string Audience { get; set; } = "SecurityLab.Client";
    public string Secret { get; set; } = "CHANGE_THIS_SECRET_TO_A_LONG_RANDOM_VALUE_123456789";
}
