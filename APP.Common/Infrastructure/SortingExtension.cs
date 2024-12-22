using System.Linq.Expressions;

namespace App.Shared.Infrastructure
{
    public static class SortingExtension
    {
        public static IQueryable<T> GetOrdering<T>(IQueryable<T> source, List<SortParam> SortParams)
        {
            IOrderedQueryable<T> myorder = null;

            foreach (var SortParam in SortParams)
            {
                if (myorder == null)
                {
                    myorder = SortParam.SortOrderDescending.HasValue && SortParam.SortOrderDescending.Value

                        ? source.OrderByDescending(SortParam.OrderProperty)

                        : source.OrderBy(SortParam.OrderProperty);
                }
                else
                {
                    myorder = SortParam.SortOrderDescending.HasValue && SortParam.SortOrderDescending.Value

                        ? myorder.ThenByDescending(SortParam.OrderProperty)

                        : myorder.ThenBy(SortParam.OrderProperty);

                }
            }

            return myorder;
        }


        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
        {
            var param = Expression.Parameter(typeof(T), "x");

            Expression body = param;

            foreach (var props in propertyName.Split('.'))
            {
                body = Expression.PropertyOrField(body, props);
            }

            var sort = Expression.Lambda(body, param);

            MethodCallExpression call = Expression.Call(typeof(Queryable),
                                        (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                                        new[] { typeof(T), body.Type },
                                        source.Expression,
                                        Expression.Quote(sort));

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }


        private static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, false);
        }


        private static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, true, false);
        }


        private static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, true);
        }


        private static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, true, true);
        }

    }
    public class PageParam
    {
        const int maxPageSize = 50;

        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value > maxPageSize ? maxPageSize : value;
            }
        }

        public int PageNumber { get; set; } = 1;
    }
    public class QueryObjectParams : PageParam
    {
        public List<SortParam> SortingParams { get; set; }
    }
    public class QueryResult<T>
    {
        public IEnumerable<T> Entities { get; set; }
        public int TotalCount { get; set; }

        public QueryResult()
        {

        }

        public QueryResult(IEnumerable<T> entities, int totalCount)
        {
            TotalCount = totalCount;

            Entities = entities;
        }
    }
    public class SortParam
    {
        public bool? SortOrderDescending { get; set; }

        public string OrderProperty { get; set; }
    }
}