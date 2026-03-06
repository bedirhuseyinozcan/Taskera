using FluentValidation;

namespace Taskera.Application.Features.Workspaces.Commands.UpdateWorkspace;

public sealed class UpdateWorkspaceCommandValidator : AbstractValidator<UpdateWorkspaceCommand>
{
    public UpdateWorkspaceCommandValidator()
    {
        // Workspace ID'si mutlaka dolu gelmeli
        RuleFor(x => x.WorkspaceId)
            .NotEmpty().WithMessage("Güncellenecek çalışma alanı kimliği belirtilmelidir.");

        // İsim boş olamaz ve Create ile aynı kurallara sahip olmalı
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Çalışma alanı adı boş olamaz.")
            .MaximumLength(100).WithMessage("Çalışma alanı adı 100 karakteri geçemez.");

        // Açıklama opsiyonel olabilir ama bir sınırı olmalı
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama 500 karakteri geçemez.");
    }
}