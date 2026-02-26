using Taskera.Domain.Identity;

namespace Taskera.Domain.Common
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; protected set; }
        public UserId? CreatedBy { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; } 
        public UserId? UpdatedBy { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }
        public bool IsDeleted { get; protected set; }
    }
}
