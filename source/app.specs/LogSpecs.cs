using Machine.Specifications;
using app.infrastructure.containers;
using app.infrastructure.logging;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Log))]
  public class LogSpecs
  {
    public abstract class concern : Observes
    {

    }

    public class when_accessing_the_logging_gateway : concern
    {
      Establish c = () =>
      {
        factory = fake.an<ICreateLoggers>();
        the_container = fake.an<IFetchDependencies>();
        ContainerFacadeResolver resolver= () => the_container;
        logger_for_type = fake.an<ILogInformation>();

        spec.change(() => Container.facade_resolver).to(resolver);
        factory.setup(x => x.create_logger_bound_to(typeof(when_accessing_the_logging_gateway)))
          .Return(logger_for_type);
        the_container.setup(x => x.a<ICreateLoggers>()).Return(factory);
      };
      Because b = () =>
        result = Log.an;

      It should_return_a_logger_bound_to_the_calling_type = () =>
        result.ShouldEqual(logger_for_type);

      static ILogInformation result;
      static ILogInformation logger_for_type;
      static ICreateLoggers factory;
      static IFetchDependencies the_container;
    }
  }
}
