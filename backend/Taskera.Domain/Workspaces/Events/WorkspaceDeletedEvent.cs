using Taskera.Domain.Common;

namespace Taskera.Domain.Workspaces.Events
{
    public class WorkspaceDeletedEvent : IDomainEvent
    {
        public WorkspaceId WorkspaceId { get; }
        public DateTime OccurredOn {  get; } = DateTime.UtcNow;

        public WorkspaceDeletedEvent(WorkspaceId workspaceId)
        {
            WorkspaceId = workspaceId;
        }
    }
}