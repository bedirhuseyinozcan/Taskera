using FluentValidation;

namespace Taskera.Application.Features.Workspaces.Commands.UpdateWorkspace
{
    public class UpdateWorkspaceCommandValidator : AbstractValidator<UpdateWorkspaceCommand>
    {
        public UpdateWorkspaceCommandValidator()
        {
            RuleFor(x => x.WorkspaceId).NotEmpty().WithMessage("Workspace ID is required.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(100);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}