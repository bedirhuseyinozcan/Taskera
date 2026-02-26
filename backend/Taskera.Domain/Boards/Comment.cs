using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class Comment : Entity
    {
        public CommentId CommentId { get; private set; }
        public string Content { get; private set; }
        public UserId Author { get; private set; }
        public DateTime CreatedAt { get; private set; }
        private Comment() { }
        internal Comment(CommentId commentId, UserId author, string content)
        {
            Guard.AgainstNullOrWhiteSpace(content, nameof(content));
            CommentId = commentId;
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