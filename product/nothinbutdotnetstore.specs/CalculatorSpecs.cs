using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace nothinbutdotnetstore.specs
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator>
        {
            Establish c = () =>
            {
                values = new List<int>();
//                provide_a_basic_sut_constructor_argument(23);        
//                provide_a_basic_sut_constructor_argument(values);        
//                create_sut_using(() => new Calculator(connection,
//                    reader,2,values,3));


            };

            static List<int> values;
        }


        [Subject(typeof(Calculator))]
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

        [Subject(typeof(Calculator))]
        public class when_adding_two_positive_numbers : concern
        {
            Establish c = () =>
            {
                connection = the_dependency<IDbConnection>();
                command = an<IDbCommand>();

                connection.Stub(x => x.CreateCommand())
                    .Return(command);
            };

            Because b = () =>
                result = sut.add(2, 3);

            It should_open_a_connection_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_a_query = () =>
                command.received(x => x.ExecuteNonQuery());

            It should_dispose_both_the_command_and_connection = () =>
            {
                connection.received(x => x.Dispose());
                command.received(x => x.Dispose());
            };

            It should_return_the_sum = () =>
                result.ShouldEqual(5);

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }

        [Subject(typeof(Calculator))]
        public class when_attempting_to_add_a_negative_number : concern
        {
            Because b = () =>
                catch_exception(() => sut.add(2, -1));

            It should_not_allow_it_to_occur = () =>
                exception_thrown_by_the_sut.ShouldBeAn<ArgumentException>();
        }

        [Subject(typeof(Calculator))]
        public class when_shutting_down_the_calculator_and_they_are_not_in_the_correct_security_group : concern
        {
            Establish c = () =>
            {
                fake_principal = an<IPrincipal>();

                fake_principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything))
                    .Return(false);

                change(() => Thread.CurrentPrincipal).to(fake_principal);
            };

            Because b = () =>
                catch_exception(() => sut.shut_off());

            It should_throw_an_security_exception = () =>
                exception_thrown_by_the_sut.ShouldBeAn<SecurityException>();

            static IPrincipal fake_principal;
        }
        public class when_shutting_down_the_calculator_and_they_are_in_the_correct_role: concern
        {
            Establish c = () =>
            {
                fake_principal = an<IPrincipal>();

                fake_principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything))
                    .Return(true);

                change(() => Thread.CurrentPrincipal).to(fake_principal);
            };

            Because b = () =>
                sut.shut_off();

            It should_not_do_anything = () =>
            {

            };


            static IPrincipal fake_principal;
        }
    }
}