using Taskera.Domain.Common;

namespace Taskera.Domain.Workspaces.Events
{
    public sealed record WorkspaceDeletedEvent(WorkspaceId WorkspaceId) : IDomainEvent
    {
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}