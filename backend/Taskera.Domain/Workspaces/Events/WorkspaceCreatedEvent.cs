using Taskera.Domain.Common;

namespace Taskera.Domain.Workspaces.Events
{
    public sealed record WorkspaceCreatedEvent(WorkspaceId WorkspaceId, string Name) : IDomainEvent
    {
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}