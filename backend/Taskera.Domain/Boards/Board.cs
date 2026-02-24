using Taskera.Domain.Boards.Events;
using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class Board : AggregateRoot
    {
        public BoardId Id { get; private set; }
        public string Name { get; private set; }

        private readonly List<BoardList> _lists = new();
        public IReadOnlyCollection<BoardList> Lists => _lists.AsReadOnly();

        private Board(BoardId id, string name)
        {
            Id = id;
            Name = name;
            AddDomainEvents(new BoardCreatedEvent(this));
        }

        public static Board Create(string name)
        {
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            return new Board(BoardId.New(), name);
        }

        // İş kuralları
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
            AddDomainEvents(new ListReorderedEvent(this));
        }

        public void ReorderList(int oldIndex, int newIndex)
        {
            if (oldIndex < 0 || oldIndex >= _lists.Count || newIndex < 0 || newIndex >= _lists.Count)
                throw new ArgumentOutOfRangeException();

            var list = _lists[oldIndex];
            _lists.RemoveAt(oldIndex);
            _lists.Insert(newIndex, list);

            // Order güncelle
            for (int i = 0; i < _lists.Count; i++)
                _lists[i].SetOrder(i + 1);

            AddDomainEvents(new ListReorderedEvent(this));
        }

        public void AddCard(int listIndex, string title, string description)
        {
            if (listIndex < 0 || listIndex >= _lists.Count)
                throw new ArgumentOutOfRangeException();

            var card = new Card(title, description);
            _lists[listIndex].AddCard(card);
            AddDomainEvents(new CardCreatedEvent(this, card));
        }

        public void MoveCard(int fromListIndex, int toListIndex, Card card)
        {
            if (fromListIndex < 0 || fromListIndex >= _lists.Count)
                throw new ArgumentOutOfRangeException();
            if (toListIndex < 0 || toListIndex >= _lists.Count)
                throw new ArgumentOutOfRangeException();

            _lists[fromListIndex].RemoveCard(card);
            _lists[toListIndex].AddCard(card);

            AddDomainEvents(new CardMovedEvent(this, card, fromListIndex, toListIndex));
        }

        public void AssignCard(Card card, UserId userId)
        {
            card.Assign(userId);
            AddDomainEvents(new CardAssignedEvent(this, card, userId));
        }
    }
}