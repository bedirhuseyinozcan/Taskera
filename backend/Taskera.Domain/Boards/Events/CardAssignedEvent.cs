using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Boards.Events
{
    public sealed class CardAssignedEvent : IDomainEvent
    {
        public Board Board { get; }
        public Card Card { get; }
        public List<UserId> AssignedTo { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public CardAssignedEvent(Board board, Card card, List<UserId> assignedTo)
        {
            Board = board;
            Card = card;
            AssignedTo = assignedTo;
        }
    }
}