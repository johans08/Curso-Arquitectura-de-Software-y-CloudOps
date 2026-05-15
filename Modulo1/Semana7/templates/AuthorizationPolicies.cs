builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));

    options.AddPolicy("InstructorOnly", policy =>
        policy.RequireRole("Instructor", "Admin"));

    options.AddPolicy("StudentReadAccess", policy =>
        policy.RequireRole("Student", "Instructor", "Admin"));
});
