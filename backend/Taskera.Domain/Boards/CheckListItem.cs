using Taskera.Domain.Common;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards
{
    public sealed class ChecklistItem : ValueObject
    {
        public string Title { get; }
        public bool IsCompleted { get; private set; }

        internal ChecklistItem(string title, bool isCompleted = false)
        {
            Guard.AgainstNullOrWhiteSpace(title, nameof(title));
            Title = title;
            IsCompleted = isCompleted;
        }

        internal void Toggle()
        {
            IsCompleted = !IsCompleted;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title;
            yield return IsCompleted;
        }
    }
}