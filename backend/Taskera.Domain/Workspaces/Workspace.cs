using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces.Events;

namespace Taskera.Domain.Workspaces
{
    public sealed class Workspace : AggregateRoot
    {
        public WorkspaceId Id { get; set; }
        public string Name { get; set; }

        private readonly List<WorkspaceMember> _members = new();
        public IReadOnlyCollection<WorkspaceMember> Members => _members.AsReadOnly();

        private Workspace(WorkspaceId id, string name)
        {
            Id = id;
            Name = name;
            AddDomainEvents(new WorkspaceCreatedEvent(this));
        }
        public static Workspace Create(string name)
        {
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            return new Workspace(WorkspaceId.New(), name);
        }
        public void AddMember(UserId userId, TeamRole role)
        {
            if (_members.Any(x => x.UserId == userId))
                throw new InvalidOperationException("User already exists in workspace.");

            var member = new WorkspaceMember(userId, role);
            _members.Add(member);
            AddDomainEvents(new MemberAddedEvent(this, member));
        }
        public void RemoveMember(UserId userId)
        {
            var member = _members.FirstOrDefault(x => x.UserId == userId);
            if (member == null)
                throw new InvalidOperationException("User not found.");

            _members.Remove(member);
        }
        public void Rename(string newName)
        {
            Guard.AgainstNullOrWhiteSpace(newName, nameof(newName));
            Name = newName;
        }
    }
}
