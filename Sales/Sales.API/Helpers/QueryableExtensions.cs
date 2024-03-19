using Sales.Shared.DTOs;

namespace Sales.API.Helpers
{

    public static class QueryableExtensions
    {
        //metodo clave de la extecion
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.RecordsNumber)
                .Take(pagination.RecordsNumber);
        }
    }

}
