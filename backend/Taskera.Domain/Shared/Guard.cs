using System.Runtime.CompilerServices;

namespace Taskera.Domain.Shared
{
    public static class Guard
    {
        public static void AgainstNull(object? value,[CallerArgumentExpression("value")] string? name = null)
        {
            if (value is null)
                throw new ArgumentException(name);
        }
        public static void AgainstNullOrWhiteSpace(string? value, [CallerArgumentExpression("value")] string? name = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{name} cannot be empty.", name);
        }
        public static void AgainstNegativeOrZero(int value, [CallerArgumentExpression("value")] string? name = null)
        {
            if (value <= 0)
                throw new ArgumentException($"{name} must be greater than zero.");
        }
        public static void AgainstLength(string? value, int maxLength, [CallerArgumentExpression("value")] string? name = null)
        {
            if (value?.Length > maxLength)
                throw new ArgumentException($"{name} cannot exceed {maxLength} characters.", name);
        }
    }

}
