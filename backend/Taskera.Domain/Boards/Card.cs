using System.Net.Mail;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Taskera.Domain.Boards.Events;
using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class Card : Entity<CardId>
    {
        public string Title { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public DateTime? Deadline { get; private set; }

        private readonly List<UserId> _assignedTo = new();
        public IReadOnlyCollection<UserId> AssignedTo => _assignedTo.AsReadOnly();

        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

        private readonly List<ChecklistItem> _checklist = new();
        public IReadOnlyCollection<ChecklistItem> Checklist => _checklist.AsReadOnly();

        private Card() { }
        internal Card(CardId id, string title, string description) : base(id)
        {
            Guard.AgainstNullOrWhiteSpace(title, nameof(title));
            Title = title;
            Description = description;
        }
        internal void UpdateTitle(string title)
        {
            Guard.AgainstNullOrWhiteSpace(title, nameof(title));
            Title = title;
        }
        internal void UpdateDescription(string description)
        {
            Description = description;
        }
        internal void Assign(List<UserId> userIds)
        {
            _assignedTo.Clear();
            if (userIds != null)
            {
                _assignedTo.AddRange(userIds);
            }
        }
        public void AddComment(UserId author, string content)
        {
            var comment = new Comment(CommentId.New(), author, content);
            _comments.Add(comment);
            AddDomainEvent(new CommentAddedEvent(this.Id, author, content));
        }
        internal void SetDeadline(DateTime? deadline)
        {
            Deadline = deadline;
        }
        internal void AddChecklistItem(string title)
        {
            var item = new ChecklistItem(ChecklistItemId.New(), title);
            _checklist.Add(item);
        }
    }
}