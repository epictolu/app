namespace app.web.core
{
  public interface IProcessOneRequest
  {
    void run(IProvideDetailsForACommand request);
  }
}