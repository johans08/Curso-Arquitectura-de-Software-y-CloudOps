public static IResult ConflictError(string code, string message, HttpContext context)
{
    return Results.Conflict(new
    {
        Code = code,
        Message = message,
        TraceId = context.TraceIdentifier
    });
}
