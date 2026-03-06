using FluentValidation;

namespace Taskera.Application.Features.Workspaces.Commands.CreateWorkspace;

public sealed class CreateWorkspaceCommandValidator : AbstractValidator<CreateWorkspaceCommand>
{
    public CreateWorkspaceCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);
        RuleFor(x => x.OwnerId).NotEmpty();
    }
}