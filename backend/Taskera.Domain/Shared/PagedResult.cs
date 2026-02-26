namespace Taskera.Domain.Shared
{
    public class PagedResult<T>
    {
        public IReadOnlyList<T> Items { get; }
        public int TotalItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }

        public int TotalPages =>
            (int)Math.Ceiling((double)TotalItems / PageSize);

        public PagedResult(
            IReadOnlyList<T> items,
            int totalItems,
            int pageNumber,
            int pageSize)
        {
            if (pageSize <= 0)
                throw new ArgumentException("PageSize must be greater than zero.", nameof(pageSize));

            if (pageNumber <= 0)
                throw new ArgumentException("PageNumber must be greater than zero.", nameof(pageNumber));

            if (totalItems < 0)
            {
                throw new ArgumentException("Total items cannot be negative.", nameof(totalItems));
            }

            Items = items ?? throw new ArgumentNullException(nameof(items));
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}