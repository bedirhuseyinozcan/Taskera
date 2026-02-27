using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Workspaces;

public sealed class WorkspaceMember : ValueObject
{
    public WorkspaceId WorkspaceId { get; private set; }
    public UserId UserId { get; private set; }
    public TeamRole Role { get; private set; }

    internal WorkspaceMember(WorkspaceId workspaceId, UserId userId, TeamRole role)
    {
        WorkspaceId = workspaceId;
        UserId = userId;
        Role = role;
    }

    internal void ChangeRole(TeamRole role) => Role = role;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return WorkspaceId;
        yield return UserId;
    }
}