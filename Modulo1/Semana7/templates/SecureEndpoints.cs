app.MapPost("/api/courses", CreateCourse)
   .RequireAuthorization("InstructorOnly");

app.MapDelete("/api/courses/{id}", DeleteCourse)
   .RequireAuthorization("AdminOnly");

app.MapGet("/api/my-courses", GetMyCourses)
   .RequireAuthorization("StudentReadAccess");
