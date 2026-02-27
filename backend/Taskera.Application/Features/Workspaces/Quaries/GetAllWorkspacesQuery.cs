using MediatR;
using Taskera.Application.Features.Workspaces.DTOs;
using Taskera.Domain.Identity;
using Taskera.Domain.Shared;

namespace Taskera.Application.Features.Workspaces.Queries.GetAllWorkspaces;
public record GetAllWorkspacesQuery(UserId UserId) : IRequest<Result<List<WorkspaceListItemDTO>>>;