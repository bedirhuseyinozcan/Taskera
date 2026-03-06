namespace Taskera.Domain.Common
{
    public abstract class AggregateRoot<TId> : AuditableEntity<TId>
    {
        protected AggregateRoot(TId id) : base(id) { }
        protected AggregateRoot() : base() { }
    }
}
