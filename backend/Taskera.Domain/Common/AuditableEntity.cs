namespace Taskera.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; protected set; }
        public Guid CreatedBy { get; protected set; }
        public DateTime? ModifiedAt { get; protected set; } 
        public Guid? ModifiedBy { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }
        public bool IsDeleted { get; protected set; }
    }
}
