namespace PatternsLab.Creational;

public interface INotificationSender
{
    void Send(string message);
}

public sealed class EmailSender : INotificationSender
{
    public void Send(string message) => Console.WriteLine($"EMAIL sent: {message}");
}

public sealed class SmsSender : INotificationSender
{
    public void Send(string message) => Console.WriteLine($"SMS sent: {message}");
}

public sealed class NotificationFactory
{
    public INotificationSender Create(string channel) => channel.ToLowerInvariant() switch
    {
        "email" => new EmailSender(),
        "sms" => new SmsSender(),
        _ => throw new ArgumentException($"Unsupported channel: {channel}")
    };
}
