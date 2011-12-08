using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Stub))]
  public class StubGatewaySpecs
  {
    public abstract class concern
    {
    }

    public class when_asked_for_a_stub : concern
    {
      Establish c = () =>
      {
      };

      Because b = () =>
        result = Stub.with<AStub>();

      It should_return_the_stub_instance =
        () => result.ShouldBeAn<AStub>();

      static AStub result;
    }

    public class AStub
    {
    }
  }
}