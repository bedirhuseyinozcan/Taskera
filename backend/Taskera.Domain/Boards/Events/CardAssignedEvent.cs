using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Boards.Events
{
    public sealed record CardAssignedEvent(BoardId BoardId, CardId CardId, List<UserId> AssignedUserIds) : IDomainEvent
    {
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    }
}