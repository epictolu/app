namespace app.web.core
{
  public interface IProcessOneRequest
  {
    void run(IProvideDetailsForACommand request);
    bool can_handle(IProvideDetailsForACommand request);
  }
}