using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Boards.Events
{
    public sealed class CardCreatedEvent : IDomainEvent
    {
        public Board Board { get; }
        public Card Card { get; }
        public DateTime OccuredOn { get; } = DateTime.UtcNow;
        public CardCreatedEvent(Board board, Card card)
        {
            Board = board;
            Card = card;
        }
    }
}