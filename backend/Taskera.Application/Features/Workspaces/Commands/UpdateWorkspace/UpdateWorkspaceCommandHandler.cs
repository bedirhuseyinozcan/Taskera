using MediatR;
using Taskera.Domain.Abstractions;
using Taskera.Domain.Repositories;
using Taskera.Domain.Shared;

namespace Taskera.Application.Features.Workspaces.Commands.UpdateWorkspace
{
    public class UpdateWorkspaceCommandHandler : IRequestHandler<UpdateWorkspaceCommand, Result<Unit>>
    {
        private readonly IWorkspaceRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWorkspaceCommandHandler(IWorkspaceRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Unit>> Handle(UpdateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var workspace = await _repository.GetByIdAsync(request.WorkspaceId, cancellationToken);

            if (workspace is null)
            {
                return Result<Unit>.Fail(new Error("Workspace.NotFound", "Workspace not found."));
            }

            if (workspace.Name != request.Name) 
                workspace.UpdateName(request.Name);
            if (workspace.Description != request.Description) 
                workspace.UpdateDescription(request.Description);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<Unit>.Success(Unit.Value);
        }
    }
}