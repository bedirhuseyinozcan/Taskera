using FluentValidation;

namespace Taskera.Application.Features.Workspaces.Commands.CreateWorkspace
{
    public class CreateWorkspaceCommandValidator : AbstractValidator<CreateWorkspaceCommand>
    {
        public CreateWorkspaceCommandValidator() 
        {
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Workspace name cannot be empty.").MaximumLength(100).WithMessage("Workspace name can be maximum 100 characters.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Workspace description can be maximum 500 characters");
        }
    }
}
