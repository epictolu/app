using Machine.Specifications;
using app.web.application;
using app.web.application.models;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class ViewReportSpecs
  {
    public abstract class concern : Observes<ISupportAStory, ViewReport<OurModel>>
    {
    }

    public class when_run : concern
    {
      static IDisplayReports display_engine;
      static IProvideDetailsForACommand request;

      Establish c = () =>
      {
        display_engine = depends.on<IDisplayReports>();
        the_model = new OurModel();

        query = depends.on<IFetchInformation<OurModel>>();

        request = fake.an<IProvideDetailsForACommand>();

        query.setup(x => x.fetch_using(request)).Return(the_model);
      };

      Because of = () => sut.run(request);

      It should_display_the_products_for_the_department = () =>
        display_engine.received(x => x.display(the_model));

      static IFetchInformation<OurModel> query;
      static OurModel the_model;
    }

    public class OurModel
    {
    }
  }
}