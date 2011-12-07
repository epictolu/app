namespace app.web.core
{
  public interface IProcessOneRequest : ISupportAStory
  {
    bool can_handle(IProvideDetailsForACommand request);
  }
}