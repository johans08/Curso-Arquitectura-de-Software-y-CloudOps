public sealed class Course
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Status { get; private set; } = "Draft";

    public Course(string code, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("El código es obligatorio.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre es obligatorio.");

        Code = code.Trim().ToUpperInvariant();
        Name = name.Trim();
        Description = description.Trim();
    }

    public void Publish()
    {
        if (Status == "Published")
            return;

        Status = "Published";
    }
}
