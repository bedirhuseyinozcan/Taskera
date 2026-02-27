using Mapster;
using Taskera.Application.Features.Workspaces.DTOs;
using Taskera.Domain.Workspaces;

namespace Taskera.Application.Mapping;

public static class WorkspaceMappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<Workspace, WorkspaceDTO>
            .NewConfig()
            .Map(dest => dest.Id, src => src.WorkspaceId.Value)
            .Map(dest => dest.Members, src => src.Members);

        TypeAdapterConfig<WorkspaceMember, WorkspaceMemberDTO>
            .NewConfig()
            .Map(dest => dest.UserId, src => src.UserId.Value);

        TypeAdapterConfig<Workspace, WorkspaceListItemDTO>
            .NewConfig()
            .Map(dest => dest.Id, src => src.WorkspaceId.Value);
    }
}