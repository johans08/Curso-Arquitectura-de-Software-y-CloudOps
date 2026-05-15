namespace Inventory.Api.Models;

public sealed class OperationResult<T>
{
    public bool IsSuccess { get; private init; }
    public T? Value { get; private init; }
    public IReadOnlyList<string> Errors { get; private init; } = Array.Empty<string>();

    public static OperationResult<T> Success(T value) => new() { IsSuccess = true, Value = value };
    public static OperationResult<T> Failure(params string[] errors) => new() { IsSuccess = false, Errors = errors };
}
