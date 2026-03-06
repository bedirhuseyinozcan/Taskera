using MediatR;
using Taskera.Application.Abstractions.Messaging;
using Taskera.Domain.Abstractions;
using Taskera.Domain.Repositories;
using Taskera.Domain.Shared;
using Taskera.Domain.Shared.Enums;
using Taskera.Domain.Workspaces;

namespace Taskera.Application.Features.Workspaces.Commands.UpdateWorkspace;

internal sealed class UpdateWorkspaceCommandHandler : ICommandHandler<UpdateWorkspaceCommand, Unit>
{
    private readonly IWorkspaceRepository _workspaceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWorkspaceCommandHandler(IWorkspaceRepository workspaceRepository, IUnitOfWork unitOfWork)
    {
        _workspaceRepository = workspaceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Unit>> Handle(UpdateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        var workspace = await _workspaceRepository.GetByIdAsync(WorkspaceId.Create(request.WorkspaceId), cancellationToken);

        if (workspace is null)
        {
            return Result<Unit>.Fail(new Error("Workspace.NotFound", "Güncellenecek alan bulunamadı.", ErrorType.NotFound));
        }

        // Domain nesnesi üzerinden güncelleme yapıyoruz (Business logic Domain katmanında kalıyor)
        workspace.Update(request.Name, request.Description);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}