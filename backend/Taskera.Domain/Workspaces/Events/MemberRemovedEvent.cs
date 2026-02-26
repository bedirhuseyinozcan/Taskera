using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Workspaces.Events;
public sealed record MemberRemovedEvent(WorkspaceId WorkspaceId, UserId UserId) : IDomainEvent
{
    public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
}