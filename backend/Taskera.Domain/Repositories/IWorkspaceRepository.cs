using Taskera.Domain.Workspaces;

namespace Taskera.Domain.Repositories
{
    public interface IWorkspaceRepository
    {
        Task<Workspace?> GetByIdAsync(WorkspaceId id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Workspace>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Workspace workspace, CancellationToken cancellationToken = default);
        Task UpdateAsync(Workspace workspace, CancellationToken cancellationToken = default);
        Task DeleteAsync(Workspace workspace, CancellationToken cancellationToken = default);
    }
}