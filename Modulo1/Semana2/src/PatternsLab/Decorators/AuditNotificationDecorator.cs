using PatternsLab.Creational;

namespace PatternsLab.Decorators;

public sealed class AuditNotificationDecorator(INotificationSender inner) : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"AUDIT before notification: {DateTimeOffset.UtcNow:O}");
        inner.Send(message);
        Console.WriteLine("AUDIT after notification: success");
    }
}
