using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Identity.Enums;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces.Events;

namespace Taskera.Domain.Workspaces
{
    public sealed class Workspace : AggregateRoot<WorkspaceId>
    {
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }

        private readonly List<WorkspaceMember> _members = new();
        public IReadOnlyCollection<WorkspaceMember> Members => _members.AsReadOnly();
        private Workspace() { }
        private Workspace(WorkspaceId id, string name, string? description) : base(id)
        {
            Name = name;
            Description = description;
            AddDomainEvent(new WorkspaceCreatedEvent(Id, Name));
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
            CheckIfDeleted();

            if (_members.Any(x => x.UserId == userId))
                throw new InvalidOperationException("User already exists in workspace.");

            var member = new WorkspaceMember(userId, role);
            _members.Add(member);

            AddDomainEvent(new MemberAddedEvent(Id, userId, role));
        }
        public void RemoveMember(UserId userId)
        {
            CheckIfDeleted();

            var member = _members.FirstOrDefault(x => x.UserId == userId);
            if (member == null)
                throw new InvalidOperationException("User not found.");

            if (member.Role == TeamRole.Owner && _members.Count(x => x.Role == TeamRole.Owner) <= 1)
                throw new InvalidOperationException("Workspace must have at least one owner.");

            _members.Remove(member);
            AddDomainEvent(new MemberRemovedEvent(Id, userId));
        }
        public void ChangeMemberRole(UserId userId, TeamRole newRole)
        {
            CheckIfDeleted();
            var member = _members.FirstOrDefault(x => x.UserId == userId);
            if (member == null) throw new InvalidOperationException("User not found.");

            member.ChangeRole(newRole);
        }
        public void UpdateName(string newName)
        {
            CheckIfDeleted();

            Guard.AgainstNullOrWhiteSpace(newName, nameof(newName));
            Name = newName;
        }
        public void UpdateDescription(string? description = null)
        {
            CheckIfDeleted();

            Description = description;
        }

        public void DeleteWorkspace()
        {
            CheckIfDeleted();

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            AddDomainEvent(new WorkspaceDeletedEvent(Id));
        }

        private void CheckIfDeleted()
        {
            if (IsDeleted)
                throw new InvalidOperationException("Workspace is already deleted.");
        }
    }
}
