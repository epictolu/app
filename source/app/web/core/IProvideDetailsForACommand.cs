namespace app.web.core
{
  public interface IProvideDetailsForACommand
  {
      bool CanBeHandledBy(IProcessOneRequest request);
  }
}