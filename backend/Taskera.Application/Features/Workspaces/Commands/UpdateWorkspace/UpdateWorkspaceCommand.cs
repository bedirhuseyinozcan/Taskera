using MediatR;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces;

namespace Taskera.Application.Features.Workspaces.Commands.UpdateWorkspace
{
    public record UpdateWorkspaceCommand(WorkspaceId WorkspaceId, UserId UserId, string Name, string? Description) : IRequest<Result<Unit>>;
}
