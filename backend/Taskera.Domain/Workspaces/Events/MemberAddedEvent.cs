using Taskera.Domain.Common;

namespace Taskera.Domain.Workspaces.Events
{
    public sealed class MemberAddedEvent : IDomainEvent
    {
        public Workspace Workspace { get; }
        public WorkspaceMember WorkspaceMember { get; }
        public DateTime OccuredOn { get; } = DateTime.UtcNow;

        public MemberAddedEvent(Workspace workspace ,WorkspaceMember workspaceMember)
        {
            Workspace = workspace;
            WorkspaceMember = workspaceMember;
        }
    }
}
