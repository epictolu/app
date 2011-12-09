using Machine.Specifications;
using app.infrastructure.containers;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Container))]
  public class ContainerSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_accessing_the_container_facade : concern
    {
      Establish c = () =>
      {
        the_container_facade = fake.an<IFetchDependencies>();
        ContainerFacadeResolver resolver = () => the_container_facade;
        spec.change(() => Container.facade_resolver).to(resolver);
      };

      Because b = () =>
        result = Container.fetch;

      It should_return_the_container_created_by_the_facade_resolver = () =>
        result.ShouldEqual(the_container_facade);

      static IFetchDependencies result;
      static IFetchDependencies the_container_facade;
    }
  }
}