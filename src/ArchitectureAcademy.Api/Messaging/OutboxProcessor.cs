using ArchitectureAcademy.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureAcademy.Api.Messaging;

public sealed class OutboxProcessor(
    IServiceScopeFactory scopeFactory,
    ILogger<OutboxProcessor> logger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await ProcessPendingMessages(stoppingToken);
            await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
        }
    }

    private async Task ProcessPendingMessages(CancellationToken cancellationToken)
    {
        using var scope = scopeFactory.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AcademyDbContext>();

        var messages = await db.OutboxMessages
            .Where(x => x.ProcessedAt == null)
            .OrderBy(x => x.OccurredAt)
            .Take(20)
            .ToListAsync(cancellationToken);

        foreach (var message in messages)
        {
            try
            {
                logger.LogInformation("Procesando evento Outbox {Type}: {Payload}", message.Type, message.Payload);

                // Aquí se conectaría un adaptador real:
                // - Email
                // - Webhook
                // - SignalR
                // - Broker externo en módulos posteriores

                message.MarkProcessed();
            }
            catch (Exception ex)
            {
                message.MarkFailed(ex.Message);
                logger.LogError(ex, "Error procesando evento Outbox {MessageId}", message.Id);
            }
        }

        await db.SaveChangesAsync(cancellationToken);
    }
}
