using Taskera.Domain.Common;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Workspaces
{
    public sealed class WorkspaceId : ValueObject
    {
        public Guid Value { get; }
        private WorkspaceId(Guid value)
        {
            Guard.AgainstNull(value, nameof(value));
            Value = value;
        }
        public static WorkspaceId Create(Guid value)
        {
            return new WorkspaceId(value); 
        }
        public static WorkspaceId New()
        {
            return new WorkspaceId(Guid.NewGuid());
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}