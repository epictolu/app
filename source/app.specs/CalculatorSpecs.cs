using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
    }

    public class when_attempting_to_add_a_negative_number : concern
    {
      Because b = () =>
        spec.catch_exception(() => sut.add(2, -3));

      It should_throw_an_argument_exception = () =>
        spec.exception_thrown.ShouldBeAn<ArgumentException>();
    }

    public class when_shutting_off_the_calculator : concern
    {
      public class and_they_are_not_in_the_correct_role
      {
        Establish c = () =>
        {
          fake_principal = fake.an<IPrincipal>();
          fake_principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

          spec.change(() => Thread.CurrentPrincipal).to(fake_principal);
        };

        Because b = () =>
          spec.catch_exception(() => sut.shut_off());

        It should_throw_a_security_exception = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();

        static IPrincipal fake_principal;
      }
    }

    public class when_adding_two_numbers : concern
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
        depends.on(3);
        command = fake.an<IDbCommand>();

        connection.setup(x => x.CreateCommand()).Return(command);
      };

      Because b = () =>
        result = sut.add(2, 3);

      It should_open_a_connection_to_the_database = () =>
        connection.received(x => x.Open());

      It should_dispose_items = () =>
      {
        connection.received(x => x.Dispose());
        command.received(x => x.Dispose());
      };

      It should_run_a_query = () =>
        command.received(x => x.ExecuteNonQuery());

      It should_return_the_sum = () =>
        result.ShouldEqual(5);

      static int result;
      static IDbConnection connection;
      static IDbCommand command;
    }
  }
}