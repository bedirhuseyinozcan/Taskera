using Taskera.Application.Abstractions.Messaging;

namespace Taskera.Application.Features.Workspaces.Commands.CreateWorkspace;

public sealed record CreateWorkspaceCommand(
    Guid OwnerId,
    string Name,
    string Description) : ICommand<Guid>;