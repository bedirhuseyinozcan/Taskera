using Mapster;
using MediatR;
using Taskera.Application.Features.Workspaces.DTOs;
using Taskera.Domain.Repositories;
using Taskera.Domain.Shared;

namespace Taskera.Application.Features.Workspaces.Queries.GetWorkspaceById;

public class GetWorkspaceByIdQueryHandler : IRequestHandler<GetWorkspaceByIdQuery, Result<WorkspaceDTO>>
{
    private readonly IWorkspaceRepository _repository;

    public GetWorkspaceByIdQueryHandler(IWorkspaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<WorkspaceDTO>> Handle(GetWorkspaceByIdQuery request, CancellationToken cancellationToken)
    {
        var workspace = await _repository.GetByIdAsync(request.WorkspaceId, cancellationToken);

        if (workspace is null)
        {
            return Result<WorkspaceDTO>.Fail(new Error("Workspace.NotFound", "Workspace not found."));
        }

        var dto = workspace.Adapt<WorkspaceDTO>();

        return Result<WorkspaceDTO>.Success(dto);
    }
}