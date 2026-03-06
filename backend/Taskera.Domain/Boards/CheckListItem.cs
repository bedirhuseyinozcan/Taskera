using Taskera.Domain.Common;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards;
public sealed class ChecklistItem : Entity<ChecklistItemId>
{
    public string Title { get; private set; } = null!;
    public bool IsCompleted { get; private set; }
    private ChecklistItem() { }
    internal ChecklistItem(ChecklistItemId id, string title) : base(id)
    {
        Guard.AgainstNullOrWhiteSpace(title, nameof(title));
        Title = title;
        IsCompleted = false;
    }

    internal void Toggle()
    {
        IsCompleted = !IsCompleted;
    }

    internal void UpdateTitle(string newTitle)
    {
        Guard.AgainstNullOrWhiteSpace(newTitle, nameof(newTitle));
        Title = newTitle;
    }
}