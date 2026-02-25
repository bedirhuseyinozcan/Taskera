using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Workspaces.Events;
public sealed class MemberRemovedEvent : IDomainEvent
{
    public WorkspaceId WorkspaceId { get; }
    public UserId UserId { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public MemberRemovedEvent(WorkspaceId workspaceId, UserId userId)
    {
        WorkspaceId = workspaceId;
        UserId = userId;
    }
}