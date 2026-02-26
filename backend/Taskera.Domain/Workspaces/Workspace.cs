using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces.Events;

namespace Taskera.Domain.Workspaces
{
    public sealed class Workspace : AggregateRoot
    {
        public WorkspaceId WorkspaceId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        private readonly List<WorkspaceMember> _members = new();
        public IReadOnlyCollection<WorkspaceMember> Members => _members.AsReadOnly();
        private Workspace() { }
        private Workspace(WorkspaceId workspaceId, string name, string? description)
        {
            WorkspaceId = workspaceId;
            Name = name;
            Description = description;
            AddDomainEvent(new WorkspaceCreatedEvent(workspaceId, Name));
        }
        public static Workspace Create(string name, UserId ownerId, string? description = null)
        {
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            var workspace = new Workspace(WorkspaceId.New(), name, description);
            workspace.AddMember(ownerId, TeamRole.Owner);
            return workspace;
        }
        public void AddMember(UserId userId, TeamRole role)
        {
            if (IsDeleted) 
                throw new InvalidOperationException("Silinmiş bir çalışma alanı üzerinde işlem yapılamaz.");

            if (_members.Any(x => x.UserId == userId))
                throw new InvalidOperationException("User already exists in workspace.");

            var member = new WorkspaceMember(this.WorkspaceId, userId, role);
            _members.Add(member);

            AddDomainEvent(new MemberAddedEvent(WorkspaceId, userId, role));
        }
        public void RemoveMember(UserId userId)
        {
            var member = _members.FirstOrDefault(x => x.UserId == userId);
            if (member == null)
                throw new InvalidOperationException("User not found.");

            if (member.Role == TeamRole.Owner && _members.Count(x => x.Role == TeamRole.Owner) <= 1)
                throw new InvalidOperationException("Workspace must have at least one owner.");

            _members.Remove(member);
            AddDomainEvent(new MemberRemovedEvent(WorkspaceId, userId));
        }
        public void UpdateName(string newName)
        {
            if (IsDeleted) 
                throw new InvalidOperationException("Silinmiş bir çalışma alanı üzerinde işlem yapılamaz.");

            Guard.AgainstNullOrWhiteSpace(newName, nameof(newName));
            Name = newName;
        }
        public void UpdateDescription(string? description = null)
        {
            Description = description;
        }

        public void DeleteWorkspace()
        {
            if (IsDeleted) 
                throw new InvalidOperationException("Silinmiş bir çalışma alanı üzerinde işlem yapılamaz.");

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            AddDomainEvent(new WorkspaceDeletedEvent(WorkspaceId));
        }
    }
}
