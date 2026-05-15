app.MapPost("/api/courses", async (CreateCourseRequest request) =>
{
    // Caso de uso omitido para mantener el ejemplo enfocado.
    return Results.Created("/api/courses/123", new { Id = Guid.NewGuid() });
})
.WithTags("Courses")
.WithSummary("Crea un curso")
.WithDescription("Crea un curso en estado borrador. Requiere rol Instructor o Admin.")
.Produces(StatusCodes.Status201Created)
.ProducesProblem(StatusCodes.Status400BadRequest)
.ProducesProblem(StatusCodes.Status409Conflict)
.RequireAuthorization("InstructorOnly");
