namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayReports
  {
    ICreateViewInstances view_factory;

    public WebFormDisplayEngine(ICreateViewInstances view_factory)
    {
      this.view_factory = view_factory;
    }

    public void display<ReportModel>(ReportModel report)
    {
      view_factory.create_view_that_can_display(report);
    }
  }
}