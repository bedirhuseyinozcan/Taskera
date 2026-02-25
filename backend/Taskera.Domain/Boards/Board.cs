using Taskera.Domain.Boards.Events;
using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces;

namespace Taskera.Domain.Boards
{
    public sealed class Board : AggregateRoot
    {
        public BoardId Id { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime LastActivity { get; private set; }

        private readonly List<BoardList> _lists = new();
        public IReadOnlyCollection<BoardList> Lists => _lists.AsReadOnly();

        private Board(BoardId id, string name, string? description, DateTime lastActivity)
        {
            Id = id;
            Name = name;
            Description = description;
            LastActivity = lastActivity;
            AddDomainEvent(new BoardCreatedEvent(this));
        }

        public static Board Create(string name, string? description)
        {
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            return new Board(BoardId.New(), name, description, DateTime.UtcNow);
        }

        public void Rename(string newName)
        {
            Guard.AgainstNullOrWhiteSpace(newName, nameof(newName));
            Name = newName;
        }

        public void AddList(string name)
        {
            int order = _lists.Count + 1;
            var list = new BoardList(name, order);
            _lists.Add(list);
            AddDomainEvent(new ListReorderedEvent(this));
        }

        public void ReorderCardWithinList(int listIndex, int oldIndex, int newIndex)
        {
            if (listIndex < 0 || listIndex >= _lists.Count)
                throw new ArgumentOutOfRangeException(nameof(listIndex));

            _lists[listIndex].ReorderCard(oldIndex, newIndex);
            AddDomainEvent(new CardReorderedEvent(this, _lists[listIndex]));
        }

        public void AddCard(int listIndex, string title, string description)
        {
            if (listIndex < 0 || listIndex >= _lists.Count)
                throw new ArgumentOutOfRangeException();

            var card = new Card(title, description);
            _lists[listIndex].AddCard(card);
            AddDomainEvent(new CardCreatedEvent(this, card));
        }

        public void MoveCard(int fromListIndex, int toListIndex, Card card, int toIndex)
        {
            if (fromListIndex < 0 || fromListIndex >= _lists.Count)
                throw new ArgumentOutOfRangeException(nameof(fromListIndex));
            if (toListIndex < 0 || toListIndex >= _lists.Count)
                throw new ArgumentOutOfRangeException(nameof(toListIndex));

            _lists[fromListIndex].RemoveCard(card);
            _lists[toListIndex].InsertCard(card, toIndex);

            AddDomainEvent(new CardMovedEvent(this, card, fromListIndex, toListIndex));
        }

        public void AssignCard(Card card, List<UserId> userIds, Workspace workspace)
        {
            foreach (var userId in userIds)
            {
                if (!workspace.Members.Any(m => m.UserId == userId))
                    throw new InvalidOperationException("User is not a member of the workspace.");
            }

            card.Assign(userIds);
            AddDomainEvent(new CardAssignedEvent(this, card, userIds));
        }
    }
}