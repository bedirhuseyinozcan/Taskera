using Taskera.Domain.Common;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Identity
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; }
        private UserId(Guid value)
        {
            Guard.AgainstNull(value, nameof(value));
            Value = value;
        }
        public static UserId Create(Guid value)
        {
            return new UserId(value); 
        }
        public static UserId New()
        {
            return new UserId(Guid.NewGuid()); 
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
