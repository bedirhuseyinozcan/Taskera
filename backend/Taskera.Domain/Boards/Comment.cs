using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class Comment : BaseEntity
    {
        public string Content { get; private set; }
        public UserId Author { get; private set; }
        public DateTime CreatedAt { get; private set; }

        internal Comment(string content, UserId author)
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