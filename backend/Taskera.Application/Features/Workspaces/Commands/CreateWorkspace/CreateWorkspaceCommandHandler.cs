using Taskera.Application.Abstractions.Messaging;
using Taskera.Domain.Abstractions;
using Taskera.Domain.Identity;
using Taskera.Domain.Identity.Enums;
using Taskera.Domain.Repositories;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces;

namespace Taskera.Application.Features.Workspaces.Commands.CreateWorkspace;

internal sealed class CreateWorkspaceCommandHandler
    : ICommandHandler<CreateWorkspaceCommand, Guid>
{
    private readonly IWorkspaceRepository _workspaceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateWorkspaceCommandHandler(IWorkspaceRepository workspaceRepository, IUnitOfWork unitOfWork)
    {
        _workspaceRepository = workspaceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        var workspace = Workspace.Create(request.Name, request.Description);

        var ownerId = UserId.Create(request.OwnerId);
        workspace.AddMember(ownerId, TeamRole.Admin);

        await _workspaceRepository.AddAsync(workspace, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(workspace.Id.Value);
    }
}