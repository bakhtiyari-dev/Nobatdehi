namespace BusinessLogicLayer.Application
{
    public interface IApplicationMethods
    {
        public PaginatedResult<T> GetPaginatedResult<T>(IEnumerable<T> source, int pageNumber, int pageSize);
    }
}
