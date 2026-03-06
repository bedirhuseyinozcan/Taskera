using Taskera.Application.Abstractions.Messaging;
using MediatR;

namespace Taskera.Application.Features.Workspaces.Commands.UpdateWorkspace;

public sealed record UpdateWorkspaceCommand(
    Guid WorkspaceId,
    string Name,
    string? Description) : ICommand<Unit>; // Unit, MediatR'da "boş/void" anlamına gelir.