using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            static int result;

            // This is the code we want to test.
            Because b = () =>
                result = Calculator.add(2, 3);

            // This is an assertion that we want to make.
            // Assertion methods start with "Should"
            It should_return_the_sum = () =>
                result.ShouldEqual(5);
        }

        [Subject(typeof (Calculator))]
        public class when_attempting_to_add_a_negative_number : concern
        {
            private Because b = () =>
                catch_exception(() => Calculator.add(2, -1));

            It should_not_allow_it_to_occur = () =>
                exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();
        }

        
    }
}
