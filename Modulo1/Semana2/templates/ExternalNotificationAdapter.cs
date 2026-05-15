public interface INotificationSender
{
    Task SendAsync(Notification notification);
}

// Adapter: oculta el detalle externo detrás de una interfaz propia.
public sealed class ConsoleNotificationAdapter : INotificationSender
{
    public Task SendAsync(Notification notification)
    {
        Console.WriteLine($"Para: {notification.Recipient}");
        Console.WriteLine($"Asunto: {notification.Subject}");
        Console.WriteLine(notification.Body);

        return Task.CompletedTask;
    }
}
