using System.Net.Mail;
using System.Xml.Linq;
using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class Card : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? Deadline { get; private set; }
        public List<UserId?> AssignedTo { get; private set; }

        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

        private readonly List<ChecklistItem> _checklist = new();
        public IReadOnlyCollection<ChecklistItem> Checklist => _checklist.AsReadOnly();

        internal Card(string title, string description)
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
        internal void Assign(List<UserId?> userIds)
        {
            AssignedTo = userIds;
        }
        internal void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
        internal void SetDeadline(DateTime? deadline)
        {
            Deadline = deadline;
        }
        internal void AddChecklistItem(string title)
        {
            var item = new ChecklistItem(title);
            _checklist.Add(item);
        }
    }
}