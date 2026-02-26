using Taskera.Domain.Common;
using Taskera.Domain.Shared;

namespace Taskera.Domain.Boards;
public sealed class ChecklistItem : Entity
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }
    private ChecklistItem() { }
    internal ChecklistItem(string title)
    {
        Guard.AgainstNullOrWhiteSpace(title, nameof(title));
        Id = Guid.NewGuid();
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