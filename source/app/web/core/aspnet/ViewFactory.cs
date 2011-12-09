using System.Web;
using System.Web.Compilation;
using app.web.core.stubs;

namespace app.web.core.aspnet
{
  public class ViewFactory : ICreateViewInstances
  {
    IFindPathsToViews path_registry;
    PageFactory page_factory;

    public ViewFactory(IFindPathsToViews path_registry, PageFactory page_factory)
    {
      this.path_registry = path_registry;
      this.page_factory = page_factory;
    }


    public IHttpHandler create_view_that_can_display<ReportModel>(ReportModel the_report)
    {
      var path = path_registry.get_path_to_view_that_can_display<ReportModel>(); 
      var view = (IDisplayA<ReportModel>)page_factory(path,typeof(IDisplayA<ReportModel>));
      view.report_model =the_report;
      return view;
    }
  }
}