using Taskera.Domain.Common;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Identity;

public sealed class User : AggregateRoot<UserId>
{
    public string Email { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public bool IsActive { get; private set; }

    private User() { } // EF Core için
    private User(UserId id, string email, string firstName, string lastName) : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        IsActive = true;
    }
    public static User Create(string email, string firstName, string lastName)
    {
        Guard.AgainstNullOrWhiteSpace(email);
        Guard.AgainstNullOrWhiteSpace(firstName);
        Guard.AgainstNullOrWhiteSpace(lastName);
        Guard.AgainstLength(firstName, 50);
        Guard.AgainstLength(lastName, 50);

        return new User(UserId.New(), email, firstName, lastName);
    }
    public void UpdateProfile(string firstName, string lastName)
    {
        Guard.AgainstNullOrWhiteSpace(firstName);
        Guard.AgainstNullOrWhiteSpace(lastName);

        FirstName = firstName;
        LastName = lastName;
    }
}