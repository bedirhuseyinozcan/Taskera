using Taskera.Domain.Common;

namespace Taskera.Domain.Workspaces.Events
{
    public sealed class WorkspaceCreatedEvent : IDomainEvent
    {
        public Workspace Workspace { get; }
        public DateTime OccuredOn { get; } = DateTime.UtcNow;

        public WorkspaceCreatedEvent(Workspace workspace)
        {
            Workspace = workspace;
        }
    }
}
