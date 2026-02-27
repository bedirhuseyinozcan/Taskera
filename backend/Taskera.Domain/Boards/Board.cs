using Taskera.Domain.Boards.Events;
using Taskera.Domain.Common;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces;

namespace Taskera.Domain.Boards
{
    public sealed class Board : AggregateRoot
    {
        private Board() { }
        public BoardId BoardId { get; private set; }
        public WorkspaceId WorkspaceId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public DateTime LastActivity { get; private set; }

        private readonly List<BoardList> _lists = new();
        public IReadOnlyCollection<BoardList> Lists => _lists.AsReadOnly();

        private Board(BoardId boardId, WorkspaceId workspaceId, string name, string? description, DateTime lastActivity)
        {
            BoardId = boardId;
            WorkspaceId = workspaceId;
            Name = name;
            Description = description;
            LastActivity = lastActivity;
        }

        public static Board Create(WorkspaceId workspaceId, string name, string? description)
        {
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            return new Board(BoardId.New(), workspaceId, name, description, DateTime.UtcNow);
        }

        public void Rename(string newName)
        {
            Guard.AgainstNullOrWhiteSpace(newName, nameof(newName));
            Name = newName;
        }

        public void AddList(string name)
        {
            Guard.AgainstNullOrWhiteSpace(name, nameof(name));
            int order = _lists.Count + 1;
            var list = new BoardList(BoardListId.New(), name, order);
            _lists.Add(list);
        }

        public void ReorderCardWithinList(int listIndex, int oldIndex, int newIndex)
        {
            if (listIndex < 0 || listIndex >= _lists.Count)
                throw new ArgumentOutOfRangeException(nameof(listIndex));

            _lists[listIndex].ReorderCard(oldIndex, newIndex);
        }

        public void AddCard(BoardListId listId, string title, string description)
        {
            var list = _lists.FirstOrDefault(l => l.BoardListId == listId);
            if (list == null)
                throw new InvalidOperationException("Liste bulunamadı.");

            var card = new Card(CardId.New(), title, description);
            list.AddCard(card);
            AddDomainEvent(new CardCreatedEvent(this.BoardId, card.CardId, title));
        }
        public void MoveCard(BoardListId fromListId, BoardListId toListId, CardId cardId, int toIndex)
        {
            var fromList = _lists.FirstOrDefault(l => l.BoardListId == fromListId);
            var toList = _lists.FirstOrDefault(l => l.BoardListId == toListId);

            if (fromList == null || toList == null)
                throw new InvalidOperationException("Kaynak veya hedef liste bulunamadı.");

            var card = fromList.Cards.FirstOrDefault(c => c.CardId == cardId);
            if (card == null) throw new InvalidOperationException("Kart bulunamadı.");

            fromList.RemoveCard(card);
            toList.InsertCard(card, toIndex);

            AddDomainEvent(new CardMovedEvent(this.BoardId, cardId, fromList.Title, toList.Title));
        }

        public void RemoveList(int index)
        {
            if (index < 0 || index >= _lists.Count) return;

            _lists.RemoveAt(index);
            for (int i = 0; i < _lists.Count; i++)
            {
                _lists[i].SetOrder(i + 1);
            }
        }

        public void AssignCard(CardId cardId, List<UserId> userIds)
        {
            var card = _lists.SelectMany(l => l.Cards)
                             .FirstOrDefault(c => c.CardId == cardId);

            if (card == null)
                throw new InvalidOperationException("Bu kart bu panoda bulunamadı.");

            card.Assign(userIds);
            AddDomainEvent(new CardAssignedEvent(this.BoardId, cardId, userIds));
        }
    }
}