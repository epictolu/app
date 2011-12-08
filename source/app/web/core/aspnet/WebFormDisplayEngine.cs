using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
    ICreateViewInstances view_factory;
    GetTheCurrentHttpContext current_context;

    public WebFormDisplayEngine(ICreateViewInstances view_factory, GetTheCurrentHttpContext current_context)
    {
      this.view_factory = view_factory;
      this.current_context = current_context;
    }

    public WebFormDisplayEngine():this(null,() => HttpContext.Current)
    {
    }

    public void display<ReportModel>(ReportModel report)
    {
      view_factory.create_view_that_can_display(report).ProcessRequest(current_context());
    }
  }
}