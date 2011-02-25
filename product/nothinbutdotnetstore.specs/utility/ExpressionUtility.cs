using System.Linq.Expressions;
using System.Reflection;
using Machine.Specifications.DevelopWithPassion.Extensions;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.specs.utility
{
    public class ExpressionUtility
    {
        public static PropertyInfo get_the_property_on<T>(Expression<PropertyAccessor<T, object>> property_accessor)
        {
            return property_accessor.Body
                .downcast_to<MemberExpression>().Member
                .downcast_to<PropertyInfo>();
        }
    }
}