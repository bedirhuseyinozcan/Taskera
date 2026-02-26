using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Boards.Events
{
    public sealed record CardCreatedEvent(BoardId BoardId, CardId CardId, string Title) : IDomainEvent
    {
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}