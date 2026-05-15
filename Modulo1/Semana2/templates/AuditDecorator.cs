public interface ICommandHandler<TCommand>
{
    Task HandleAsync(TCommand command);
}

public sealed class AuditCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
{
    private readonly ICommandHandler<TCommand> _inner;
    private readonly ILogger<AuditCommandHandlerDecorator<TCommand>> _logger;

    public AuditCommandHandlerDecorator(
        ICommandHandler<TCommand> inner,
        ILogger<AuditCommandHandlerDecorator<TCommand>> logger)
    {
        _inner = inner;
        _logger = logger;
    }

    public async Task HandleAsync(TCommand command)
    {
        _logger.LogInformation("Ejecutando comando {Command}", typeof(TCommand).Name);
        await _inner.HandleAsync(command);
        _logger.LogInformation("Comando {Command} ejecutado correctamente", typeof(TCommand).Name);
    }
}
