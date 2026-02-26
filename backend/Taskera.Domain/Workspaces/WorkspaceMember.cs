using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Workspaces;

public class WorkspaceMember : Entity
{
    private WorkspaceMember() { } 
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

    public override bool Equals(object? obj)
    {
        if (obj is not WorkspaceMember other) return false;
        return WorkspaceId == other.WorkspaceId && UserId == other.UserId;
    }

    public override int GetHashCode() => HashCode.Combine(WorkspaceId, UserId);
}