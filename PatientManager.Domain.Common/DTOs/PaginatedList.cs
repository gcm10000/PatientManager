namespace PatientManager.Domain.Common.DTOs
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public PaginatedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageSize.Equals(0) ? 1 : pageNumber;
            TotalPages = pageSize.Equals(0) ? 1 : (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;
    }
}
