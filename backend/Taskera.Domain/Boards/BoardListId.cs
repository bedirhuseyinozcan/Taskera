using Taskera.Domain.Common;

namespace Taskera.Domain.Boards
{
    public sealed class BoardListId : ValueObject
    {
        public Guid Value { get; }
        private BoardListId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("BoardListId cannot be empty.", nameof(value));
            Value = value;
        }
        public static BoardListId New() => new BoardListId(Guid.NewGuid());
        public static BoardListId Create(Guid value) => new BoardListId(value);
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
