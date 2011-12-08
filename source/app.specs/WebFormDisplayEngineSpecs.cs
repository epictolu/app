using System.Collections.Generic;
using System.Web;
using app.specs.utility;
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
        view = fake.an<IHttpHandler>();
        view_factory = depends.on<ICreateViewInstances>();
        the_context = ObjectFactory.web.create_http_context();
        the_report = new Report();
        view_factory.setup(x => x.create_view_that_can_display(the_report)).Return(view);

        depends.on<GetTheCurrentHttpContext>(() => the_context);
      };

      Because b = () =>
        sut.display(the_report);

      It should_tell_the_view_to_process_using_the_active_context = () =>
        view.received(x => x.ProcessRequest(the_context));

      static Report the_report;
      static ICreateViewInstances view_factory;
      static IHttpHandler view;
      static HttpContext the_context;
    }

    class Report
    {
    }
  }

  [Subject(typeof(ViewFactory))]
  public class ViewFactorySpecs
  {
    public abstract class concern : Observes<ICreateViewInstances,
                                      ViewFactory>
    {
    }

    public class when_creating_a_view_that_can_display_the_report : concern
    {
      Establish c = () =>
      {
        var a_view_for_the_report = fake.an<IDisplayAReport>();
        a_view_for_the_report.setup(x => x.can_i_handle());

        depends.on<IEnumerable<IDisplayAReport>>(new[] { a_view_for_the_report });
      };

      Because of = () =>
        sut.create_view_that_can_display(the_report);

      It should_create_a_view_that_can_display_the_report = () =>
        the_report.ShouldNotBeNull();

      static IHttpHandler the_report;
    }
  }

  public interface IDisplayAReport
  {
  }

  public class ViewFactory : ICreateViewInstances
  {
    public IHttpHandler create_view_that_can_display<ReportModel>(ReportModel the_report)
    {
      throw new System.NotImplementedException();
    }
  }
}