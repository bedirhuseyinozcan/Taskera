using Taskera.Domain.Common;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class BoardList : BaseEntity
    {
        public string Name { get; private set; }
        public int Order { get; private set; }

        private readonly List<Card> _cards = new();
        public IReadOnlyCollection<Card> Cards => _cards.AsReadOnly();

        internal BoardList(string name, int order)
        {
            Name = name;
            Order = order;
        }

        internal void Rename(string newName)
        {
            Guard.AgainstNullOrWhiteSpace(newName, nameof(newName));
            Name = newName;
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
    }
}