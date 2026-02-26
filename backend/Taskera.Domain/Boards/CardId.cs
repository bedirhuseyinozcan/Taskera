using Taskera.Domain.Common;

namespace Taskera.Domain.Boards
{
    public sealed class CardId : ValueObject
    {
        public Guid Value { get; }
        private CardId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("CardId cannot be empty.", nameof(value));
            Value = value;
        }
        public static CardId New() => new CardId(Guid.NewGuid());
        public static CardId Create(Guid value) => new CardId(value);
        protected override IEnumerable<object> GetEqualityComponents() 
        {
            yield return Value; 
        }
    }
}