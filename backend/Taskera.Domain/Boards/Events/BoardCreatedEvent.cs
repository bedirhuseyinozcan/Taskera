using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Boards.Events
{
    public sealed class BoardCreatedEvent : IDomainEvent
    {
        public Board Board { get; }
        public DateTime OccuredOn { get; } = DateTime.UtcNow;
        public BoardCreatedEvent(Board board)
        {
            Board = board;
        }
    }
}