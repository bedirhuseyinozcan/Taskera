using Taskera.Domain.Common;

namespace Taskera.Domain.Workspaces.Events
{
    public sealed class WorkspaceDescriptionUpdatedEvent : IDomainEvent
    {
        public WorkspaceId WorkspaceId { get; }
        public string? NewDescription { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public WorkspaceDescriptionUpdatedEvent(WorkspaceId workspaceId, string? newDescription)
        {
            WorkspaceId = workspaceId;
            NewDescription = newDescription;
        }
    }
}