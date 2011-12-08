using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(WebFormDisplayEngine))]
  public class WebFormDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayReports,
                                      WebFormDisplayEngine>
    {
    }

    public class when_displaying_a_report : concern
    {
      Establish c = () =>
      {
        view_factory = depends.on<ICreateViewInstances>();
        the_report = new Report();
      };

      Because b = () =>
        sut.display(the_report);

      It should_create_the_view_that_can_display_the_report = () =>
        view_factory.received(x => x.create_view_that_can_display(the_report));


      static Report the_report;
      static ICreateViewInstances view_factory;
    }

    class Report
    {
    }
  }
}