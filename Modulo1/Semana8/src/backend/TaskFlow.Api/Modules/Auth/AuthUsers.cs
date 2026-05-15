namespace TaskFlow.Api.Modules.Auth;

public sealed record LoginRequest(string Username, string Password);
public sealed record DemoUser(string Username, string Password, string Role);

public static class AuthUsers
{
    private static readonly DemoUser[] Users =
    [
        new("admin", "admin123", "Admin"),
        new("student", "student123", "User")
    ];

    public static DemoUser? Find(string username, string password)
    {
        return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}
