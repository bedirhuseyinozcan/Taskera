using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Boards.Events
{
    public sealed class CardMovedEvent : IDomainEvent
    {
        public Board Board { get; }
        public Card Card { get; }
        public int FromListIndex { get; }
        public int ToListIndex { get; }
        public DateTime OccuredOn { get; } = DateTime.UtcNow;

        public CardMovedEvent(Board board, Card card, int fromListIndex, int toListIndex)
        {
            Board = board;
            Card = card;
            FromListIndex = fromListIndex;
            ToListIndex = toListIndex;
        }
    }
}