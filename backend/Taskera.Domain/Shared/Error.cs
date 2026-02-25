namespace Taskera.Domain.Shared
{
    public sealed record class Error(string Code, string Message)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        public static Error NullValue(string name) =>
                new("NullValue", $"{name} cannot be null.");
        public static Error NotFound(string name) =>
                new("NotFound", $"{name} was not found.");
        public static Error Validation(string message) =>
                new("Validation", message);
    }
}
