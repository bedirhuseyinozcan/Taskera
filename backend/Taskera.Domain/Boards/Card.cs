using System.Net.Mail;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Taskera.Domain.Boards.Events;
using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class Card : Entity
    {
        public CardId CardId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? Deadline { get; private set; }
        public List<UserId> AssignedTo { get; private set; } = new List<UserId>();

        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

        private readonly List<ChecklistItem> _checklist = new();
        public IReadOnlyCollection<ChecklistItem> Checklist => _checklist.AsReadOnly();

        private Card() { }
        internal Card(CardId cardId, string title, string description)
        {
            Guard.AgainstNullOrWhiteSpace(title, nameof(title));
            CardId = cardId;
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
            AssignedTo = userIds ?? new List<UserId>();
        }
        public void AddComment(UserId author, string content)
        {
            var comment = new Comment(CommentId.New(), author, content);
            _comments.Add(comment);
            AddDomainEvent(new CommentAddedEvent(this.CardId, author, content));
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