using Taskera.Domain.Common;

namespace Taskera.Domain.Boards.Events
{
    public sealed record CardMovedEvent(BoardId BoardId, CardId CardId, string FromListTitle, string ToListTitle) : IDomainEvent
    {
        public DateTime OccurredOn {  get; init; } = DateTime.UtcNow;
    }
}