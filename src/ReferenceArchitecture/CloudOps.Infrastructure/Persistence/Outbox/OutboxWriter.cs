using System.Text.Json;
using CloudOps.Application.Abstractions;

namespace CloudOps.Infrastructure.Persistence.Outbox;

public sealed class OutboxWriter : IOutboxWriter
{
    private readonly AppDbContext _dbContext;

    public OutboxWriter(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync<T>(T message, CancellationToken cancellationToken) where T : notnull
    {
        var outboxMessage = new OutboxMessage
        {
            Id = Guid.NewGuid(),
            OccurredOnUtc = DateTime.UtcNow,
            Type = typeof(T).FullName ?? typeof(T).Name,
            Payload = JsonSerializer.Serialize(message)
        };

        await _dbContext.OutboxMessages.AddAsync(outboxMessage, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
