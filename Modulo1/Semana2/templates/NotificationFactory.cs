public sealed record Notification(string Subject, string Body, string Recipient);

public static class NotificationFactory
{
    public static Notification CoursePublished(string courseName, string instructorEmail)
    {
        return new Notification(
            Subject: $"Curso publicado: {courseName}",
            Body: $"El curso {courseName} ya está disponible para estudiantes.",
            Recipient: instructorEmail);
    }
}
