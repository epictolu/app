 
using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace nothinbutdotnetstore.specs
{
    public class ExpressionSpecs
    {
        public abstract class concern : Observes
        {

        }

        [Subject(typeof(Expression<>))]
        public class when_playing_around_with_expressions : concern
        {
            It should_be_able_to_create_a_method_dynamically = () =>
            {
                Func<int, bool> is_even = x => x%2 == 0;
                is_even(2).ShouldBeTrue();

                ParameterExpression incoming_number = Expression.Parameter(typeof(int),"x");
                ConstantExpression the_number_two = Expression.Constant(2);
                BinaryExpression modulo = Expression.Modulo(incoming_number,the_number_two);
                BinaryExpression equal = Expression.Equal(modulo,Expression.Constant(0));

                var dynamic_even = Expression.Lambda<Func<int,bool>>(equal,incoming_number);
                dynamic_even.Compile()(2).ShouldBeTrue();
            };

        }
    }
}
