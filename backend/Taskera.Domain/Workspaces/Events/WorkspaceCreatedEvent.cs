using Taskera.Domain.Common;

namespace Taskera.Domain.Workspaces.Events;
public sealed class WorkspaceCreatedEvent : IDomainEvent
{
    public WorkspaceId WorkspaceId { get; }
    public string Name { get; }
    public string? Description { get; }
    public DateTime OccurredOn { get; } = DateTime.UtcNow;

    public WorkspaceCreatedEvent(WorkspaceId workspaceId, string name, string? description)
    {
        WorkspaceId = workspaceId;
        Name = name;
        Description = description;
    }
}