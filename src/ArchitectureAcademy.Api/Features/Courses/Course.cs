using ArchitectureAcademy.SharedKernel;

namespace ArchitectureAcademy.Api.Features.Courses;

public sealed class Course : Entity
{
    private Course()
    {
        Code = string.Empty;
        Name = string.Empty;
        Description = string.Empty;
        Status = CourseStatus.Draft;
    }

    public Course(string code, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("El código del curso es obligatorio.", nameof(code));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del curso es obligatorio.", nameof(name));

        Code = code.Trim().ToUpperInvariant();
        Name = name.Trim();
        Description = description.Trim();
        Status = CourseStatus.Draft;

        AddDomainEvent(new CourseCreatedEvent(Id, Code));
    }

    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Status { get; private set; }

    public void Publish()
    {
        if (Status == CourseStatus.Published)
            return;

        Status = CourseStatus.Published;
        MarkUpdated();
    }
}

public static class CourseStatus
{
    public const string Draft = "Draft";
    public const string Published = "Published";
}

public sealed record CourseCreatedEvent(Guid CourseId, string Code) : IDomainEvent
{
    public Guid EventId { get; } = Guid.NewGuid();
    public DateTimeOffset OccurredAt { get; } = DateTimeOffset.UtcNow;
}
