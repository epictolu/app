using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes
        {
            
        }

        public class when_adding_two_positive_numbers : concern
        {
            Because b = () =>
                result = Calculator.add(2, 3);


            It should_return_the_sum = () =>
                result.ShouldEqual(5);


            static int result;
        }

        [Subject(typeof(Calculator))]
        public class when_attempting_to_add_a_negative_number : concern
        {
            Because b = () =>
                catch_exception(() => Calculator.add(2, -1));


            It should_not_allow_it_to_occur = () =>
                exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();
                
        }
    }
}