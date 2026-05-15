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

public sealed record ApiError(
    string Code,
    string Message,
    string TraceId);
