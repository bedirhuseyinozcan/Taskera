using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Workspaces.Events;
public sealed record MemberAddedEvent(WorkspaceId WorkspaceId, UserId UserId, TeamRole Role) : IDomainEvent
{
    public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
}