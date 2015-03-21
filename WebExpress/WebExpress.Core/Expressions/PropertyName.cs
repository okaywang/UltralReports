
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core.Expressions
{
    public class PropertyName<T>
    { 
        public static string For(Expression<Func<T, object>> expression)
        {
            Expression body = expression.Body;
            return GetMemberName(body);
        }

        public static string GetMemberName(Expression expression)
        {
            if (expression is MemberExpression)
            {
                var memberExpression = (MemberExpression)expression;
                if (memberExpression.Expression.NodeType == ExpressionType.MemberAccess)
                {
                    return GetMemberName(memberExpression.Expression) + "." + memberExpression.Member.Name;
                }
                return memberExpression.Member.Name;
            }
            if (expression is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)expression;
                if (unaryExpression.NodeType != ExpressionType.Convert)
                {
                    throw new Exception(string.Format("Cannot interpret member from {0}", expression));
                }
                return GetMemberName(unaryExpression.Operand);
            }

            throw new Exception(string.Format("Could not determine member from {0}", expression));
        }
    }
}
