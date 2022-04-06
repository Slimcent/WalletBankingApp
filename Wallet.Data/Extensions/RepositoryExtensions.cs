using System.Linq.Dynamic.Core;

namespace Wallet.Data.Extensions
{
    public static class RepositoryExtensions
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> query, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return query;

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<T>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return query;

            return query.OrderBy(orderQuery);
        }
    }
}
