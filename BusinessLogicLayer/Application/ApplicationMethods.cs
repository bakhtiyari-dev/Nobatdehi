namespace BusinessLogicLayer.Application
{
    public class ApplicationMethods : IApplicationMethods
    {
        public ApplicationMethods() { }

        public PaginatedResult<T> GetPaginatedResult<T>(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if ((pageNumber - 1) * pageSize >= source.Count())
            {
                throw new ArgumentException("Combination of page number and page size has greeter than all exist items count!");
            }

            var totalItems = source.Count();
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedResult<T>
            {
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                Items = items
            };
        }
    }
}
