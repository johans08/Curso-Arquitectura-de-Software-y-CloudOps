using ArchitectureAcademy.Api.Data;
using ArchitectureAcademy.Api.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ArchitectureAcademy.Api.Features.Courses;

public static class CourseEndpoints
{
    public static IEndpointRouteBuilder MapCourseEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/courses")
            .WithTags("Courses");

        group.MapGet("/", async (AcademyDbContext db) =>
        {
            var courses = await db.Courses
                .OrderBy(x => x.Code)
                .Select(x => new CourseResponse(x.Id, x.Code, x.Name, x.Description, x.Status))
                .ToListAsync();

            return Results.Ok(courses);
        })
        .WithSummary("Obtiene cursos")
        .WithDescription("Devuelve la lista de cursos registrados en la plataforma.");

        group.MapPost("/", async (CreateCourseRequest request, AcademyDbContext db) =>
        {
            var exists = await db.Courses.AnyAsync(x => x.Code == request.Code);

            if (exists)
            {
                return Results.Conflict(new
                {
                    Error = "course_code_already_exists",
                    Message = "Ya existe un curso con ese código."
                });
            }

            var course = new Course(request.Code, request.Name, request.Description);

            db.Courses.Add(course);
            db.OutboxMessages.Add(new OutboxMessage(
                type: "CourseCreated",
                payload: JsonSerializer.Serialize(new
                {
                    course.Id,
                    course.Code,
                    course.Name
                })));

            await db.SaveChangesAsync();

            var response = new CourseResponse(course.Id, course.Code, course.Name, course.Description, course.Status);

            return Results.Created($"/api/courses/{course.Id}", response);
        })
        .RequireAuthorization("InstructorOnly")
        .WithSummary("Crea un curso")
        .WithDescription("Registra un curso en estado Draft y genera un evento Outbox.");

        return app;
    }
}
