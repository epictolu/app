namespace app.web.core
{
  public interface IFetchInformation<ReportModel>
  {
    ReportModel fetch_using(IProvideDetailsForACommand request);
  }
}