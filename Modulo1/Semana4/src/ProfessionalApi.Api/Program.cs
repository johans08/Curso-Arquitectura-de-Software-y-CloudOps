using Microsoft.OpenApi.Models;
using ProfessionalApi.Api.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Professional Tickets API",
        Version = "v1",
        Description = "API de ejemplo para diseño profesional con Swagger/OpenAPI."
    });
});

builder.Services.AddSingleton<TicketStore>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var group = app.MapGroup("/api/v1/tickets")
    .WithTags("Tickets")
    .WithOpenApi();

group.MapGet("/", (TicketStore store) => Results.Ok(store.GetAll()))
    .WithSummary("Lista tickets")
    .WithDescription("Obtiene todos los tickets registrados en memoria.")
    .Produces<IReadOnlyList<TicketResponse>>(StatusCodes.Status200OK);

group.MapPost("/", (CreateTicketRequest request, TicketStore store) =>
{
    if (string.IsNullOrWhiteSpace(request.Title))
        return Results.BadRequest(new ApiError("VALIDATION_ERROR", "Title is required"));

    var ticket = store.Create(request);
    return Results.Created($"/api/v1/tickets/{ticket.Id}", ticket);
})
.WithSummary("Crea un ticket")
.WithDescription("Registra un nuevo ticket y responde con 201 Created.")
.Produces<TicketResponse>(StatusCodes.Status201Created)
.Produces<ApiError>(StatusCodes.Status400BadRequest);

group.MapGet("/{id:guid}", (Guid id, TicketStore store) =>
{
    var ticket = store.GetById(id);
    return ticket is null ? Results.NotFound(new ApiError("NOT_FOUND", "Ticket not found")) : Results.Ok(ticket);
})
.WithSummary("Obtiene un ticket por ID")
.Produces<TicketResponse>(StatusCodes.Status200OK)
.Produces<ApiError>(StatusCodes.Status404NotFound);

app.MapGet("/health", () => Results.Ok(new { status = "ok" })).ExcludeFromDescription();

app.Run("http://localhost:5000");
