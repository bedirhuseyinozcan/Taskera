using Taskera.Domain.Shared.Enums;

namespace Taskera.Domain.Shared;

public sealed record Error(string Code, string Message, ErrorType Type)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided", ErrorType.Failure);

    public static Error NotFound(string name) =>
        new("NotFound", $"{name} was not found.", ErrorType.NotFound);

    public static Error Validation(string message) =>
        new("Validation", message, ErrorType.Validation);

    public static Error Conflict(string message) =>
        new("Conflict", message, ErrorType.Conflict);
}