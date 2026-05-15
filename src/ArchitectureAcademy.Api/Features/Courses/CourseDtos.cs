namespace ArchitectureAcademy.Api.Features.Courses;

public sealed record CreateCourseRequest(
    string Code,
    string Name,
    string Description);

public sealed record CourseResponse(
    Guid Id,
    string Code,
    string Name,
    string Description,
    string Status);
