namespace app.web.core
{
  public interface IProcessRequests
  {
    void process(IProvideDetailsForACommand controller_request);
  }
}