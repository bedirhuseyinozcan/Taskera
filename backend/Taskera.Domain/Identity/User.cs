using Taskera.Domain.Common;

namespace Taskera.Domain.Identity;

public sealed class User : AggregateRoot
{
    public UserId Id { get; private set; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public bool IsActive { get; private set; }

    private User() { } // EF Core için

    public static User Create(string email, string firstName, string lastName)
    {
        return new User(UserId.New(), email, firstName, lastName);
    }

    private User(UserId id, string email, string firstName, string lastName)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        IsActive = true;
    }
}