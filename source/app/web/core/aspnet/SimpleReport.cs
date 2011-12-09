using System.Web.UI;

namespace app.web.core.aspnet
{
  public class SimpleReport<ReportModel> : Page,IDisplayA<ReportModel>
  {
    public ReportModel report_model { get; set; }
  }
}