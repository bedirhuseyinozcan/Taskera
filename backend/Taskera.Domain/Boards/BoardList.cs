using Taskera.Domain.Common;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class BoardList : Entity
    {
        public string Title { get; private set; }
        public int Order { get; private set; }

        private readonly List<Card> _cards = new();
        public IReadOnlyCollection<Card> Cards => _cards.AsReadOnly();

        private BoardList() { }
        internal BoardList(string title, int order)
        {
            Title = title;
            Order = order;
        }

        internal void UpdateName(string newName)
        {
            Guard.AgainstNullOrWhiteSpace(newName, nameof(newName));
            Title = newName;
        }

        internal void SetOrder(int order)
        {
            Guard.AgainstNegativeOrZero(order, nameof(order));
            Order = order;
        }

        internal void AddCard(Card card)
        {
            _cards.Add(card);
        }

        internal void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }

        internal void InsertCard(Card card, int index)
        {
            if (index < 0 || index > _cards.Count)
                throw new ArgumentOutOfRangeException();

            _cards.Insert(index, card);
        }

        internal void ReorderCard(int oldIndex, int newIndex)
        {
            if (oldIndex < 0 || oldIndex >= _cards.Count || newIndex < 0 || newIndex >= _cards.Count)
                throw new ArgumentOutOfRangeException();

            var card = _cards[oldIndex];
            _cards.RemoveAt(oldIndex);
            _cards.Insert(newIndex, card);
        }
    }
}