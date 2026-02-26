using Taskera.Domain.Common;

namespace Taskera.Domain.Boards
{
    public sealed class BoardId : ValueObject
    {
        public Guid Value { get; }
        private BoardId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("BoardId cannot be empty.", nameof(value));
            Value = value;
        }
        public static BoardId New() => new BoardId(Guid.NewGuid());
        public static BoardId Create(Guid value) => new BoardId(value);
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
