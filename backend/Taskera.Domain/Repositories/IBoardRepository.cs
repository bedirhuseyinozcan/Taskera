using Taskera.Domain.Boards;

namespace Taskera.Domain.Repositories
{
    public interface IBoardRepository
    {
        Task<Board?> GetByIdAsync(BoardId id, CancellationToken cancellationToken = default);
        Task<Board?> GetWithDetailsAsync(BoardId id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Board>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Board board, CancellationToken cancellationToken = default);
        void Remove(Board board);
    }
}