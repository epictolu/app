using System.Web;

namespace app.web.core
{
  public class StubDisplayEngine:IDisplayReports
  {
    public void display<ReportModel>(ReportModel report)
    {
      HttpContext.Current.Items.Add("blah",report);
      HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx", true);
    }
  }
}