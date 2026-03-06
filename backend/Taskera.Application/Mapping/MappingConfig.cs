using Mapster;
using Taskera.Application.Features.Workspaces.DTOs;
using Taskera.Domain.Workspaces;

namespace Taskera.Application.Mapping;

public static class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<Workspace, WorkspaceResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}