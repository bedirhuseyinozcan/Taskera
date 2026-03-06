using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Identity.Enums;

namespace Taskera.Domain.Workspaces;
public sealed class WorkspaceMember : ValueObject
{
    public UserId UserId { get; private set; }
    public TeamRole Role { get; private set; }

    internal WorkspaceMember( UserId userId, TeamRole role)
    {
        UserId = userId;
        Role = role;
    }

    internal void ChangeRole(TeamRole role) => Role = role;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return UserId;
        yield return Role;
    }
}