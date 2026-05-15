namespace ProfessionalApi.Api.Contracts;

public sealed record CreateTicketRequest(string Title, string Description, string Priority);
public sealed record TicketResponse(Guid Id, string Title, string Description, string Priority, string Status, DateTimeOffset CreatedAt);
public sealed record ApiError(string Code, string Message);

public sealed class TicketStore
{
    private readonly List<TicketResponse> _tickets = [];

    public IReadOnlyList<TicketResponse> GetAll() => _tickets;

    public TicketResponse? GetById(Guid id) => _tickets.FirstOrDefault(t => t.Id == id);

    public TicketResponse Create(CreateTicketRequest request)
    {
        var ticket = new TicketResponse(
            Guid.NewGuid(),
            request.Title.Trim(),
            request.Description.Trim(),
            string.IsNullOrWhiteSpace(request.Priority) ? "Medium" : request.Priority.Trim(),
            "Open",
            DateTimeOffset.UtcNow);

        _tickets.Add(ticket);
        return ticket;
    }
}
