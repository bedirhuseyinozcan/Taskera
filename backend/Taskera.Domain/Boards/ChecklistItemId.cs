using Taskera.Domain.Common;

namespace Taskera.Domain.Boards
{
    public sealed class ChecklistItemId : ValueObject
    {
        public Guid Value { get; }
        private ChecklistItemId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("ChecklistItemId cannot be empty.", nameof(value));
            Value = value;
        }
        public static ChecklistItemId New() => new ChecklistItemId(Guid.NewGuid());
        public static ChecklistItemId Create(Guid value) => new ChecklistItemId(value);
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
