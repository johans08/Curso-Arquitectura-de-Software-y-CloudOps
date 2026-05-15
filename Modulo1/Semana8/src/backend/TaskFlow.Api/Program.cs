using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TaskFlow.Api.Data;
using TaskFlow.Api.Events;
using TaskFlow.Api.Modules.Auth;
using TaskFlow.Api.Modules.Tasks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskFlowDbContext>(options => options.UseSqlite("Data Source=taskflow.db"));
builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();
builder.Services.AddHostedService<TaskCreatedConsumer>();

var jwtSecret = "TASKFLOW_SECRET_CHANGE_ME_123456789_123456789";
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = "TaskFlow",
            ValidAudience = "TaskFlow.Web",
            IssuerSigningKey = key
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", p => p.RequireRole("Admin"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskFlow API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese: Bearer {token}"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskFlowDbContext>();
    db.Database.EnsureCreated();
}

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok(new { status = "ok", app = "TaskFlow" }));

app.MapPost("/auth/login", (LoginRequest request) =>
{
    var user = AuthUsers.Find(request.Username, request.Password);
    if (user is null) return Results.Unauthorized();

    var claims = new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Role)
    };

    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken("TaskFlow", "TaskFlow.Web", claims, expires: DateTime.UtcNow.AddHours(2), signingCredentials: credentials);
    return Results.Ok(new { accessToken = new JwtSecurityTokenHandler().WriteToken(token), user.Username, user.Role });
});

var tasks = app.MapGroup("/api/v1/tasks").RequireAuthorization().WithTags("Tasks");

tasks.MapGet("/", async (TaskFlowDbContext db, ClaimsPrincipal user) =>
{
    var username = user.Identity?.Name ?? "unknown";
    var items = await db.Tasks.Where(t => t.Owner == username).ToListAsync();
    return Results.Ok(items);
});

tasks.MapPost("/", async (CreateTaskRequest request, TaskFlowDbContext db, ClaimsPrincipal user, IEventBus eventBus) =>
{
    if (string.IsNullOrWhiteSpace(request.Title))
        return Results.BadRequest(new { message = "Title is required" });

    var username = user.Identity?.Name ?? "unknown";
    var item = new TaskItem
    {
        Id = Guid.NewGuid(),
        Title = request.Title.Trim(),
        Description = request.Description.Trim(),
        Status = "Pending",
        Owner = username,
        CreatedAt = DateTimeOffset.UtcNow
    };

    db.Tasks.Add(item);
    await db.SaveChangesAsync();
    await eventBus.PublishAsync(new TaskCreatedEvent(Guid.NewGuid(), item.Id, item.Owner, item.Title));

    return Results.Created($"/api/v1/tasks/{item.Id}", item);
});

tasks.MapPatch("/{id:guid}/complete", async (Guid id, TaskFlowDbContext db, ClaimsPrincipal user) =>
{
    var username = user.Identity?.Name ?? "unknown";
    var item = await db.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.Owner == username);
    if (item is null) return Results.NotFound();

    item.Status = "Completed";
    await db.SaveChangesAsync();
    return Results.Ok(item);
});

app.Run("http://localhost:5000");
