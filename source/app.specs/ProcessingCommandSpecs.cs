using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ProcessingCommand))]
  public class ProcessingCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      ProcessingCommand>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsForACommand>();
        depends.on<RequestMatch>(x => true);
      };

      Because b = () =>
        result = sut.can_handle(request);

      It should_make_its_determination_by_using_its_request_specification = () =>
        result.ShouldBeTrue();

      static IProvideDetailsForACommand request;
      static bool result;
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsForACommand>();
        application_feature = depends.on<ISupportAStory>();
      };

      Because b = () =>
        sut.run(request);

      It should_run_the_application_feature = () =>
        application_feature.received(x => x.run(request));

      static IProvideDetailsForACommand request;
      static ISupportAStory application_feature;
    }
  }
}
