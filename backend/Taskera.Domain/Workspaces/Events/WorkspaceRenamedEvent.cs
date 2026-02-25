using Taskera.Domain.Common;

namespace Taskera.Domain.Workspaces.Events
{
    public sealed class WorkspaceRenamedEvent : IDomainEvent
    {
        public WorkspaceId WorkspaceId { get; }
        public string NewName { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public WorkspaceRenamedEvent(WorkspaceId workspaceId, string newName)
        {
            WorkspaceId = workspaceId;
            NewName = newName;
        }
    }
}