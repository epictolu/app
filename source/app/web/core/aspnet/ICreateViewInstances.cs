using System.Web;

namespace app.web.core.aspnet
{
  public interface ICreateViewInstances
  {
    IHttpHandler create_view_that_can_display<ReportModel>(ReportModel the_report);
  }
}