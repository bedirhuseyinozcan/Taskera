using Taskera.Domain.Identity;

namespace Taskera.Domain.Common
{
    public abstract class AuditableEntity<TId> : Entity<TId>
    {
        protected AuditableEntity(TId id) : base(id) { }
        protected AuditableEntity() : base() { }
        public DateTime CreatedAt { get; protected set; }
        public UserId? CreatedBy { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; } 
        public UserId? UpdatedBy { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
