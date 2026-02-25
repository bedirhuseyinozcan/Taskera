namespace Taskera.Domain.Shared
{
    public static class Guard
    {
        public static void AgainstNull(object? value, string name)
        {
            if (value is null)
                throw new ArgumentNullException(name);
        }
        public static void AgainstNullOrWhiteSpace(string? value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{name} cannot be empty.", name);
        }
        public static void AgainstNegativeOrZero(int value, string name)
        {
            if (value <= 0)
                throw new ArgumentException($"{name} must be greater than zero.");
        }
    }

}
