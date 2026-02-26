using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Workspaces
{
    public sealed class WorkspaceId : ValueObject
    {
        public Guid Value { get; }
        private WorkspaceId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("WorkspaceId cannot be empty.", nameof(value));
            Value = value;
        }
        public static WorkspaceId Create(Guid value) => new WorkspaceId(value);
        public static WorkspaceId New() => new WorkspaceId(Guid.NewGuid());

        public static implicit operator Guid(WorkspaceId workspaceId) => workspaceId.Value;
        public static implicit operator WorkspaceId(Guid value) => new(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        public override string ToString() => Value.ToString();
    
    }
}