using MediatR;
using Taskera.Application.Features.Workspaces.DTOs;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces;

namespace Taskera.Application.Features.Workspaces.Queries.GetWorkspaceById;
public record GetWorkspaceByIdQuery(WorkspaceId WorkspaceId) : IRequest<Result<WorkspaceDTO>>;