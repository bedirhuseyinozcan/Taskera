using Taskera.Domain.Identity;
using Taskera.Domain.Workspaces;

namespace Taskera.Domain.Repositories
{
    public interface IWorkspaceRepository
    {
        Task<Workspace?> GetByIdAsync(WorkspaceId id, CancellationToken cancellationToken = default);
        Task<Workspace?> GetWithMembersAsync(WorkspaceId id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Workspace>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Workspace>> GetByUserIdAsync(UserId userId, CancellationToken cancellationToken = default);
        Task AddAsync(Workspace workspace, CancellationToken cancellationToken = default);
        void Remove(Workspace workspace);
    }
}