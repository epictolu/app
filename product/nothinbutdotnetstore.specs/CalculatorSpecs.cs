using System;
using System.Data;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator>
        {
            
        }

        public class when_created : concern
        {
            Establish c = () =>
            {
                connection = the_dependency<IDbConnection>();
            };

            It should_not_open_the_connection_to_the_database = () =>
                connection.never_received(x => x.Open());

            static IDbConnection connection;
        }

        public class when_adding_two_positive_numbers : concern
        {
            Establish c = () =>
            {
                connection = the_dependency<IDbConnection>();
            };

            Because b = () =>
                result = sut.add(2, 3);

            It should_open_a_connection_to_the_database = () =>
                connection.received(x => x.Open());
  
            It should_return_the_sum = () =>
                result.ShouldEqual(5);


            static int result;
            static IDbConnection connection;
        }

        [Subject(typeof(Calculator))]
        public class when_attempting_to_add_a_negative_number : concern
        {
            Because b = () =>
                catch_exception(() => sut.add(2, -1));


            It should_not_allow_it_to_occur = () =>
                exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();
                
        }

        
    }
}
