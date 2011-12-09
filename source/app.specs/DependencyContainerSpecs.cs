using System;
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
      public class and_there_are_no_issues
      {
        Establish c = () =>
        {
          item_created_by_the_factory = new OurItem();

          dependency_factories = depends.on<IFindDependencyFactories>();
          dependency_factory = fake.an<ICreateASingleDependency>();
          dependency_factories.setup(x => x.get_factory_that_can_create(typeof(OurItem)))
            .Return(dependency_factory);
          dependency_factory.setup(x => x.create()).Return(item_created_by_the_factory);
        };

        Because b = () =>
          result = sut.a<OurItem>();

        It should_return_the_item_created_by_the_dependency_factory_for_the_requested_type = () =>
          result.ShouldEqual(item_created_by_the_factory);

        static OurItem result;
        static object item_created_by_the_factory;
        static ICreateASingleDependency dependency_factory;
        static IFindDependencyFactories dependency_factories;
      }
      public class and_the_factory_for_the_dependency_throws_an_exception_when_creating_an_item
      {
        Establish c = () =>
        {
          exception = new Exception();
          item_created_by_the_factory = new OurItem();

          dependency_factories = depends.on<IFindDependencyFactories>();
          dependency_factory = fake.an<ICreateASingleDependency>();
          dependency_factories.setup(x => x.get_factory_that_can_create(typeof(OurItem)))
            .Return(dependency_factory);
          dependency_factory.setup(x => x.create()).Throw(exception);
        };

        Because b = () =>
          spec.catch_exception(() => sut.a<OurItem>());

          private It should_throw_an_exception_with_the_correct_details = () =>
                                                                              {
                                                                                  var item =
                                                                                      spec.exception_thrown.ShouldBeAn
                                                                                          <DependencyCreationException>();
                                                                                  item.InnerException.ShouldEqual(
                                                                                      exception);
                                                                                  item.type_that_could_not_be_created.
                                                                                      ShouldEqual(typeof (OurItem));
                                                                              };

        static OurItem result;
        static object item_created_by_the_factory;
        static ICreateASingleDependency dependency_factory;
        static IFindDependencyFactories dependency_factories;
        static Exception exception;
      }
    }

    public class OurItem
    {
      
    }
  }
}
