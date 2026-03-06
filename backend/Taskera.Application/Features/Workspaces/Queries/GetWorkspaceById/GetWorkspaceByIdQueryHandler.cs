using Mapster;
using Taskera.Application.Abstractions.Messaging;
using Taskera.Application.Features.Workspaces.DTOs;
using Taskera.Domain.Repositories;
using Taskera.Domain.Shared;
using Taskera.Domain.Shared.Enums;
using Taskera.Domain.Workspaces;

namespace Taskera.Application.Features.Workspaces.Queries.GetWorkspaceById;

internal sealed class GetWorkspaceByIdQueryHandler
    : IQueryHandler<GetWorkspaceByIdQuery, WorkspaceResponse>
{
    private readonly IWorkspaceRepository _workspaceRepository;

    public GetWorkspaceByIdQueryHandler(IWorkspaceRepository workspaceRepository)
    {
        _workspaceRepository = workspaceRepository;
    }

    public async Task<Result<WorkspaceResponse>> Handle(GetWorkspaceByIdQuery request, CancellationToken cancellationToken)
    {
        var workspaceId = WorkspaceId.Create(request.WorkspaceId);
        var workspace = await _workspaceRepository.GetByIdAsync(workspaceId, cancellationToken);

        if (workspace is null)
        {
            return Result<WorkspaceResponse>.Fail(new Error(
                "Workspace.NotFound",
                "İstenen çalışma alanı bulunamadı.",
                ErrorType.NotFound));
        }

        var response = workspace.Adapt<WorkspaceResponse>();

        return Result<WorkspaceResponse>.Success(response);
    }
}