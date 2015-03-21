using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    public static class IQueryableExtension
    {
        public static IOrderedQueryable<T> ObjectSort<T>(this IQueryable<T> query, Expression<Func<T, object>> expression, SortOrder direction = SortOrder.Ascending)
        {
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                var propertyExpression = (MemberExpression)unaryExpression.Operand;
                var parameters = expression.Parameters;

                if (propertyExpression.Type == typeof(DateTime))
                {
                    var newExpression = Expression.Lambda<Func<T, DateTime>>(propertyExpression, parameters);
                    return direction == SortOrder.Ascending ? query.OrderBy(newExpression) : query.OrderByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(int))
                {
                    var newExpression = Expression.Lambda<Func<T, int>>(propertyExpression, parameters);
                    return direction == SortOrder.Ascending ? query.OrderBy(newExpression) : query.OrderByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(bool))
                {
                    var newExpression = Expression.Lambda<Func<T, bool>>(propertyExpression, parameters);
                    return direction == SortOrder.Ascending ? query.OrderBy(newExpression) : query.OrderByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(decimal))
                {
                    var newExpression = Expression.Lambda<Func<T, decimal>>(propertyExpression, parameters);
                    return direction == SortOrder.Ascending ? query.OrderBy(newExpression) : query.OrderByDescending(newExpression);
                }

                throw new NotSupportedException("Object type resolution not implemented for this type");
            }
            return query.OrderBy(expression);
        }

        public static IOrderedQueryable<T> ThenObjectSort<T>(this IOrderedQueryable<T> query, Expression<Func<T, object>> expression, SortOrder direction = SortOrder.Ascending)
        {
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                var propertyExpression = (MemberExpression)unaryExpression.Operand;
                var parameters = expression.Parameters;

                if (propertyExpression.Type == typeof(DateTime))
                {
                    var newExpression = Expression.Lambda<Func<T, DateTime>>(propertyExpression, parameters);
                    return direction == SortOrder.Ascending ? query.ThenBy(newExpression) : query.ThenByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(int))
                {
                    var newExpression = Expression.Lambda<Func<T, int>>(propertyExpression, parameters);
                    return direction == SortOrder.Ascending ? query.ThenBy(newExpression) : query.ThenByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(bool))
                {
                    var newExpression = Expression.Lambda<Func<T, bool>>(propertyExpression, parameters);
                    return direction == SortOrder.Ascending ? query.ThenBy(newExpression) : query.ThenByDescending(newExpression);
                }

                if (propertyExpression.Type == typeof(decimal))
                {
                    var newExpression = Expression.Lambda<Func<T, decimal>>(propertyExpression, parameters);
                    return direction == SortOrder.Ascending ? query.ThenBy(newExpression) : query.ThenByDescending(newExpression);
                }

                throw new NotSupportedException("Object type resolution not implemented for this type");
            }
            return query.OrderBy(expression);
        }
    }
}
