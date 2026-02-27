using Mapster;
using MediatR;
using Taskera.Application.Features.Workspaces.DTOs;
using Taskera.Domain.Repositories;
using Taskera.Domain.Shared;

namespace Taskera.Application.Features.Workspaces.Queries.GetAllWorkspaces;

public class GetAllWorkspacesQueryHandler : IRequestHandler<GetAllWorkspacesQuery, Result<List<WorkspaceListItemDTO>>>
{
    private readonly IWorkspaceRepository _repository;

    public GetAllWorkspacesQueryHandler(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<List<WorkspaceListItemDTO>>> Handle(GetAllWorkspacesQuery request, CancellationToken cancellationToken)
    {
        var workspaces = await _repository.GetByUserIdAsync(request.UserId, cancellationToken);

        var dtos = workspaces.Adapt<List<WorkspaceListItemDTO>>();

        return Result<List<WorkspaceListItemDTO>>.Success(dtos);
    }
}