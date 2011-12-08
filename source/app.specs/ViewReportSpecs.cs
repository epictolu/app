using Machine.Specifications;
using Rhino.Mocks;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class ViewReportSpecs
  {
    public abstract class concern : Observes<ISupportAStory, ViewReport<OurModel,TheQuery>>
    {
    }

    public class TheQuery : IFetchInformation<OurModel>
    {
      public OurModel fetch_using(IProvideDetailsForACommand request)
      {
        return new OurModel();
      }
    }

    public class when_run : concern
    {
      static IDisplayReports display_engine;
      static IProvideDetailsForACommand request;

      Establish c = () =>
      {
        display_engine = depends.on<IDisplayReports>();
        the_model = new OurModel();

        request = fake.an<IProvideDetailsForACommand>();
      };

      Because of = () => sut.run(request);

      It should_display_the_products_for_the_department = () =>
        display_engine.received(x => x.display(Arg<OurModel>.Is.NotNull));

      static OurModel the_model;
    }

    public class OurModel
    {
    }
  }
}