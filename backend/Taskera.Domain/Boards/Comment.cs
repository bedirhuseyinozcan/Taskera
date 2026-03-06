using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class Comment : Entity<CommentId>
    {
        public string Content { get; private set; } = null!;
        public UserId Author { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }
        private Comment() { }
        internal Comment(CommentId id, UserId author, string content) : base(id)
        {
            Guard.AgainstNullOrWhiteSpace(content, nameof(content));
            Content = content;
            Author = author;
            CreatedAt = DateTime.UtcNow;
        }

        internal void UpdateContent(string content)
        {
            Guard.AgainstNullOrWhiteSpace(content, nameof(content));
            Content = content;
        }
    }
}