public sealed class CreateCourseUseCase
{
    private readonly ICourseRepository _repository;

    public CreateCourseUseCase(ICourseRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> ExecuteAsync(CreateCourseCommand command)
    {
        var exists = await _repository.ExistsByCodeAsync(command.Code);

        if (exists)
            throw new InvalidOperationException("Ya existe un curso con ese código.");

        var course = new Course(command.Code, command.Name, command.Description);

        await _repository.AddAsync(course);

        return course.Id;
    }
}

public sealed record CreateCourseCommand(string Code, string Name, string Description);

public interface ICourseRepository
{
    Task<bool> ExistsByCodeAsync(string code);
    Task AddAsync(Course course);
}
