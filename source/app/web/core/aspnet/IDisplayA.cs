using System.Web;

namespace app.web.core.aspnet
{
  public interface IDisplayA<ReportModel> : IHttpHandler
  {
    ReportModel report_model { get; set; }
  }
}