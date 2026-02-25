using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces.Events;

namespace Taskera.Domain.Workspaces
{
    public sealed class Workspace : AggregateRoot
    {
        public WorkspaceId Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }

        private readonly List<WorkspaceMember> _members = new();
        public IReadOnlyCollection<WorkspaceMember> Members => _members.AsReadOnly();

        private Workspace(WorkspaceId id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
            AddDomainEvent(new WorkspaceCreatedEvent(Id, Name, Description));
        }
        public static Workspace Create(string name, string? description = null)
        {
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            return new Workspace(WorkspaceId.New(), name, description);
        }
        public void AddMember(UserId userId, TeamRole role)
        {
            if (_members.Any(x => x.UserId == userId))
                throw new InvalidOperationException("User already exists in workspace.");

            var member = new WorkspaceMember(userId, role);
            _members.Add(member);
            AddDomainEvent(new MemberAddedEvent(Id, userId, role));
        }
        public void RemoveMember(UserId userId)
        {
            var member = _members.FirstOrDefault(x => x.UserId == userId);
            if (member == null)
                throw new InvalidOperationException("User not found.");

            _members.Remove(member);
            AddDomainEvent(new MemberRemovedEvent(Id, userId));
        }
        public void UpdateName(string newName)
        {
            Guard.AgainstNullOrWhiteSpace(newName, nameof(newName));
            Name = newName;
            AddDomainEvent(new WorkspaceRenamedEvent(Id, newName));
        }
        public void UpdateDescription(string? description = null)
        {
            Description = description;
            AddDomainEvent(new WorkspaceDescriptionUpdatedEvent(Id, description));
        }

        public void DeleteWorkspace()
        {
            if (IsDeleted)
            {
                throw new InvalidOperationException("Workspace is already deleted.");
            }

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            AddDomainEvent(new WorkspaceDeletedEvent(Id));
        }
    }
}
