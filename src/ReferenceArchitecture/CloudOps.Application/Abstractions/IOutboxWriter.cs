namespace CloudOps.Application.Abstractions;

public interface IOutboxWriter
{
    Task AddAsync<T>(T message, CancellationToken cancellationToken) where T : notnull;
}
