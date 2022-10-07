using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace PatientManager.Sql.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int? page, int? pageSize)
        {
            if (page != null && pageSize != null)
                query = query.Skip(pageSize.Value * (page.Value - 1)).Take(pageSize.Value);
            return query;
        }
        public static IQueryable<T> Filtering<T>(this IQueryable<T> query, Expression<Func<T, bool>>? filter)
        {
            if (filter != null) query = query.Where(filter);
            return query;
        }
        public static IQueryable<T> Ordering<T>(this IQueryable<T> query, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy)
        {
            if (orderBy != null) query = orderBy(query);
            return query;
        }
        public static IQueryable<T> Including<T>(this IQueryable<T> query, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include)
        {
            if (include != null) query = include(query);
            return query;
        }

        public static IQueryable<T> Selecting<T>(this IQueryable<T> query, Expression<Func<T, T>>? selector = null)
        {
            if (selector != null) query = query.Select(selector);
            return query;
        }
    }
}
