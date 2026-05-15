namespace CloudOps.Domain.Entities;

public sealed class Customer
{
    private Customer() { }

    public Customer(string fullName, string email)
    {
        if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Full name is required.", nameof(fullName));
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email is required.", nameof(email));

        Id = Guid.NewGuid();
        FullName = fullName.Trim();
        Email = email.Trim().ToLowerInvariant();
        CreatedAtUtc = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public DateTime CreatedAtUtc { get; private set; }
}
