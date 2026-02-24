namespace Taskera.Domain.Common
{
    public interface IDomainEvent
    {
        DateTime OccuredOn { get; }
    }
}
