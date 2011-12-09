using Machine.Specifications;
using app.infrastructure.containers.basic;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(DependencyFactoryRegistry))]
  public class DependencyFactoryRegistrySpecs
  {
    public abstract class concern : Observes<IFindDependencyFactories,
                                      DependencyFactoryRegistry>
    {
    }

    public class when_finding_a_factory_to_create_a_dependency : concern
    {
      public class and_it_has_the_factory
      {
        Establish c = () =>
        {
          the_factory = fake.an<ICreateASingleDependency>();
        };
        Because b = () =>
          result = sut.get_factory_that_can_create(typeof(AnItem));

        It should_return_the_factory_to_the_caller = () =>
          result.ShouldEqual(the_factory);

        static ICreateASingleDependency result;
        static ICreateASingleDependency the_factory;
      }
    }

    public class AnItem
    {
    }
  }
}