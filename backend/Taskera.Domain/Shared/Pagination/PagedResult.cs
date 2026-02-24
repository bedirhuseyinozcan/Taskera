namespace Taskera.Domain.Shared.Pagination
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
            Items = items;
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

}
