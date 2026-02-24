using System.Xml.Linq;
using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class Card : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public UserId? AssignedTo { get; private set; }

        private readonly List<Comment> _comments = new();
        public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

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

        internal void Assign(UserId userId)
        {
            AssignedTo = userId;
        }

        internal void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
    }
}