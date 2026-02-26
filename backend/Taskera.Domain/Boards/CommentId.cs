using Taskera.Domain.Common;
    
namespace Taskera.Domain.Boards
{
    public sealed class CommentId : ValueObject
    {
        public Guid Value { get; }
        private CommentId(Guid value) 
        {
            if (value == Guid.Empty)
                throw new ArgumentException("CommentId cannot be empty.", nameof(value));
            Value = value;
        }
        public static CommentId New() => new CommentId(Guid.NewGuid());
        public static CommentId Create(Guid value) => new CommentId(value);
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
