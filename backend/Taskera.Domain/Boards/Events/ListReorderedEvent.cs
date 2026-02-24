using Taskera.Domain.Common;
using Taskera.Domain.Identity;

namespace Taskera.Domain.Boards.Events
{
    public sealed class ListReorderedEvent : IDomainEvent
    {
        public Board Board { get; }
        public DateTime OccuredOn { get; } = DateTime.UtcNow;
        public ListReorderedEvent(Board board)
        {
            Board = board;
        }
    }
}