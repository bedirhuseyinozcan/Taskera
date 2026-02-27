using Taskera.Domain.Common;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards;
public sealed class ChecklistItem : Entity
{
    public ChecklistItemId ChecklistItemId { get; private set; }
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }
    private ChecklistItem() { }
    internal ChecklistItem(ChecklistItemId checklistItemId, string title)
    {
        Guard.AgainstNullOrWhiteSpace(title, nameof(title));
        ChecklistItemId = checklistItemId;
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