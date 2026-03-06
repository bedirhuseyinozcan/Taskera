using Taskera.Application.Abstractions.Messaging;
using Taskera.Application.Features.Workspaces.DTOs;

namespace Taskera.Application.Features.Workspaces.Queries.GetWorkspaceById;

public sealed record GetWorkspaceByIdQuery(Guid WorkspaceId) : IQuery<WorkspaceResponse>;