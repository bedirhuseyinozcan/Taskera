using Taskera.Domain.Common;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces;

namespace Taskera.Domain.Boards
{
    public sealed class BoardId : ValueObject
    {
        public Guid Value { get; }
        private BoardId(Guid value)
        {
            Guard.AgainstNull(value, nameof(value));
            Value = value;
        }
        public static BoardId Create(Guid value)
        {
            return new BoardId(value);
        }
        public static BoardId New()
        {
            return new BoardId(Guid.NewGuid());
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
