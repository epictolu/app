using app.infrastructure.containers;
using app.infrastructure.containers.basic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(DependencyContainer))]
  public class DependencyContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      DependencyContainer>
    {
    }

    public class when_fetching_a_dependency : concern
    {
      Establish c = () =>
      {
        item_created_by_the_factory = new OurItem();

        var dependency_factory = depends.on<ICreateDependencies>();
        dependency_factory.setup(x => x.create_a<OurItem>()).Return(item_created_by_the_factory);
      };

      Because b = () =>
        result = sut.a<OurItem>();

      It should_return_the_item_created_by_the_dependency_factory_for_the_requested_type = () =>
        result.ShouldEqual(item_created_by_the_factory);

      static OurItem result;
      static OurItem item_created_by_the_factory;
    }

    public class OurItem
    {
      
    }
  }

  public interface ICreateDependencies
  {
    T create_a<T>();
  }
}