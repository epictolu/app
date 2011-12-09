using System.Web;
using System.Web.UI;
using Machine.Specifications;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
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
        a_view = fake.an<IDisplayA<TheViewsModel>>();
        the_path = "blah.aspx";
        the_views_report = new TheViewsModel();
        view_path_registry = depends.on<IFindPathsToViews>();
        view_path_registry.setup(x => x.get_path_to_view_that_can_display<TheViewsModel>()).Return(the_path);

        depends.on<PageFactory>((path, type) =>
        {
          path.ShouldEqual(the_path);
          type.ShouldEqual(typeof(IDisplayA<TheViewsModel>));
          return a_view;
        });
      };

      Because of = () =>
        result = sut.create_view_that_can_display(the_views_report);

      It should_populate_the_view_with_its_model = () =>
        a_view.report_model.ShouldEqual(the_views_report);
        

      It should_return_the_view_created_using_its_path_information = () =>
        result.ShouldEqual(a_view);
        
      static IFindPathsToViews view_path_registry;
      static TheViewsModel the_views_report;
      static string the_path;
      static IHttpHandler result;
      static IDisplayA<TheViewsModel> a_view;
    }

    public class TheViewsModel
    {
    }
  }
}