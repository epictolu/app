using app.web.core;

namespace app.web.application
{
  public class ViewReport<ReportModel,Query> : ISupportAStory where Query : IFetchInformation<ReportModel>,new()
  {
    IDisplayReports display_engine;
    Query query;

    public ViewReport(IDisplayReports display_engine)
    {
      this.display_engine = display_engine;
      this.query = new Query();
    }

    public void run(IProvideDetailsForACommand request)
    {
      display_engine.display(query.fetch_using(request));
    }
  }
}