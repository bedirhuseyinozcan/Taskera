namespace Taskera.Domain.Shared
{
    public class PagedResult<T>
    {
        public IReadOnlyList<T> Items { get; }
        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }

        public int TotalPages => PageSize > 0
            ? (int)Math.Ceiling((double)TotalItems / PageSize)
            : 0;
        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;
        public PagedResult(
            IReadOnlyList<T> items,
            int totalItems,
            int pageNumber,
            int pageSize)
        {
            if (pageSize <= 0) throw new ArgumentException("PageSize must be > 0", nameof(pageSize));
            if (pageNumber <= 0) throw new ArgumentException("PageNumber must be > 0", nameof(pageNumber));
            if (totalItems < 0) throw new ArgumentException("Total items cannot be negative", nameof(totalItems));

            Items = items ?? throw new ArgumentNullException(nameof(items));
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}