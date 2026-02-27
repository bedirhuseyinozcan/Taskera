using MediatR;
using Taskera.Domain.Abstractions;
using Taskera.Domain.Identity;
using Taskera.Domain.Repositories;
using Taskera.Domain.Shared;
using Taskera.Domain.Workspaces;

namespace Taskera.Application.Features.Workspaces.Commands.CreateWorkspace
{
    public class CreateWorkspaceCommandHandler : IRequestHandler<CreateWorkspaceCommand, Result<Guid>>
    {
        private readonly IWorkspaceRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateWorkspaceCommandHandler(IWorkspaceRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var workspace = Workspace.Create(request.Name, request.OwnerId, request.Description);
            await _repository.AddAsync(workspace);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<Guid>.Success(workspace.WorkspaceId.Value);
        }
    }
}
