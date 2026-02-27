using MediatR;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Application.Features.Workspaces.Commands.CreateWorkspace
{
    public record CreateWorkspaceCommand(UserId OwnerId, string Name, string? Description) : IRequest<Result<Guid>>;
}
