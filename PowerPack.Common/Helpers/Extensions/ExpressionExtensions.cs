using System;
using System.Linq.Expressions;

namespace PowerPack.Common.Helpers.Extensions
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression)
        {
            var member = (MemberExpression)expression.Body;
            return member.Member.Name;
        }
    }
}
