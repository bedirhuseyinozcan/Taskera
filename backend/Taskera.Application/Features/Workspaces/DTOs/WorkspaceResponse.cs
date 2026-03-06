namespace Taskera.Application.Features.Workspaces.DTOs;

public record WorkspaceResponse(
    Guid Id,
    string Name,
    string Description);